//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.Network.EventsArgs;
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace StilSoft.Network
{
    public class ServerConnection : IDisposable
    {
        private bool _disposed;

        private TcpClient _client;
        private Task _receiveTask;
        private readonly object _connectionLock = new object();
        private readonly Timer _autoReconnectTimer;
        private int _reconnectAttemptsCounter;
        private CancellationTokenSource _receiveCancellationTokenSource;
        private readonly ManualResetEvent _sendReceiveDataEvent;

        public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public event EventHandler<ErrorEventArgs> InternalError;

        public ConnectionState State { get; private set; } = ConnectionState.Disconnected;
        public string Hostname { get; set; }
        public int Port { get; set; }
        public int ConnectTimeOut { get; set; } = 2000;
        public int SendTimeOut { get; set; } = 2000;
        public int ReceiveTimeOut { get; set; } = 2000;
        public int SendBufferSize { get; set; } = 16 * 1024;
        public int ReceiveBufferSize { get; set; } = 16 * 1024;
        public bool AutoConnect { get; set; }
        public bool AutoReconnect { get; set; }
        public int AutoReconnectInterval
        {
            get { return (int)_autoReconnectTimer.Interval; }
            set { _autoReconnectTimer.Interval = value; }
        }
        public int ReconnectAttempts { get; set; } = 10;


        public ServerConnection()
        {
            _autoReconnectTimer = new Timer { Interval = 1000 };
            _autoReconnectTimer.Elapsed += AutoReconnectTimer_Elapsed;
            _autoReconnectTimer.AutoReset = false;

            _sendReceiveDataEvent = new ManualResetEvent(false);
        }

        public ServerConnection(string hostname, int port) : this()
        {
            Hostname = hostname;
            Port = port;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                Disconnect();

            _disposed = true;
        }

        ~ServerConnection()
        {
            Dispose(false);
        }


        public Task ConnectAsync()
        {
            return ConnectAsync(Hostname, Port);
        }

        public Task ConnectAsync(string hostname, int port)
        {
            return Task.Run(() => ConnectInternal(hostname, port));
        }

        public void Connect()
        {
            ConnectInternal(Hostname, Port);
        }

        public void Connect(string hostname, int port)
        {
            ConnectInternal(hostname, port);
        }

        private void ConnectInternal(string hostname, int port, bool reconnect = false)
        {
            lock (_connectionLock)
            {
                Hostname = hostname;
                Port = port;

                Disconnect();

                _client = new TcpClient
                {
                    SendTimeout = SendTimeOut,
                    SendBufferSize = SendBufferSize,
                    ReceiveBufferSize = ReceiveBufferSize,
                    NoDelay = true
                };

                KeepAlive(true, 500, 300);

                try
                {
                    OnConnectionStateChanged(reconnect ? ConnectionState.Reconnecting : ConnectionState.Connecting);

                    var isConnectComplete = _client.ConnectAsync(hostname, port).Wait(ConnectTimeOut);

                    if (!isConnectComplete)
                        throw new TimeoutException("Connect timeout.");
                }
                catch (Exception ex)
                {
                    Disconnect();

                    if (ex is AggregateException && ex.InnerException is SocketException)
                        throw ex.InnerException;

                    throw;
                }

                if (!IsConnected())
                {
                    Disconnect();

                    throw new InvalidOperationException("Unable to connect.");
                }

                _reconnectAttemptsCounter = ReconnectAttempts;

                StartReceiveTask();

                OnConnectionStateChanged(ConnectionState.Connected);
            }
        }

        public Task DisconnectAsync()
        {
            return Task.Run(() => Disconnect());
        }

        public void Disconnect()
        {
            lock (_connectionLock)
            {
                _autoReconnectTimer.Enabled = false;

                StopReceiveTask();

                _sendReceiveDataEvent.Set();
                _sendReceiveDataEvent.Reset();

                _client?.Close();
                _client = null;

                try
                {
                    _receiveTask?.Wait(500);
                }
                catch
                {
                    // ignored
                }

                if (State != ConnectionState.Disconnected)
                    OnConnectionStateChanged(ConnectionState.Disconnected);
            }
        }

        public bool IsConnected()
        {
            var checkIsConnected = _client != null &&
                                   _client.Connected &&
                                   !(_client.Client.Poll(0, SelectMode.SelectRead) && _client.Available == 0) &&
                                   _client.Client.Poll(0, SelectMode.SelectWrite) &&
                                   !_client.Client.Poll(0, SelectMode.SelectError);

            return checkIsConnected;
        }

        public void Send(byte[] data)
        {
            SendReceive(data, null);
        }

        public void SendReceive(byte[] data, Func<byte[], bool> dataReceiver, bool clearReceiveBuffer = false)
        {
            lock (_connectionLock)
            {
                if (!IsConnected())
                {
                    if (!AutoConnect)
                        throw new InvalidOperationException("A request to send data was disallowed because the socket is not connected.");

                    Connect();
                }

                // Clear received before sending new data
                if (clearReceiveBuffer)
                {
                    while (_client.Available > 0)
                    {
                        var dummy = new byte[_client.Available];
                        _client.Client.Receive(dummy);
                    }
                }

                // Send data
                _client.Client.Send(data);

                if (dataReceiver == null)
                    return;

                // Receive data if data receiver function is set
                EventHandler<DataReceivedEventArgs> receivedDataHandler = (sender, e) =>
                {
                    // Return if event is set
                    if (_sendReceiveDataEvent.WaitOne(0))
                        return;

                    // Set event If data receiver return true
                    if (dataReceiver(e.Data))
                        _sendReceiveDataEvent.Set();
                };

                DataReceived += receivedDataHandler;

                // Wait data receiver to complete
                var isReceiverComplete = _sendReceiveDataEvent.WaitOne(ReceiveTimeOut);

                DataReceived -= receivedDataHandler;

                _sendReceiveDataEvent.Reset();

                // If data receiver function not return true in specified "ReceiveTimeOut" time then throw "TimeoutException"
                if (!isReceiverComplete)
                    throw new TimeoutException("Timeout receiving data.");
            }
        }

        private void StartReceiveTask()
        {
            _receiveCancellationTokenSource = new CancellationTokenSource();

            _receiveTask = Task.Factory.StartNew(() => ReceiveThread(_receiveCancellationTokenSource.Token),
                 _receiveCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        private void StopReceiveTask()
        {
            _receiveCancellationTokenSource?.Cancel();
        }

        private void ReceiveThread(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var receiveBuffer = new byte[ReceiveBufferSize];
                    var totalBytesReceived = _client.Client.Receive(receiveBuffer);

                    if (totalBytesReceived == 0)
                        throw new InvalidOperationException("Received zero bytes.");

                    var buffer = new byte[totalBytesReceived];
                    Array.Copy(receiveBuffer, buffer, totalBytesReceived);

                    OnDataReceived(buffer);
                }
                catch (Exception ex)
                {
                    var socketException = ex as SocketException;

                    if (socketException?.SocketErrorCode == SocketError.Interrupted)
                        break;

                    Disconnect();

                    if (AutoReconnect)
                        _autoReconnectTimer.Enabled = true;

                    OnInternalError(ex);

                    break;
                }
            }
        }

        private void AutoReconnectTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (IsConnected() || _reconnectAttemptsCounter == 0)
                return;

            _reconnectAttemptsCounter--;

            try
            {
                ConnectInternal(Hostname, Port, true);
            }
            catch
            {
                _autoReconnectTimer.Enabled = AutoReconnect;
            }
        }

        private void OnConnectionStateChanged(ConnectionState state)
        {
            State = state;

            ConnectionStateChanged?.Invoke(this, new ConnectionStateChangedEventArgs(state));
        }

        private void OnDataReceived(byte[] data)
        {
            DataReceived?.Invoke(this, new DataReceivedEventArgs(data));
        }

        private void OnInternalError(Exception ex)
        {
            try
            {
                InternalError?.Invoke(this, new ErrorEventArgs(ex));
            }
            catch
            {
                // ignored
            }
        }

        private void KeepAlive(bool enable, int keepAliveTime, int keepAliveInterval)
        {
            var size = Marshal.SizeOf(new uint());
            var values = new byte[size * 3];

            BitConverter.GetBytes((uint)(enable ? 1 : 0)).CopyTo(values, 0);
            BitConverter.GetBytes((uint)keepAliveTime).CopyTo(values, size);
            BitConverter.GetBytes((uint)keepAliveInterval).CopyTo(values, size * 2);

            _client?.Client?.IOControl(IOControlCode.KeepAliveValues, values, null);
        }
    }
}
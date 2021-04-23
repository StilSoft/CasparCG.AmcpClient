//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System;
using System.Threading.Tasks;
using CasparCg.AmcpClient.Abstracts.Command;
using CasparCg.AmcpClient.Commands.Query;
using CasparCg.AmcpClient.Commands.Query.Common;
using CasparCg.AmcpClient.Common.EventsArgs;
using StilSoft.Communication.Tcp;

namespace CasparCg.AmcpClient
{
    public class AmcpConnection : TcpClient, ICommandConnection
    {
        private readonly object _lockServerVersion = new object();
        private volatile Version _serverVersion;

        public new event EventHandler<DataReceivedEventArgs> DataReceived;


        public AmcpConnection(string hostname = "localhost", int port = 5250)
        {
            Hostname = hostname;
            Port = port;

            base.DataReceived += (s, e) => DataReceived?.Invoke(s, new DataReceivedEventArgs(e.Data));

            ConnectionStateChanged += (s, e) =>
            {
                if (e.State != ConnectionState.Connected)
                    _serverVersion = null;
            };
        }

        public Task<Version> GetServerVersionAsync()
        {
            return Task.Run(() => GetServerVersion());
        }

        public Version GetServerVersion()
        {
            lock (_lockServerVersion)
            {
                if (_serverVersion != null)
                    return _serverVersion;

                try
                {
                    _serverVersion = new VersionCommand(Component.Server) { DontCheckServerVersion = true }.Execute(this).Version;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Unable to get server version.", ex);
                }

                return _serverVersion;
            }
        }
    }
}
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
        private readonly object lockServerVersion = new object();
        private volatile Version serverVersion;

        public new event EventHandler<DataReceivedEventArgs> DataReceived;


        public AmcpConnection(string hostname = "localhost", int port = 5250)
        {
            this.Hostname = hostname;
            this.Port = port;

            base.DataReceived += (s, e) => this.DataReceived?.Invoke(s, new DataReceivedEventArgs(e.Data));

            this.ConnectionStateChanged += (s, e) =>
            {
                if (e.State != ConnectionState.Connected)
                {
                    this.serverVersion = null;
                }
            };
        }

        public Task<Version> GetServerVersionAsync()
        {
            return Task.Run(() => GetServerVersion());
        }

        public Version GetServerVersion()
        {
            lock (this.lockServerVersion)
            {
                if (this.serverVersion != null)
                {
                    return this.serverVersion;
                }

                try
                {
                    this.serverVersion = new VersionCommand(Component.Server) { DontCheckServerVersion = true }.Execute(this)
                        .Version;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Unable to get server version.", ex);
                }

                return this.serverVersion;
            }
        }
    }
}
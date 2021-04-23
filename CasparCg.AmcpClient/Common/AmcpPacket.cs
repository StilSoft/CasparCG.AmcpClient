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
using System.Text;
using CasparCg.AmcpClient.Abstracts.Command;

namespace CasparCg.AmcpClient.Common
{
    public class AmcpPacket : ICommandPacket
    {
        private readonly string data;

        public bool IncludePacketId { get; set; }
        public string PacketId { get; }

        public byte[] Data
        {
            get
            {
                string packetId = "";

                if (this.IncludePacketId)
                {
                    packetId = $"REQ {this.PacketId} ";
                }

                return Encoding.UTF8.GetBytes($"{packetId}{this.data}\r\n");
            }
        }

        public string CommandName { get; set; }


        public AmcpPacket(string data)
        {
            this.PacketId = Guid.NewGuid().ToString();
            this.data = data;
        }
    }
}
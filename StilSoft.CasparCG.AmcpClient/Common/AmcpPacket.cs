//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Abstracts.Command;
using System;
using System.Text;

namespace StilSoft.CasparCG.AmcpClient.Common
{
    public class AmcpPacket : ICommandPacket
    {
        private readonly string _data;

        public bool IncludePacketId { get; set; }
        public string PacketId { get; }

        public byte[] Data
        {
            get
            {
                var packetId = "";

                if (IncludePacketId)
                    packetId = $"REQ {PacketId} ";

                return Encoding.UTF8.GetBytes($"{packetId}{_data}\r\n");
            }
        }

        public string CommandName { get; set; }


        public AmcpPacket(string data)
        {
            PacketId = Guid.NewGuid().ToString();
            _data = data;
        }
    }
}
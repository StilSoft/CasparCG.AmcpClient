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
        private string _packetId;

        public bool SendPacketId { get; set; }

        public string PacketId
        {
            get
            {
                if (SendPacketId && string.IsNullOrWhiteSpace(_packetId))
                    _packetId = Guid.NewGuid().ToString();

                return _packetId;
            }
        }

        public byte[] Data
        {
            get
            {
                var id = "";

                if (!string.IsNullOrWhiteSpace(PacketId))
                    id = $"REQ {PacketId} ";

                return Encoding.UTF8.GetBytes($"{id}{_data}\r\n");
            }
        }

        public string CommandName { get; set; }


        public AmcpPacket(string data)
        {
            _data = data;
        }
    }
}
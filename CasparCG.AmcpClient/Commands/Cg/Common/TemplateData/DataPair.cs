//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


namespace CasparCg.AmcpClient.Commands.Cg.Common.TemplateData
{
    public class DataPair
    {
        public string Name { get; set; }
        public string Value { get; set; }


        public DataPair(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
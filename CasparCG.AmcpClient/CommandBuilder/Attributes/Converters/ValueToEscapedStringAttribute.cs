//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Converters
{
    internal class ValueToEscapedStringAttribute : AbstractValueToStringConverterAttribute
    {
        public override string GetValue(object value)
        {
            return value.ToString().Replace(@"\", @"\\").
                                    Replace(@"'", @"\''").
                                    Replace(@"""", @"\""");
        }
    }
}
//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Conditions
{
    internal class IncludeIfIncludedAttribute : AbstractPropertyIncludedConditionAttribute
    {
        public IncludeIfIncludedAttribute(string propertyName) : base(propertyName)
        {

        }
    }
}
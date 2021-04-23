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

namespace CasparCg.AmcpClient.CommandBuilder.Attributes
{
    /// <summary>
    /// Specifies that a class should be included in command builder.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandBuilderObjectAttribute : Attribute
    {
        
    }
}
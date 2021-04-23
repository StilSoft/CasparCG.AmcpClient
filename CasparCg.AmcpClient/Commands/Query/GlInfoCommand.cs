//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Response;

namespace CasparCg.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get information about the allocated and pooled OpenGL resources.
    /// </summary>
    public class GlInfoCommand : AbstractBaseCommand<GlInfoCommandResponse>
    {
        // GL INFO

        internal override string CommandName { get; } = "GL INFO";
    }
}
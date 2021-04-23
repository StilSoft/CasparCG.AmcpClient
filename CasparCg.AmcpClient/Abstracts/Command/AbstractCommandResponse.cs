//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


namespace CasparCg.AmcpClient.Abstracts.Command
{
    public abstract class AbstractCommandResponse<TResponseInputData>
    {
        internal abstract void ProcessData(TResponseInputData data);
    }
}
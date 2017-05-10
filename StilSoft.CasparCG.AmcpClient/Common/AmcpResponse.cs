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
using StilSoft.CasparCG.AmcpClient.Common.Exceptions;
using System;
using System.ComponentModel;
using System.Reflection;

namespace StilSoft.CasparCG.AmcpClient.Common
{
    public class AmcpResponse : AbstractCommandResponse<AmcpParsedData>
    {
        internal override void ProcessData(AmcpParsedData data)
        {
            CheckResponse(data);
        }

        private void CheckResponse(AmcpParsedData data)
        {
            switch (data.Code)
            {
                case AmcpReturnCode.Info:
                case AmcpReturnCode.InfoData:
                case AmcpReturnCode.OkMultiData:
                case AmcpReturnCode.OkData:
                case AmcpReturnCode.Ok:
                    break;

                case AmcpReturnCode.CommandUnknownData:
                case AmcpReturnCode.InvalidChannel:
                case AmcpReturnCode.ParameterMissing:
                case AmcpReturnCode.ParameterIllegal:
                case AmcpReturnCode.MediaFileNotFound:
                case AmcpReturnCode.InternalServerErrorData:
                case AmcpReturnCode.InternalServerError:
                case AmcpReturnCode.MediaFileUnreadible:
                case AmcpReturnCode.AccessError:
                case AmcpReturnCode.Unknown:
                    var serverMessage = "";

                    if (data.Data.Count > 1)
                        serverMessage = $": {data.Data[1]}";

                    throw new GeneralServerException($"{GetReturnCodeDescription(data.Code)}{serverMessage}.");

                default:
                    throw new ArgumentOutOfRangeException(nameof(data.Code), data.Code.ToString(), "Invalid return code");
            }
        }

        private string GetReturnCodeDescription(AmcpReturnCode returnCode)
        {
            var description = returnCode.ToString();
            var fieldInfo = returnCode.GetType().GetField(description);

            if (fieldInfo != null)
            {
                var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

                if (descriptionAttribute != null)
                    description = descriptionAttribute.Description;
            }

            return description;
        }
    }
}
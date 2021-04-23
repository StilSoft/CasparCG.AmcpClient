//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.ComponentModel;

namespace CasparCg.AmcpClient.Common
{
    public enum AmcpReturnCode
    {
        // General error
        [Description("Unknown error")]
        Unknown = 0,                    // Unknown code, unknown error or no response (default return code)

        // Information
        Info = 100,                     // 100 [action] - Information about an event.
        InfoData = 101,                 // 101 [action] - Information about an event. A line of data is being returned.

        // Successful
        OkMultiData = 200,              // 200 [command] OK - The command has been executed and several lines of data (seperated by \r\n) are being returned (terminated with an additional \r\n) 
        OkData = 201,                   // 201 [command] OK - The command has been executed and data (terminated by \r\n) is being returned.
        Ok = 202,                       // 202 [command] OK - The command has been executed.

        // Client Error
        [Description("Unknown command")]
        CommandUnknownData = 400,       // 400 ERROR - Command not understood and data (terminated by \r\n) is being returned.
        [Description("Invalid channel number")]
        InvalidChannel = 401,           // 401 [command] ERROR - Illegal video_channel
        [Description("Missing command parameter")]
        ParameterMissing = 402,         // 402 [command] ERROR - Parameter missing
        [Description("Invalid command parameter")]
        ParameterIllegal = 403,         // 403 [command] ERROR - Illegal parameter
        [Description("File not found")]
        MediaFileNotFound = 404,        // 404 [command] ERROR - Media file not found

        // Server Error
        [Description("Internal server error")]
        InternalServerErrorData = 500,  // 500 FAILED - Internal server error
        [Description("Internal server error")]
        InternalServerError = 501,      // 501 [command] FAILED - Internal server error
        [Description("File unreadable")]
        MediaFileUnreadible = 502,      // 502 [command] FAILED - Media file unreadable
        [Description("Access error")]
        AccessError = 503               // 503 [command] FAILED - Access error
    }
}
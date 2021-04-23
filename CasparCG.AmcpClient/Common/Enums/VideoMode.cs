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
using System.Xml.Serialization;

namespace CasparCg.AmcpClient.Common.Enums
{
    public enum VideoMode
    {
        [XmlEnum("PAL")]
        [Description("PAL")]
        ModePal,

        [XmlEnum("NTSC")]
        [Description("NTSC")]
        ModeNtsc,

        [XmlEnum("576p2500")]
        [Description("576p2500")]
        Mode576P2500,

        [XmlEnum("720p2398")]
        [Description("720p2398")]
        Mode720P2398,

        [XmlEnum("720p2400")]
        [Description("720p2400")]
        Mode720P2400,

        [XmlEnum("720p2500")]
        [Description("720p2500")]
        Mode720P2500,

        [XmlEnum("720p2997")]
        [Description("720p2997")]
        Mode720P2997,

        [XmlEnum("720p3000")]
        [Description("720p3000")]
        Mode720P3000,

        [XmlEnum("720p5000")]
        [Description("720p5000")]
        Mode720P5000,

        [XmlEnum("720p5994")]
        [Description("720p5994")]
        Mode720P5994,

        [XmlEnum("720p6000")]
        [Description("720p6000")]
        Mode720P6000,

        [XmlEnum("1080p2398")]
        [Description("1080p2398")]
        Mode1080P2398,

        [XmlEnum("1080p2400")]
        [Description("1080p2400")]
        Mode1080P2400,

        [XmlEnum("1080p2500")]
        [Description("1080p2500")]
        Mode1080P2500,

        [XmlEnum("1080p2997")]
        [Description("1080p2997")]
        Mode1080P2997,

        [XmlEnum("1080p3000")]
        [Description("1080p3000")]
        Mode1080P3000,

        [XmlEnum("1080p5000")]
        [Description("1080p5000")]
        Mode1080P5000,

        [XmlEnum("1080p5994")]
        [Description("1080p5994")]
        Mode1080P5994,

        [XmlEnum("1080p6000")]
        [Description("1080p6000")]
        Mode1080P6000,

        [XmlEnum("1080i5000")]
        [Description("1080i5000")]
        Mode1080I5000,

        [XmlEnum("1080i5994")]
        [Description("1080i5994")]
        Mode1080I5994,

        [XmlEnum("1080i6000")]
        [Description("1080i6000")]
        Mode1080I6000,

        [XmlEnum("1556p2398")]
        [Description("1556p2398")]
        Mode1556P2398,

        [XmlEnum("1556p2400")]
        [Description("1556p2400")]
        Mode1556P2400,

        [XmlEnum("1556p2500")]
        [Description("1556p2500")]
        Mode1556P2500,

        [XmlEnum("dci1080p2398")]
        [Description("dci1080p2398")]
        ModeDci1080P2398,

        [XmlEnum("dci1080p2400")]
        [Description("dci1080p2400")]
        ModeDci1080P2400,

        [XmlEnum("dci1080p2500")]
        [Description("dci1080p2500")]
        ModeDci1080P2500,

        [XmlEnum("2160p2398")]
        [Description("2160p2398")]
        Mode2160P2398,

        [XmlEnum("2160p2400")]
        [Description("2160p2400")]
        Mode2160P2400,

        [XmlEnum("2160p2500")]
        [Description("2160p2500")]
        Mode2160P2500,

        [XmlEnum("2160p2997")]
        [Description("2160p2997")]
        Mode2160P2997,

        [XmlEnum("2160p3000")]
        [Description("2160p3000")]
        Mode2160P3000,

        [XmlEnum("2160p5000")]
        [Description("2160p5000")]
        Mode2160P5000,

        [XmlEnum("2160p5994")]
        [Description("2160p5994")]
        Mode2160P5994,

        [XmlEnum("2160p6000")]
        [Description("2160p6000")]
        Mode2160P6000,

        [XmlEnum("dci2160p2398")]
        [Description("dci2160p2398")]
        ModeDci2160P2398,

        [XmlEnum("dci2160p2400")]
        [Description("dci2160p2400")]
        ModeDci2160P2400,

        [XmlEnum("dci2160p2500")]
        [Description("dci2160p2500")]
        ModeDci2160P2500
    }
}
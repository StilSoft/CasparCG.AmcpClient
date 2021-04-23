//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.ComponentModel.DataAnnotations;
using CasparCg.AmcpClient.CommandBuilder.Attributes;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Conditions;
using CasparCg.AmcpClient.Common.Enums;

namespace CasparCg.AmcpClient.Commands.Basic.Common
{
    [CommandBuilderObject]
    public class Transition
    {
        // [transition:CUT,MIX,PUSH,WIPE,SLIDE] 
        // [duration:int] 
        // {
        //     [tween:string]
        //     |linear
        // }
        // {
        //     [direction:LEFT,RIGHT]
        //     |RIGHT
        // }
        // |CUT 0

        /// <summary>
        /// Transition type <see cref="Common.TransitionType"/>.
        /// </summary>
        [Required]
        [EnumDataType(typeof(TransitionType))]
        [IncludeIfIncluded(nameof(Duration))]
        [CommandParameter]
        public TransitionType? TransitionType { get; set; }

        /// <summary>
        /// Transition duration.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        [IncludeIfNotEqual(nameof(Duration), 0)]
        [CommandParameter]
        public int? Duration { get; set; }

        /// <summary>
        /// Transition tween.
        /// </summary>
        [EnumDataType(typeof(Tween))]
        [IncludeIfIncluded(nameof(Duration))]
        [IncludeIfNotEqual(nameof(TransitionType), Common.TransitionType.Cut)]
        [IncludeIfNotEqual(nameof(Tween), AmcpClient.Common.Enums.Tween.Linear)]
        [CommandParameter]
        public Tween? Tween { get; set; }

        /// <summary>
        /// Transition duration.
        /// </summary>
        [EnumDataType(typeof(Direction))]
        [IncludeIfIncluded(nameof(Duration))]
        [IncludeIfNotEqual(nameof(TransitionType), Common.TransitionType.Cut)]
        [IncludeIfNotEqual(nameof(TransitionType), Common.TransitionType.Mix)]
        [IncludeIfNotEqual(nameof(Direction), Common.Direction.Right)]
        [CommandParameter]
        public Direction? Direction { get; set; }


        public Transition(TransitionType? transitionType = null, int? duration = null, Tween? tween = null, Direction? direction = null)
        {
            TransitionType = transitionType;
            Duration = duration;
            Tween = tween;
            Direction = direction;
        }
    }
}
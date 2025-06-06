/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2024.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

namespace Leap.InputModule
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILeapWidget
    {
        /// <summary>
        /// 
        /// </summary>
        void Expand();

        /// <summary>
        /// 
        /// </summary>
        void Retract();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        void HoverDistance(float distance);
    }
}
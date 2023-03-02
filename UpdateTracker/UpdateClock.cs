using Cinemachine;
using System;

namespace UpdateTracker
{
    internal class UpdateClock
    {
        public static UpdateClock Late { get; internal set; }
        public static object Fixed { get; internal set; }

        public static explicit operator UpdateClock(CinemachineCore.UpdateFilter v)
        {
            throw new NotImplementedException();
        }
    }
}
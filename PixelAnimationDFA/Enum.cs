using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelAnimationDFA
{
    public enum State
    {
        Idle,
        RunningLeft,
        RunningRight,
        RollingRight
    }

    public enum Input
    {
        PressA,
        ReleaseA,
        PressD,
        ReleaseD,
        PressSpace,
        RollComplete
    }
}

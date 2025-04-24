using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelAnimationDFA
{
    public enum State
    {
        IdleRight,
        IdleLeft,
        RunningRight,
        RunningLeft,
        RollingRight,
        RollingLeft,
        CrouchRight,
        CrouchLeft,
        CrouchWalkRight,
        CrouchWalkLeft,
        AttackRight,
        AttackLeft
    }

    public enum Input
    {
        PressA,
        ReleaseA,
        PressD,
        ReleaseD,
        PressC,
        PressV,
        PressSpace,
        AnimationComplete
    }
}

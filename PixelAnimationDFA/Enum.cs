using System;

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
        PressZ,
        PressV,
        PressSpace,
        AnimationComplete
    }
}

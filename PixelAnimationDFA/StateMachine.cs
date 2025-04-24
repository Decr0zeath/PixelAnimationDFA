using System;
using System.Collections.Generic;
using static System.Windows.Forms.AxHost;

namespace PixelAnimationDFA
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<(State, Input), State> transitionTable;
        private readonly Action<State> onStateChanged;

        public State CurrentState { get; private set; }

        public StateMachine(Action<State> onStateChangedCallback)
        {
            CurrentState = State.IdleRight;
            onStateChanged = onStateChangedCallback;

            transitionTable = new Dictionary<(State, Input), State>
            {
                //------------------------- IDLE RIGHT STATE --------------------------------
                {(State.IdleRight, Input.PressA), State.RunningLeft},
                {(State.IdleRight, Input.PressD), State.RunningRight},
                {(State.IdleRight, Input.PressC), State.CrouchRight},
                {(State.IdleRight, Input.PressV), State.AttackRight},
                {(State.IdleRight, Input.PressSpace), State.RollingRight},
                //------------------------- IDLE LEFT STATE ---------------------------------
                {(State.IdleLeft, Input.PressA), State.RunningLeft},
                {(State.IdleLeft, Input.PressD), State.RunningRight},
                {(State.IdleLeft, Input.PressC), State.CrouchLeft},
                {(State.IdleLeft, Input.PressV), State.AttackLeft},
                {(State.IdleLeft, Input.PressSpace), State.RollingLeft},
                //------------------------- RUNNING RIGHT STATE -----------------------------
                {(State.RunningRight, Input.PressA), State.RunningRight},
                {(State.RunningRight, Input.ReleaseA), State.IdleRight},
                {(State.RunningRight, Input.ReleaseD), State.IdleRight},
                {(State.RunningRight, Input.PressC), State.CrouchRight},
                {(State.RunningRight, Input.PressV), State.AttackRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                //------------------------- RUNNING LEFT STATE ------------------------------
                {(State.RunningLeft, Input.ReleaseA), State.IdleLeft},
                {(State.RunningLeft, Input.PressD), State.RunningRight},
                {(State.RunningLeft, Input.ReleaseD), State.IdleRight},
                {(State.RunningLeft, Input.PressC), State.CrouchLeft},
                {(State.RunningLeft, Input.PressV), State.AttackLeft},
                {(State.RunningLeft, Input.PressSpace), State.RollingLeft},
                //------------------------- ROLLING RIGHT STATE -----------------------------
                {(State.RollingRight, Input.AnimationComplete), State.IdleRight},
                //------------------------- ROLLING LEFT STATE ------------------------------
                {(State.RollingLeft, Input.AnimationComplete), State.IdleLeft},
                //------------------------- CROUCH RIGHT STATE ------------------------------
                {(State.CrouchRight, Input.PressA), State.CrouchWalkLeft},
                {(State.CrouchRight, Input.ReleaseA), State.CrouchLeft},
                {(State.CrouchRight, Input.PressD), State.CrouchWalkRight},
                {(State.CrouchRight, Input.ReleaseD), State.CrouchRight},
                {(State.CrouchRight, Input.PressZ), State.IdleRight},
                {(State.CrouchRight, Input.PressV), State.AttackRight},
                {(State.CrouchRight, Input.PressSpace), State.RollingRight},
                //------------------------- CROUCH LEFT STATE -------------------------------
                {(State.CrouchLeft, Input.PressA), State.CrouchWalkLeft},
                {(State.CrouchLeft, Input.ReleaseA), State.CrouchLeft},
                {(State.CrouchLeft, Input.PressD), State.CrouchWalkRight},
                {(State.CrouchLeft, Input.ReleaseD), State.CrouchRight},
                {(State.CrouchLeft, Input.PressZ), State.IdleLeft},
                {(State.CrouchLeft, Input.PressV), State.AttackLeft},
                {(State.CrouchLeft, Input.PressSpace), State.RollingLeft},
                //------------------------- CROUCH WALK RIGHT STATE -------------------------
                {(State.CrouchWalkRight, Input.ReleaseD), State.CrouchRight},
                {(State.CrouchWalkRight, Input.PressZ), State.IdleRight},
                {(State.CrouchWalkRight, Input.PressV), State.AttackRight},
                {(State.CrouchWalkRight, Input.PressSpace), State.RollingRight},
                //------------------------- CROUCH WALK LEFT STATE --------------------------
                {(State.CrouchWalkLeft, Input.ReleaseA), State.CrouchLeft},
                {(State.CrouchWalkLeft, Input.PressZ), State.IdleLeft},
                {(State.CrouchWalkLeft, Input.PressV), State.AttackLeft},
                {(State.CrouchWalkLeft, Input.PressSpace), State.RollingLeft},
                //------------------------- ATTACK RIGHT STATE ------------------------------
                {(State.AttackRight, Input.AnimationComplete), State.IdleRight},
                //------------------------- ATTACK LEFT STATE -------------------------------
                {(State.AttackLeft, Input.AnimationComplete), State.IdleLeft}
            };
        }

        public void ApplyInput(Input input)
        {
            if (transitionTable.TryGetValue((CurrentState, input), out State nextState))
            {
                CurrentState = nextState;
                onStateChanged?.Invoke(nextState);
            }
        }
    }
}


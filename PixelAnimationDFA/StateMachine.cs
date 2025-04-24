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
                {(State.IdleRight, Input.PressA), State.RunningLeft},
                //{(State.IdleRight, Input.ReleaseA), State.IdleLeft},
                {(State.IdleRight, Input.PressD), State.RunningRight},
                //{(State.IdleRight, Input.ReleaseD), State.IdleRight},
                {(State.IdleRight, Input.PressC), State.CrouchLeft},
                {(State.IdleRight, Input.PressV), State.AttackRight},
                {(State.IdleRight, Input.PressSpace), State.RollingRight},
                //{(State.IdleRight, Input.RollComplete), State.IdleRight},

              
                {(State.IdleLeft, Input.PressA), State.RunningLeft},
                //{(State.IdleLeft, Input.ReleaseA), State.IdleLeft},
                {(State.IdleLeft, Input.PressD), State.RunningRight},
                //{(State.IdleLeft, Input.ReleaseD), State.IdleRight},
                {(State.IdleLeft, Input.PressC), State.CrouchLeft},
                {(State.IdleLeft, Input.PressV), State.AttackLeft},
                {(State.IdleLeft, Input.PressSpace), State.RollingLeft},
                //{(State.IdleLeft, Input.RollComplete), State.IdleLeft},

                                //PressA,
                //ReleaseA,
                //PressD,
                //ReleaseD,
                //PressC,
                //PressV,
                //PressSpace,
                //RollComplete

                {(State.RunningLeft, Input.PressA), State.RunningLeft},
                {(State.RunningLeft, Input.ReleaseA), State.IdleLeft},
                {(State.RunningLeft, Input.PressD), State.RunningRight},
                {(State.RunningLeft, Input.ReleaseD), State.IdleRight},
                {(State.RunningLeft, Input.PressC), State.CrouchLeft},
                {(State.RunningLeft, Input.PressV), State.AttackLeft},
                {(State.RunningLeft, Input.PressSpace), State.RollingLeft},
                {(State.RunningLeft, Input.RollComplete), State.IdleLeft},



                {(State.RunningRight, Input.ReleaseD), State.IdleRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},

                {(State.RollingRight, Input.RollComplete), State.IdleRight}
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


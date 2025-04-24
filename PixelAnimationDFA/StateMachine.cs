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
            CurrentState = State.Idle;
            onStateChanged = onStateChangedCallback;

            transitionTable = new Dictionary<(State, Input), State>
            {
                {(State.Idle, Input.PressA), State.RunningLeft},
                {(State.Idle, Input.PressD), State.RunningRight},
                {(State.Idle, Input.PressSpace), State.RollingRight},
                {(State.RunningLeft, Input.ReleaseA), State.Idle},
                {(State.RunningRight, Input.ReleaseD), State.Idle},
                {(State.RunningLeft, Input.PressSpace), State.RollingRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
                {(State.RollingRight, Input.RollComplete), State.Idle}
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


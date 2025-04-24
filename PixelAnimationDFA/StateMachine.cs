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
                //------------------------- IDLE RIGHT STATE -------------------------
                {(State.IdleRight, Input.PressA), State.RunningLeft},
                //{(State.IdleRight, Input.ReleaseA), State.IdleLeft},
                {(State.IdleRight, Input.PressD), State.RunningRight},
                //{(State.IdleRight, Input.ReleaseD), State.IdleRight},
                {(State.IdleRight, Input.PressC), State.CrouchRight},
                //{(State.IdleRight, Input.PressZ), State.CrouchRight},
                {(State.IdleRight, Input.PressV), State.AttackRight},
                {(State.IdleRight, Input.PressSpace), State.RollingRight},
                //{(State.IdleRight, Input.RollComplete), State.IdleRight},

                //------------------------- IDLE LEFT STATE -------------------------
                {(State.IdleLeft, Input.PressA), State.RunningLeft},
                //{(State.IdleLeft, Input.ReleaseA), State.IdleLeft},
                {(State.IdleLeft, Input.PressD), State.RunningRight},
                //{(State.IdleLeft, Input.ReleaseD), State.IdleRight},
                {(State.IdleLeft, Input.PressC), State.CrouchLeft},
                //{(State.IdleLeft, Input.PressZ), State.CrouchLeft},
                {(State.IdleLeft, Input.PressV), State.AttackLeft},
                {(State.IdleLeft, Input.PressSpace), State.RollingLeft},
                //{(State.IdleLeft, Input.RollComplete), State.IdleLeft},
            
                //------------------------- RUNNING RIGHT STATE -------------------------
                {(State.RunningRight, Input.PressA), State.RunningRight},
                {(State.RunningRight, Input.ReleaseA), State.IdleRight},
               // {(State.RunningRight, Input.PressD), State.RunningRight},
                {(State.RunningRight, Input.ReleaseD), State.IdleRight},
                {(State.RunningRight, Input.PressC), State.CrouchRight},
                //{(State.RunningRight, Input.PressZ), State.CrouchRight},
                {(State.RunningRight, Input.PressV), State.AttackRight},
                {(State.RunningRight, Input.PressSpace), State.RollingRight},
               // {(State.RunningRight, Input.AnimationComplete), State.IdleRight},
            
                //------------------------- RUNNING LEFT STATE -------------------------
                //{(State.RunningLeft, Input.PressA), State.RunningLeft},
                {(State.RunningLeft, Input.ReleaseA), State.IdleLeft},
                {(State.RunningLeft, Input.PressD), State.RunningRight},
                {(State.RunningLeft, Input.ReleaseD), State.IdleRight},
                {(State.RunningLeft, Input.PressC), State.CrouchLeft},
                //{(State.RunningLeft, Input.PressZ), State.CrouchLeft},
                {(State.RunningLeft, Input.PressV), State.AttackLeft},
                {(State.RunningLeft, Input.PressSpace), State.RollingLeft},
               // {(State.RunningLeft, Input.AnimationComplete), State.IdleLeft},
            
                //------------------------- ROLLING RIGHT STATE -------------------------
                //{(State.RollingRight, Input.PressA), State.IdleRight},
                //{(State.RollingRight, Input.ReleaseA), State.IdleRight},
                //{(State.RollingRight, Input.PressD), State.IdleRight},
                //{(State.RollingRight, Input.ReleaseD), State.IdleRight},
                //{(State.RollingRight, Input.PressC), State.IdleRight},
                //{(State.RollingRight, Input.PressV), State.IdleRight},
                //{(State.RollingRight, Input.PressSpace), State.IdleRight},
                {(State.RollingRight, Input.AnimationComplete), State.IdleRight},

                //------------------------- ROLLING LEFT STATE -------------------------
                //{(State.RollingLeft, Input.PressA), State.IdleRight},
                //{(State.RollingLeft, Input.ReleaseA), State.IdleRight},
                //{(State.RollingLeft, Input.PressD), State.IdleRight},
                //{(State.RollingLeft, Input.ReleaseD), State.IdleRight},
                //{(State.RollingLeft, Input.PressC), State.IdleRight},
                //{(State.RollingLeft, Input.PressV), State.IdleRight},
                //{(State.RollingLeft, Input.PressSpace), State.IdleRight},
                {(State.RollingLeft, Input.AnimationComplete), State.IdleLeft},

                //------------------------- CROUCH RIGHT STATE -------------------------
                {(State.CrouchRight, Input.PressA), State.CrouchWalkLeft},
                {(State.CrouchRight, Input.ReleaseA), State.CrouchLeft},
                {(State.CrouchRight, Input.PressD), State.CrouchWalkRight},
                {(State.CrouchRight, Input.ReleaseD), State.CrouchRight},
                //{(State.CrouchRight, Input.PressC), State.IdleRight},
                {(State.CrouchRight, Input.PressZ), State.IdleRight},
                {(State.CrouchRight, Input.PressV), State.AttackRight},
                {(State.CrouchRight, Input.PressSpace), State.RollingRight},
               //- {(State.CrouchRight, Input.AnimationComplete), State.CrouchRight},
            
                //------------------------- CROUCH LEFT STATE -------------------------
                {(State.CrouchLeft, Input.PressA), State.CrouchWalkLeft},
                {(State.CrouchLeft, Input.ReleaseA), State.CrouchLeft},
                {(State.CrouchLeft, Input.PressD), State.CrouchWalkRight},
                {(State.CrouchLeft, Input.ReleaseD), State.CrouchRight},
           //     {(State.CrouchLeft, Input.PressC), State.IdleLeft},
                {(State.CrouchLeft, Input.PressZ), State.IdleLeft},
                {(State.CrouchLeft, Input.PressV), State.AttackLeft},
                {(State.CrouchLeft, Input.PressSpace), State.RollingLeft},
                //-{(State.CrouchLeft, Input.AnimationComplete), State.IdleRight},

                //------------------------- CROUCH WALK RIGHT STATE -------------------------
                //{(State.CrouchWalkRight, Input.PressA), State.IdleRight},
                //{(State.CrouchWalkRight, Input.ReleaseA), State.CrouchLeft},
                //{(State.CrouchWalkRight, Input.PressD), State.IdleRight},
                {(State.CrouchWalkRight, Input.ReleaseD), State.CrouchRight},
                //{(State.CrouchWalkRight, Input.PressC), State.IdleRight},
                {(State.CrouchWalkRight, Input.PressZ), State.IdleRight},
                {(State.CrouchWalkRight, Input.PressV), State.AttackRight},
                {(State.CrouchWalkRight, Input.PressSpace), State.RollingRight},
                //{(State.CrouchWalkRight, Input.AnimationComplete), State.IdleRight},

                //------------------------- CROUCH WALK LEFT STATE -------------------------
                //{(State.CrouchWalkLeft, Input.PressA), State.IdleRight},
                {(State.CrouchWalkLeft, Input.ReleaseA), State.CrouchLeft},
                //{(State.CrouchWalkLeft, Input.PressD), State.IdleRight},
                //{(State.CrouchWalkLeft, Input.ReleaseD), State.IdleRight},
                //{(State.CrouchWalkLeft, Input.PressC), State.IdleRight},
                {(State.CrouchWalkLeft, Input.PressZ), State.IdleLeft},
                {(State.CrouchWalkLeft, Input.PressV), State.AttackLeft},
                {(State.CrouchWalkLeft, Input.PressSpace), State.RollingLeft},
                //{(State.CrouchWalkLeft, Input.AnimationComplete), State.IdleRight},
                
                //------------------------- ATTACK RIGHT STATE -------------------------
 //               {(State.AttackRight, Input.PressA), State.IdleRight},
 //               {(State.AttackRight, Input.ReleaseA), State.IdleRight},
 //               {(State.AttackRight, Input.PressD), State.IdleRight},
 //               {(State.AttackRight, Input.ReleaseD), State.IdleRight},
 //               {(State.AttackRight, Input.PressC), State.IdleRight},
 //               {(State.AttackRight, Input.PressV), State.IdleRight},
 //               {(State.AttackRight, Input.PressSpace), State.IdleRight},
                {(State.AttackRight, Input.AnimationComplete), State.IdleRight},
                
                //------------------------- ATTACK LEFT STATE -------------------------
 //               {(State.AttackLeft, Input.PressA), State.IdleRight},
 //               {(State.AttackLeft, Input.ReleaseA), State.IdleRight},
 //               {(State.AttackLeft, Input.PressD), State.IdleRight},
 //               {(State.AttackLeft, Input.ReleaseD), State.IdleRight},
 //               {(State.AttackLeft, Input.PressC), State.IdleRight},
 //               {(State.AttackLeft, Input.PressV), State.IdleRight},
 //               {(State.AttackLeft, Input.PressSpace), State.IdleRight},
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


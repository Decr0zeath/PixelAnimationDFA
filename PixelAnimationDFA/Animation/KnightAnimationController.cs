using System;
using System.Windows.Forms;

namespace PixelAnimationDFA
{
    public class KnightAnimationController : IAnimationController
    {
        private readonly AnimateKnight animateKnight;
        private readonly PictureBox knightPictureBox;
        private readonly IStateMachine stateMachine;

        public KnightAnimationController(PictureBox knightPictureBox, IStateMachine stateMachine)
        {
            this.animateKnight = new AnimateKnight();
            this.knightPictureBox = knightPictureBox;
            this.stateMachine = stateMachine;
        }

        public void PlayAnimation(State state)
        {
            switch (state)
            {
                case State.IdleRight: animateKnight.IdleRight(knightPictureBox); break;
                case State.IdleLeft: animateKnight.IdleLeft(knightPictureBox); break;
                case State.RunningRight: animateKnight.RunningRight(knightPictureBox); break;
                case State.RunningLeft: animateKnight.RunningLeft(knightPictureBox); break;
                case State.CrouchRight: animateKnight.CrouchRight(knightPictureBox); break;
                case State.CrouchLeft: animateKnight.CrouchLeft(knightPictureBox); break;
                case State.CrouchWalkRight: animateKnight.CrouchWalkRight(knightPictureBox); break;
                case State.CrouchWalkLeft: animateKnight.CrouchWalkLeft(knightPictureBox); break;

                case State.RollingRight:
                    animateKnight.RollingRight(knightPictureBox, () => stateMachine.ApplyInput(Input.AnimationComplete));
                    break;

                case State.RollingLeft:
                    animateKnight.RollingLeft(knightPictureBox, () => stateMachine.ApplyInput(Input.AnimationComplete));
                    break;

                case State.AttackRight:
                    animateKnight.AttackRight(knightPictureBox, () => stateMachine.ApplyInput(Input.AnimationComplete));
                    break;

                case State.AttackLeft:
                    animateKnight.AttackLeft(knightPictureBox, () => stateMachine.ApplyInput(Input.AnimationComplete));
                    break;
            }
        }
    }
}

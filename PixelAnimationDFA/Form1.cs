using System;
using System.Drawing;
using System.Windows.Forms;

namespace PixelAnimationDFA
{
    public partial class Form1 : Form
    {
        private AnimateKnight animateKnight;
        private IStateMachine stateMachine;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            animateKnight = new AnimateKnight();
            stateMachine = new StateMachine(ApplyAnimationForState);

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }

        private void ApplyAnimationForState(State state)
        {
            switch (state)
            {
                case State.Idle:
                    animateKnight.IdleAnimation(pictureBoxKnight);
                    break;
                case State.RunningLeft:
                    animateKnight.RunToLeft(pictureBoxKnight);
                    break;
                case State.RunningRight:
                    animateKnight.RunToRight(pictureBoxKnight);
                    break;
                case State.RollingRight:
                    animateKnight.RollingToRight(pictureBoxKnight, () =>
                    {
                        stateMachine.ApplyInput(Input.RollComplete);
                    });
                    break;
                case State.RollingLeft;
                    break;
                case 
            }
        }

        //bool isRunningLeft = false;
        //bool isRunningRight = false;
        //bool isRolling = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X) Application.Exit();

            if (e.KeyCode == Keys.A) stateMachine.ApplyInput(Input.PressA);
            if (e.KeyCode == Keys.D) stateMachine.ApplyInput(Input.PressD);
            if (e.KeyCode == Keys.Space) stateMachine.ApplyInput(Input.PressSpace);
        }

        //private void OnRollCompleted()
        //{
        //    isRolling = false;
        //    animateKnight.IdleAnimation(pictureBoxKnight);
        //}


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) stateMachine.ApplyInput(Input.ReleaseA);
            if (e.KeyCode == Keys.D) stateMachine.ApplyInput(Input.ReleaseD);
        }

        // Animation frame update method
        private void OnFrameChanged(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                ImageAnimator.UpdateFrames(pictureBoxKnight.Image);
                pictureBoxKnight.Invalidate(); // Forces the PictureBox to repaint
            }));
        }


    }
}

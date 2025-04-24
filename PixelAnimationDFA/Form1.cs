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
                case State.IdleRight:
                    animateKnight.IdleRight(pictureBoxKnight);
                    break;
                
                case State.IdleLeft:
                    animateKnight.IdleLeft(pictureBoxKnight);
                    break;

                case State.RunningRight:
                    animateKnight.RunningRight(pictureBoxKnight);
                    break;

                case State.RunningLeft:
                    animateKnight.RunningLeft(pictureBoxKnight);
                    break;

                case State.RollingRight:

                    labelInput.Text = "Input: AnimationComplete";

                    animateKnight.RollingRight(pictureBoxKnight, () =>
                    {
                        stateMachine.ApplyInput(Input.AnimationComplete);
                    });
                    break;

                case State.RollingLeft:

                    labelInput.Text = "Input: AnimationComplete";

                    animateKnight.RollingLeft(pictureBoxKnight, () =>
                    {
                        stateMachine.ApplyInput(Input.AnimationComplete);
                    });

                    break;

                case State.CrouchRight:
                    animateKnight.CrouchRight(pictureBoxKnight);
                    break;

                case State.CrouchLeft:
                    animateKnight.CrouchLeft(pictureBoxKnight);
                    break;

                case State.CrouchWalkRight:
                    animateKnight.CrouchWalkRight(pictureBoxKnight);
                    break;

                case State.CrouchWalkLeft:
                    animateKnight.CrouchWalkLeft(pictureBoxKnight);
                    break;

                case State.AttackRight:
                    animateKnight.AttackRight(pictureBoxKnight, () =>
                    {
                        stateMachine.ApplyInput(Input.AnimationComplete);
                    });
                    break;

                case State.AttackLeft:
                    animateKnight.AttackLeft(pictureBoxKnight, () =>
                    {
                        stateMachine.ApplyInput(Input.AnimationComplete);
                    });
                    break;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X) Application.Exit();

            if (e.KeyCode == Keys.A)
            {
                labelInput.Text = "Input: Press A";
                stateMachine.ApplyInput(Input.PressA);
            }

            if (e.KeyCode == Keys.D)
            {   
                labelInput.Text = "Input: Press D";
                stateMachine.ApplyInput(Input.PressD);
            }

            if (e.KeyCode == Keys.C) 
            {
                labelInput.Text = "Input: Press C";
                stateMachine.ApplyInput(Input.PressC); 
            }

            if (e.KeyCode == Keys.Z)
            {
                labelInput.Text = "Input: Press Z";
                stateMachine.ApplyInput(Input.PressZ);
            }

            if (e.KeyCode == Keys.V)
            {   
                labelInput.Text = "Input: Press V";
                stateMachine.ApplyInput(Input.PressV);
            }

            if (e.KeyCode == Keys.Space)
            {
                labelInput.Text = "Input: Press Space";
                stateMachine.ApplyInput(Input.PressSpace);
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {   
                labelInput.Text = "Input: Release A";
                stateMachine.ApplyInput(Input.ReleaseA);
            }

            if (e.KeyCode == Keys.D)
            {
                labelInput.Text = "Input: Release D";
                stateMachine.ApplyInput(Input.ReleaseD);
            }
        }
    }
}

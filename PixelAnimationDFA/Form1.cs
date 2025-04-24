using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace PixelAnimationDFA
{
    public partial class Form1 : Form
    {
        private readonly AnimateKnight animateKnight;
        private readonly IStateMachine stateMachine;

        private readonly Dictionary<Keys, Input> keyDownInputMap = new Dictionary<Keys, Input>
        {
            { Keys.A, Input.PressA },
            { Keys.D, Input.PressD },
            { Keys.C, Input.PressC },
            { Keys.Z, Input.PressZ },
            { Keys.V, Input.PressV },
            { Keys.Space, Input.PressSpace }
        };

        private readonly Dictionary<Keys, Input> keyUpInputMap = new Dictionary<Keys, Input>
        {
            { Keys.A, Input.ReleaseA },
            { Keys.D, Input.ReleaseD }
        };

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

            animateKnight = new AnimateKnight();
            stateMachine = new StateMachine(ApplyAnimationForState);

            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
        }

        private void ApplyAnimationForState(State state)
        {
            switch (state)
            {
                case State.IdleRight:       animateKnight.IdleRight(pictureBoxKnight);          break;
                case State.IdleLeft:        animateKnight.IdleLeft(pictureBoxKnight);           break;
                case State.RunningRight:    animateKnight.RunningRight(pictureBoxKnight);       break;
                case State.RunningLeft:     animateKnight.RunningLeft(pictureBoxKnight);        break;
                case State.CrouchRight:     animateKnight.CrouchRight(pictureBoxKnight);        break;
                case State.CrouchLeft:      animateKnight.CrouchLeft(pictureBoxKnight);         break;
                case State.CrouchWalkRight: animateKnight.CrouchWalkRight(pictureBoxKnight);    break;
                case State.CrouchWalkLeft:  animateKnight.CrouchWalkLeft(pictureBoxKnight);     break;

                case State.RollingRight:
                    animateKnight.RollingRight(pictureBoxKnight, () =>
                    {
                        stateMachine.ApplyInput(Input.AnimationComplete);
                    });
                    break;

                case State.RollingLeft:
                    animateKnight.RollingLeft(pictureBoxKnight, () =>
                    {
                        stateMachine.ApplyInput(Input.AnimationComplete);
                    });
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
            if (e.KeyCode == Keys.Escape) Application.Exit();

            if (keyDownInputMap.TryGetValue(e.KeyCode, out Input input))
            {
                labelInput.Text = $"Input: Press {e.KeyCode}";
                stateMachine.ApplyInput(input);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyUpInputMap.TryGetValue(e.KeyCode, out Input input))
            {
                labelInput.Text = $"Input: Release {e.KeyCode}";
                stateMachine.ApplyInput(input);
            }
        }
    }
}

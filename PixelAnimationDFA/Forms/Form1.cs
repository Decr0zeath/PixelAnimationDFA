using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

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

            // Get the screen size
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Set form size to 75% of screen size
            int formWidth = (int)(screenWidth * 0.75);
            int formHeight = (int)(screenHeight * 0.75);
            this.Size = new Size(formWidth, formHeight);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Repositioning and Resizing of Picture Boxes
            repositionPictureBoxKnight();

            resizePictureBoxStateDiag();
            repositionPictureBoxStateDiag();

            // Initially sets the labels to a specific text
            labelInput.Text = "Input: None";
            labelCurrState.Text = "Current State: IdleRight";
        }

        // Making the form draggable
        public const int WM_NCHITTEST = 0x84;
        public const int HTCLIENT = 0x1;
        public const int HTCAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                m.Result = (IntPtr)HTCAPTION;
            }
        }

        // Dynamically Positioning the PictureBoxKnight
        private void repositionPictureBoxKnight()
        {
            int x = (this.ClientSize.Width - pictureBoxKnight.Width) / 2;
            int y = (int)(this.ClientSize.Height * 0.6) - (pictureBoxKnight.Height / 2);

            pictureBoxKnight.Location = new Point(x, y);
        }

        // Dynamically Positioning the PictureBoxStateDiag
        private void repositionPictureBoxStateDiag()
        {
            int x = (this.ClientSize.Width - pictureBoxStateDiag.Width) / 2;
            int y = (this.ClientSize.Height - pictureBoxStateDiag.Height) / 2;

            pictureBoxStateDiag.Location = new Point(x, y);
        }

        // Dynamically Resizing the PictureBoxStateDiag
        private void resizePictureBoxStateDiag()
        {
            
            double y = (double)(this.ClientSize.Height * .9);
            double x = y * 1.5;

            pictureBoxStateDiag.Size = new Size((int)x, (int)y);
        }

        private void ApplyAnimationForState(State state)
        {
            labelCurrState.Text = $"Current State: {state}";

            switch (state)
            {
                case State.IdleRight: animateKnight.IdleRight(pictureBoxKnight); break;
                case State.IdleLeft: animateKnight.IdleLeft(pictureBoxKnight); break;
                case State.RunningRight: animateKnight.RunningRight(pictureBoxKnight); break;
                case State.RunningLeft: animateKnight.RunningLeft(pictureBoxKnight); break;
                case State.CrouchRight: animateKnight.CrouchRight(pictureBoxKnight); break;
                case State.CrouchLeft: animateKnight.CrouchLeft(pictureBoxKnight); break;
                case State.CrouchWalkRight: animateKnight.CrouchWalkRight(pictureBoxKnight); break;
                case State.CrouchWalkLeft: animateKnight.CrouchWalkLeft(pictureBoxKnight); break;

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

        bool isVisible = true;
        private void ShowHidePanels(bool visible)
        {
            panelKeyBoardLayout.Visible = visible;
            pictureBoxKnight.Visible = visible;
            pictureBoxStateDiag.Visible = !visible;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0) Application.Exit();

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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '9')
            {
                ShowHidePanels(isVisible);
                isVisible = !isVisible;
            }
        }
    }
}
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace PixelAnimationDFA
{
    public partial class Form1 : Form
    {
        private readonly IAnimationController animationController;
        private readonly IStateMachine stateMachine;
        private readonly InputHandler inputHandler;

        public Form1()
        {
            InitializeComponent();

            stateMachine = new StateMachine(OnStateChanged);
            animationController = new KnightAnimationController(pictureBoxKnight, stateMachine);
            inputHandler = new InputHandler(stateMachine, labelInput, ShowHidePanels);

            KeyPreview = true;
            KeyPress += (s, e) => inputHandler.HandleKeyPress(e);
            KeyDown += (s, e) => inputHandler.HandleKeyDown(e);
            KeyUp += (s, e) => inputHandler.HandleKeyUp(e);

            InitializeForm();
            InitializePictureBoxes();

            labelInput.Text = "Input: None";
            labelCurrState.Text = "Current State: IdleRight";
        }

        private void InitializeForm()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size((int)(screenWidth * 0.75), (int)(screenHeight * 0.75));
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializePictureBoxes()
        {
            PositionKnight();
            ResizeAndPositionStateDiagram();
        }

        private void PositionKnight()
        {
            int x = (this.ClientSize.Width - pictureBoxKnight.Width) / 2;
            int y = (int)(this.ClientSize.Height * 0.6) - (pictureBoxKnight.Height / 2);
            pictureBoxKnight.Location = new Point(x, y);
        }

        private void ResizeAndPositionStateDiagram()
        {
            double y = (double)(this.ClientSize.Height * 0.9);
            double x = y * 1.5;
            pictureBoxStateDiag.Size = new Size((int)x, (int)y);

            int centerX = (this.ClientSize.Width - pictureBoxStateDiag.Width) / 2;
            int centerY = (this.ClientSize.Height - pictureBoxStateDiag.Height) / 2;
            pictureBoxStateDiag.Location = new Point(centerX, centerY);
        }

        private void OnStateChanged(State state)
        {
            labelCurrState.Text = $"Current State: {state}";
            animationController.PlayAnimation(state);
        }

        private void ShowHidePanels(bool visible)
        {
            panelKeyBoardLayout.Visible = visible;
            pictureBoxKnight.Visible = visible;
            pictureBoxStateDiag.Visible = !visible;
        }

        // Form Draggable
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84 && (int)m.Result == 0x1)
            {
                m.Result = (IntPtr)0x2;
            }
        }
    }
}
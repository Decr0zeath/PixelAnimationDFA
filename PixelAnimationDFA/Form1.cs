using System;
using System.Drawing;
using System.Windows.Forms;

namespace PixelAnimationDFA
{
    public partial class Form1 : Form
    {
        AnimateKnight animateKnight = new AnimateKnight();

        public Form1()
        {
            this.KeyPreview = true; // So the form catches key events before controls do
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        bool isRunningLeft = false;
        bool isRunningRight = false;
        bool isRolling = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.A && !isRunningLeft)
            {
                isRunningLeft = true;
                animateKnight.RunToLeft(pictureBoxKnight);
            }
            
            if (e.KeyCode == Keys.D && !isRunningRight)
            {
                isRunningRight = true;
                animateKnight.RunToRight(pictureBoxKnight);
            }

            if(e.KeyCode == Keys.Space && !isRolling)
            {
                isRolling = true;
                animateKnight.RollingToRight(pictureBoxKnight);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                isRunningLeft = false;
                animateKnight.IdleAnimation(pictureBoxKnight);
                ImageAnimator.StopAnimate(pictureBoxKnight.Image, OnFrameChanged);
            }
            
            if (e.KeyCode == Keys.D)
            {
                isRunningRight = false;
                animateKnight.IdleAnimation(pictureBoxKnight);
                ImageAnimator.StopAnimate(pictureBoxKnight.Image, OnFrameChanged);
            }

            if (e.KeyCode == Keys.Space)
            {
                isRunningRight = false;
            //    animateKnight.IdleAnimation(pictureBoxKnight);
            //    ImageAnimator.StopAnimate(pictureBoxKnight.Image, OnFrameChanged);
            }
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

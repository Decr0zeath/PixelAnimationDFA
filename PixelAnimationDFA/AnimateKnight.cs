using System;
using System.Drawing;
using System.Windows.Forms;

namespace PixelAnimationDFA
{
    internal class AnimateKnight
    {
        public void IdleRight(PictureBox characterKnight)
        {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__IdleRight;
            //ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void IdleLeft(PictureBox characterKnight)
        {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__IdleLeft;
            //ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void CrouchRight(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchRight;
            //ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }
        public void CrouchLeft(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchLeft;
           // ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }
        public void CrouchWalkRight(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchWalkRight;
            //ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }
        public void CrouchWalkLeft(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchWalkLeft;
            //ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void RunningRight(PictureBox characterKnight)
        {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__RunRight;
            //ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void RunningLeft(PictureBox characterKnight)
        {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__RunLeft;
            //ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void RollingRight(PictureBox characterKnight, Action animationComplete)
        {
            characterKnight.Image = Properties.Resources.__RollRight;

           // ImageAnimator.Animate(rollImage, (sender, e) =>
           // {
           //     ImageAnimator.UpdateFrames(rollImage);
          //      characterKnight.Invalidate();
          //  });

            Timer timer = new Timer();
            timer.Interval = 700;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                animationComplete?.Invoke();
            };
            timer.Start();
        }

        public void RollingLeft(PictureBox characterKnight, Action animationComplete)
        {
            characterKnight.Image = Properties.Resources.__RollLeft;

            // ImageAnimator.Animate(rollImage, (sender, e) =>
            //  {
            //      ImageAnimator.UpdateFrames(rollImage);
            //       characterKnight.Invalidate();
            //  });

            Timer timer = new Timer();
            timer.Interval = 700;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                animationComplete?.Invoke();
            };
            timer.Start();
        }

        public void AttackRight(PictureBox characterKnight, Action animationComplete) 
        {
            characterKnight.Image = Properties.Resources.__AttackRight;

            Timer timer = new Timer();
            timer.Interval = 1200;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                animationComplete?.Invoke();
            };
            timer.Start();
        }
        public void AttackLeft(PictureBox characterKnight, Action animationComplete) 
        { 
            characterKnight.Image = Properties.Resources.__AttackLeft;

            Timer timer = new Timer();
            timer.Interval = 1200;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                animationComplete?.Invoke();
            };
            timer.Start();
        }











        private void OnFrameChanged(object sender, System.EventArgs e)
        {
            // Update frames
            ImageAnimator.UpdateFrames((Image)sender);
        }
    }
}

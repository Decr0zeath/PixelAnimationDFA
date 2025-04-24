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
            ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void IdleLeft(PictureBox characterKnight)
        {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__IdleLeft;
            ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void CrouchRight(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchRight;
            ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }
        public void CrouchLeft(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchLeft;
            ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }
        public void CrouchWalkRight(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchWalkRight;
            ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }
        public void CrouchWalkLeft(PictureBox characterKnight) {
            //characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__CrouchWalkLeft;
            ImageAnimator.StopAnimate(characterKnight.Image, OnFrameChanged);
        }

        public void RunningRight(PictureBox characterKnight)
        {
            //characterKnight.Image = null;
            characterKnight.Image = (Image)Properties.Resources.__RunRight.Clone();
            ImageAnimator.Animate(characterKnight.Image, OnFrameChanged);
        }

        public void RunningLeft(PictureBox characterKnight)
        {
            //characterKnight.Image = null;
            characterKnight.Image = (Image)Properties.Resources.__RunLeft.Clone();
            ImageAnimator.Animate(characterKnight.Image, OnFrameChanged);
        }

        public void RollingRight(PictureBox characterKnight, Action onRollComplete)
        {
            characterKnight.Image = null;
            Image rollImage = (Image)Properties.Resources.__RollRight.Clone(); // Assuming you have a __Roll GIF
            characterKnight.Image = rollImage;

            ImageAnimator.Animate(rollImage, (sender, e) =>
            {
                ImageAnimator.UpdateFrames(rollImage);
                characterKnight.Invalidate();
            });

            // Estimate roll duration (e.g., 600ms). Use the length of the GIF if you can measure it.
            Timer timer = new Timer();
            timer.Interval = 700; // Set this to the actual duration of your roll GIF
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                onRollComplete?.Invoke();
            };
            timer.Start();
        }

        public void RollingLeft(PictureBox characterKnight, Action onRollComplete)
        {
            characterKnight.Image = null;
            Image rollImage = (Image)Properties.Resources.__RollLeft.Clone(); // Assuming you have a __Roll GIF
            characterKnight.Image = rollImage;

            ImageAnimator.Animate(rollImage, (sender, e) =>
            {
                ImageAnimator.UpdateFrames(rollImage);
                characterKnight.Invalidate();
            });

            // Estimate roll duration (e.g., 600ms). Use the length of the GIF if you can measure it.
            Timer timer = new Timer();
            timer.Interval = 700; // Set this to the actual duration of your roll GIF
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                onRollComplete?.Invoke();
            };
            timer.Start();
        }

        public void AttackRight(PictureBox characterKnight) { }
        public void AttackLeft(PictureBox characterKnight) { }
        private void OnFrameChanged(object sender, System.EventArgs e)
        {
            // Update frames
            ImageAnimator.UpdateFrames((Image)sender);
        }
    }
}

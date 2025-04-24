using System;
using System.Drawing;
using System.Windows.Forms;

namespace PixelAnimationDFA
{
    internal class AnimateKnight
    {
        public void IdleAnimation(PictureBox characterKnight)
        {
            characterKnight.Image = null;
            characterKnight.Image = Properties.Resources.__Idle;
        }

        public void RunToRight(PictureBox characterKnight)
        {
            characterKnight.Image = null;
            characterKnight.Image = (Image)Properties.Resources.__Run.Clone();
            ImageAnimator.Animate(characterKnight.Image, OnFrameChanged);
        }

        public void RunToLeft(PictureBox characterKnight)
        {
            characterKnight.Image = null;
            characterKnight.Image = (Image)Properties.Resources.__RunMirrored.Clone();
            ImageAnimator.Animate(characterKnight.Image, OnFrameChanged);
        }

        public void RollingToRight(PictureBox characterKnight, Action onRollComplete)
        {
            characterKnight.Image = null;
            Image rollImage = (Image)Properties.Resources.__Roll.Clone(); // Assuming you have a __Roll GIF
            characterKnight.Image = rollImage;

            ImageAnimator.Animate(rollImage, (sender, e) =>
            {
                ImageAnimator.UpdateFrames(rollImage);
                characterKnight.Invalidate();
            });

            // Estimate roll duration (e.g., 600ms). Use the length of the GIF if you can measure it.
            Timer timer = new Timer();
            timer.Interval = 600; // Set this to the actual duration of your roll GIF
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                onRollComplete?.Invoke();
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

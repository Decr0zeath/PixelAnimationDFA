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

        public void RollingToRight(PictureBox characterKnight)
        {
            characterKnight.Image = null;
            characterKnight.Image = (Image)Properties.Resources.__Roll.Clone();
            ImageAnimator.Animate(characterKnight.Image, OnFrameChanged);
        }


        private void OnFrameChanged(object sender, System.EventArgs e)
        {
            // Update frames
            ImageAnimator.UpdateFrames((Image)sender);
        }
    }
}

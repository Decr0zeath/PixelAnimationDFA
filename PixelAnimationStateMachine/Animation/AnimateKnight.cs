using System;
using System.Drawing;
using System.Windows.Forms;

namespace PixelAnimationStateMachine
{
    internal class AnimateKnight
    {
        public void IdleRight(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__IdleRight;
        public void IdleLeft(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__IdleLeft;
        public void CrouchRight(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__CrouchRight;
        public void CrouchLeft(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__CrouchLeft;
        public void CrouchWalkRight(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__CrouchWalkRight;
        public void CrouchWalkLeft(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__CrouchWalkLeft;
        public void RunningRight(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__RunRight;
        public void RunningLeft(PictureBox characterKnight) => characterKnight.Image = Properties.Resources.__RunLeft;
        
        public void RollingRight(PictureBox characterKnight, Action animationComplete) 
        { 
            PlayAnimationWithDelay(characterKnight, Properties.Resources.__RollRight, 700, animationComplete); 
        }
        
        public void RollingLeft(PictureBox characterKnight, Action animationComplete) 
        { 
            PlayAnimationWithDelay(characterKnight, Properties.Resources.__RollLeft, 700, animationComplete); 
        }
        
        public void AttackRight(PictureBox characterKnight, Action animationComplete)
        { 
            PlayAnimationWithDelay(characterKnight, Properties.Resources.__AttackRight, 1200, animationComplete); 
        }
        
        public void AttackLeft(PictureBox characterKnight, Action animationComplete)  
        { 
            PlayAnimationWithDelay(characterKnight, Properties.Resources.__AttackLeft, 1200, animationComplete); 
        }

        private void PlayAnimationWithDelay(PictureBox characterKnight, Image animation, int durationMs, Action animationComplete)
        {
            characterKnight.Image = animation;

            Timer timer = new Timer();
            timer.Interval = durationMs;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                animationComplete?.Invoke();
            };
            timer.Start();
        }

    }
}
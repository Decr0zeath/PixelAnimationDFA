using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PixelAnimationDFA
{
    public class InputHandler
    {
        private readonly IStateMachine stateMachine;
        private readonly Label labelInput;
        private bool isVisible;
        private readonly Action<bool> togglePanels;

        private readonly Dictionary<Keys, Input> keyDownInputMap;
        private readonly Dictionary<Keys, Input> keyUpInputMap;

        public InputHandler(IStateMachine stateMachine, Label labelInput, Action<bool> togglePanels)
        {
            this.stateMachine = stateMachine;
            this.labelInput = labelInput;
            this.togglePanels = togglePanels;
            this.isVisible = true;

            keyDownInputMap = new Dictionary<Keys, Input>
            {
                { Keys.A, Input.PressA },
                { Keys.D, Input.PressD },
                { Keys.C, Input.PressC },
                { Keys.Z, Input.PressZ },
                { Keys.V, Input.PressV },
                { Keys.Space, Input.PressSpace }
            };

            keyUpInputMap = new Dictionary<Keys, Input>
            {
                { Keys.A, Input.ReleaseA },
                { Keys.D, Input.ReleaseD }
            };
        }

        public void HandleKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0) Application.Exit();

            if (keyDownInputMap.TryGetValue(e.KeyCode, out Input input))
            {
                labelInput.Text = $"Input: Press {e.KeyCode}";
                stateMachine.ApplyInput(input);
            }
        }

        public void HandleKeyUp(KeyEventArgs e)
        {
            if (keyUpInputMap.TryGetValue(e.KeyCode, out Input input))
            {
                labelInput.Text = $"Input: Release {e.KeyCode}";
                stateMachine.ApplyInput(input);
            }
        }

        public void HandleKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '9')
            {
                isVisible = !isVisible;
                togglePanels(isVisible);
            }
        }
    }
}

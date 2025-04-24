using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace PixelAnimationDFA
{
    public interface IStateMachine
    {
        State CurrentState { get; }
        void ApplyInput(Input input);
    }

}

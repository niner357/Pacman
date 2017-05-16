using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.KeyInput
{
    public class EventKeyInput : IKeyInput
    {
        public delegate void KeyInputEventHandler(IKeyInput sender, Keys key);
        public event KeyInputEventHandler KeyInput;

        public void OnKeyInput(Keys inputKey)
        {
            KeyInput(this, inputKey);
        }
    }
}

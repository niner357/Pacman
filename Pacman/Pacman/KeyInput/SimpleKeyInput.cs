using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.KeyInput
{
    public abstract class SimpleKeyInput : IKeyInput
    {
        public abstract void KeyInput(Keys inputKey);

        public void OnKeyInput(Keys inputKey)
        {
            KeyInput(inputKey);
        }
    }
}

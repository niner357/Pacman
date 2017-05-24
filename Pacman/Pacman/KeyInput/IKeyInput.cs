using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.KeyInput
{
    public interface IKeyInput
    {
        /// <summary>
        /// Get Activated when there is a KeyInput
        /// </summary>
        /// <param name="key">The Key which activates the KeyInput</param>
        void OnKeyInput(Keys key);
    }
}

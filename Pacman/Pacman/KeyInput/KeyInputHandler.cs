using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.KeyInput
{
    public class KeyInputHandler
    {
        /// <summary>
        /// The Form
        /// </summary>
        public Form Form { get; private set; }

        private List<IKeyInput> handlingKeyInputs;
        private Thread keyInputThread;
        private List<Keys> pressedKeys;

        private Keys pressedKey;

        private bool allowHold;
        private ThreadingMode mode;

        /// <summary>
        /// The Constructor of the KeyInputHandler
        /// </summary>
        /// <param name="form">The Form where the KeyInputHandler should handle the Keys</param>
        /// <param name="allowHold">If it's true the KeyInputHandler will allow the holding of a Key</param>
        /// <param name="mode">It's for the Delay between the Activations of the KeyInput Methods</param>
        public KeyInputHandler(Form form, bool allowHold, ThreadingMode mode)
        {
            pressedKeys = new List<Keys>();
            this.mode = mode;
            this.allowHold = allowHold;
            handlingKeyInputs = new List<IKeyInput>();
            Form = form;
            keyInputThread = new Thread(() =>
            {
                KeyHandle();
            });
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (pressedKeys.Contains(e.KeyCode))
                pressedKeys.Remove(e.KeyCode);
        }

        public void Reset()
        {
            pressedKeys.Clear();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (pressedKeys.Count > 0)
                pressedKeys.Clear();
            if (!pressedKeys.Contains(e.KeyCode))
                pressedKeys.Add(e.KeyCode);
        }

        /// <summary>
        /// Starts the KeyInputHandler
        /// </summary>
        public void Start()
        {
            keyInputThread.Start();
        }

        /// <summary>
        /// Registers a new KeyInput Listener
        /// </summary>
        /// <param name="keyInput">The new KeyInput</param>
        public void RegisterKeyInput(IKeyInput keyInput)
        {
            if (!handlingKeyInputs.Contains(keyInput))
                handlingKeyInputs.Add(keyInput);
        }

        /// <summary>
        /// Stops the KeyInputHandler
        /// </summary>
        public void Stop()
        {
            try
            {
                keyInputThread.Abort();
            }
            catch { }
        }

        private void KeyHandle()
        {
            while (true)
            {
                try
                {
                    List<Keys> keys = pressedKeys;
                    foreach (Keys key in keys)
                    {
                        foreach (IKeyInput keyInput in handlingKeyInputs)
                        {
                            keyInput.OnKeyInput(key);
                        }
                    }
                    if (!allowHold)
                        pressedKeys.Clear();
                    switch (mode)
                    {
                        case ThreadingMode.None:
                            continue;
                        case ThreadingMode.Milli1:
                            Thread.Sleep(1);
                            continue;
                        case ThreadingMode.Milli10:
                            Thread.Sleep(10);
                            continue;
                        case ThreadingMode.Milli100:
                            Thread.Sleep(100);
                            continue;
                        case ThreadingMode.Second1:
                            Thread.Sleep(1000);
                            continue;
                        case ThreadingMode.Milli500:
                            Thread.Sleep(250);
                            continue;
                    }
                }
                catch { }
            }
        }
    }
}

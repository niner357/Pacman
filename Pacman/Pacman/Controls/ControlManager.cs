using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Controls
{
    public class ControlManager
    {
        public delegate void ControlClickEventHandler(GameControl source, MouseButtons btn);
        public delegate void ControlEnterEventHandler(GameControl source);
        public delegate void ControlLeaveEventHandler(GameControl source);

        private List<GameControl> controls;
        private Panel parent;
        private Graphics bufferGraphics;
        private Bitmap bufferBitmap;
        private Graphics screenGraphics;

        private GameControl inControl;

        public event ControlClickEventHandler OnControlClick;
        public event ControlEnterEventHandler OnControlEnter;
        public event ControlLeaveEventHandler OnControlLeave;

        public ControlManager(Panel parent)
        {
            this.parent = parent;
            parent.MouseClick += Parent_MouseClick;
            parent.MouseMove += Parent_MouseMove;
            controls = new List<GameControl>();
        }

        private void Parent_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (GameControl control in controls)
            {
                if (IsInControl(control, e.Location))
                {

                    if (inControl == null)
                        inControl = control;
                    if(control.Visible)
                        control.OnEnterRender(bufferGraphics);
                    if (OnControlEnter != null)
                        OnControlEnter(control);
                    if (bufferBitmap == null)
                        continue;
                    screenGraphics.DrawImage(bufferBitmap, 0, 0);
                }
                else
                {
                    if (inControl != null)
                    {
                        if (inControl == control)
                        {
                            inControl = null;
                            if (control.Visible)
                                control.OnLeaveRender(bufferGraphics);
                            if (OnControlLeave != null)
                                OnControlLeave(control);
                            if (bufferBitmap == null)
                                continue;
                            screenGraphics.DrawImage(bufferBitmap, 0, 0);
                        }
                    }
                }
            }
        }

        public void HideControl(int id)
        {
            GameControl control = GetControl(id);
            if (control == null)
                return;
            if (!control.Visible)
                return;
            bufferGraphics.FillRectangle(new SolidBrush(parent.BackColor), control.Location.X-1, control.Location.Y-1, control.Width+1, control.Height+1);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            control.Visible = false;
        }

        public void ShowControl(int id)
        {
            GameControl control = GetControl(id);
            if (control == null)
                return;
            if (control.Visible)
                return;
            control.OnInitRender(bufferGraphics);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            control.Visible = true;
        }

        public GameControl GetControl(int id)
        {
            foreach (GameControl control in controls)
                if (control.Id == id)
                    return control;
            return null;
        }

        private void Parent_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (GameControl control in controls)
            {
                if (IsInControl(control, e.Location))
                {
                    if (OnControlClick != null)
                        OnControlClick(control, e.Button);
                    if (control.Visible)
                        control.OnActivateRender(bufferGraphics);
                    screenGraphics.DrawImage(bufferBitmap, 0, 0);
                    Thread.Sleep(200);
                    if (control.Visible)
                        control.OnInitRender(bufferGraphics);
                    screenGraphics.DrawImage(bufferBitmap, 0, 0);
                }
            }
        }

        public void AddControl(GameControl control)
        {
            if (!controls.Contains(control))
            {
                control.Visible = true;
                controls.Add(control);
            }
        }

        public void Initialize()
        {
            bufferBitmap = new Bitmap(parent.Width, parent.Height);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
            screenGraphics = parent.CreateGraphics();

            foreach (GameControl control in controls)
            {
                control.OnInitRender(bufferGraphics);
                screenGraphics.DrawImage(bufferBitmap, 0, 0);
            }
        }

        private bool IsInControl(GameControl control, Point pt)
        {
            for (int x = control.Location.X; x < (control.Location.X + control.Width); x++)
            {
                for (int y = control.Location.Y; y < (control.Location.Y + control.Height); y++)
                {
                    if (pt.X == x && pt.Y == y)
                        return true;
                }
            }
            return false;
        }
    }
}

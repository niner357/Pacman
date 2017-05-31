﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Rendering;
using System.Windows.Forms;
using Pacman.Collision;
using Pacman.Map;
using System.Threading;

namespace Pacman.Entities
{
    public class Player : IRenderable, ICollidable
    {
        public Renderer PlayerRenderer { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Energized { get; set; }
        public Collider PlayerCollider { get; private set; }

        private bool pacmanOpened;

        public Player(Control parent, Level level, int width, int height)
        {
            PlayerRenderer = new Renderer(parent, this);
            PlayerCollider = new Collider(level, this);
            this.Width = width;
            this.Height = height;
            pacmanOpened = true;
        }

        public void Spawn(int x, int y)
        {
            this.X = x;
            this.Y = y;
            PlayerRenderer.DoRender(x, y);
        }

        public void Render(Graphics g)
        {
            if (!pacmanOpened)
                OpenPacMan(g);
            else
                ClosePacMan(g);
        }

        public void OpenPacMan(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), X, Y, Width, Height);
            g.FillPie(new SolidBrush(Color.Black), X, Y, Width, Height, -40, 80);
            pacmanOpened = true;
        }

        public void ClosePacMan(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), X, Y, Width, Height);
            pacmanOpened = false;
        }

        public void OnCollide(CollideResult result)
        {
            
        }
        
        public void OnNoneCollide(int toX, int toY)
        {
            PlayerRenderer.Clear(X, Y);
            PlayerRenderer.DoRender(toX, toY);
            X = toX;
            Y = toY;
        }

        public void Move(Keys key)
        {
            if(key == Keys.W)
            {
                PlayerCollider.OnMove(X, Y - 16);
            }
            else if(key == Keys.S)
            {
                PlayerCollider.OnMove(X, Y + 16);
            }
            else if(key == Keys.A)
            {
                PlayerCollider.OnMove(X - 16, Y);
            }
            else if(key == Keys.D)
            {
                PlayerCollider.OnMove(X + 16, Y);
            }
            Thread.Sleep(250);
        }
    }
}

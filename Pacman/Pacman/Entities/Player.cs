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
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Energized { get; set; }
        public Collider PlayerCollider { get; private set; }

        private bool pacmanOpened;
        private int angle;
        private Level level;
        private RendererPanel renderer;
        private Keys lastKey;

        public Player(RendererPanel renderer, Level level, int width, int height)
        {
            this.level = level;
            this.renderer = renderer;
            PlayerCollider = new Collider(level, this);
            this.Width = width;
            this.Height = height;
            pacmanOpened = true;
            angle = -40;
        }

        public void Spawn(int x, int y)
        {
            this.X = x;
            this.Y = y;
            renderer.DoRender();
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
            g.FillPie(new SolidBrush(Color.Black), X, Y, Width, Height, angle, 80);
            pacmanOpened = true;
        }

        public void ClosePacMan(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), X, Y, Width, Height);
            pacmanOpened = false;
        }

        public void OnCollide(CollideResult result)
        {
            if(result.Type == CollisionType.Side)
            {
                int teleport = 0;
                if(lastKey == Keys.W)
                {
                    for (int i = 0; i <= 32; i++)
                    {
                        if (level.GetTile(i*16, Height * 31).Type == TileType.Way)
                        {
                            if (Math.Abs(teleport - X) > Math.Abs(i - X))
                            {
                                teleport = i*16;
                            }
                        }
                    }
                    X = teleport;
                    Y = Height * 31;
                    renderer.DoRender();
                }
                if(lastKey == Keys.S)
                {
                    for (int i = 0; i <= Width * 31; i += 16)
                    {
                        if (level.GetTile(i, 0).Type == TileType.Way)
                        {
                            if (Math.Abs(teleport - X) > Math.Abs(i - X))
                            {
                                teleport = i;
                            }
                        }
                    }
                    X = teleport;
                    Y = 0;
                    renderer.DoRender();
                }
                if(lastKey == Keys.D)
                {
                    for (int i = 0; i <= Height * 31; i += 16)
                    {
                        if (level.GetTile(0, i).Type == TileType.Way)
                        {
                            if (Math.Abs(teleport - Y) > Math.Abs(i - Y))
                            {
                                teleport = i;
                            }
                        }
                    }
                    Y = teleport;
                    X = 0;
                    renderer.DoRender();
                }
                if(lastKey == Keys.A)
                {
                    for (int i = 0; i <= 31; i++)
                    {
                        if (level.GetTile(Width * 31, i*16).Type == TileType.Way)
                        {
                            if (Math.Abs(teleport - Y) > Math.Abs(i*16 - Y))
                            {
                                teleport = i*16;
                            }
                        }
                    }
                    Y = teleport;
                    X = Width * 31;
                    renderer.DoRender();
                }
            }
        }
        
        public void OnNoneCollide(int toX, int toY)
        {
            renderer.DoRender();
            X = toX;
            Y = toY;
        }

        public void Move(Keys key)
        {
            if(key == Keys.W)
            {
                angle = -130;
                PlayerCollider.OnMove(X, Y - 16);
                lastKey = key;
            }
            else if(key == Keys.S)
            {
                angle = 50;
                PlayerCollider.OnMove(X, Y + 16);
                lastKey = key;
            }
            else if(key == Keys.A)
            {
                angle = 135;
                PlayerCollider.OnMove(X - 16, Y);
                lastKey = key;
            }
            else if(key == Keys.D)
            {
                angle = -40;
                PlayerCollider.OnMove(X + 16, Y);
                lastKey = key;
            }
            Thread.Sleep(250);
        }
    }
}

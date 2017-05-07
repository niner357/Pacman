using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RunLengthEncoding.Pathfinding;
using RunLengthEncoding.Controls;
using RunLengthEncoding.Audio;
using RunLengthEncoding.Utils;

namespace RunLengthEncoding
{
    public partial class Form1 : Form
    {
        public static ControlManager ControlManager;

        private AudioPlayer player;
        private int maxWidth = 10;

        #region SecondTry Vars
        private Graphics bufferGraphics;
        private Bitmap bufferBitmap;
        private Graphics screenGraphics;
        #endregion

        public Form1()
        {
            InitializeComponent();
            ControlManager = new ControlManager(panel1);
            ControlManager.OnControlClick += ControlManager_OnControlClick;

            TestButton button = new TestButton("TestButton", new Point(10, 10), new Size(200, 100));

            #region SecondTry Extra
            bufferBitmap = new Bitmap(panel1.Width, panel1.Height);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
            screenGraphics = panel1.CreateGraphics();
            grid = new List<GridField>();
            for(int x = 0; x < 512; x+=16)
            {
                for (int y = 0; y < 512; y+=16)
                {
                    grid.Add(new GridField(x, y));
                }
            }
            #endregion
            button.Text = "Test";
            button.OnInitRender(bufferGraphics);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);

            player = new AudioPlayer();
            player.StartPlayingRandomBackground();

            oldMaximum = MaximumSize;
            oldNormal = Size;
        }

        private void ControlManager_OnControlClick(GameControl source, MouseButtons btn)
        {
            if (source.Name == "TestButton")
                if (btn == MouseButtons.Left)
                    player.musicWaveOut.Volume = 0;
        }

        #region FirstTry
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Map File | *.jan";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string text = richTextBox1.Text.Replace("\n", "");
                int count = 0;
                char beforeChar = ' ';
                string str = "";
                foreach (char c in text.ToCharArray())
                {
                    if (beforeChar == ' ')
                    {
                        beforeChar = c;
                        count++;
                    }
                    else
                    {
                        if (beforeChar == c)
                        {
                            count++;
                        }
                        else
                        {
                            if(str == "")
                                str = count + beforeChar.ToString();
                            else
                                str += ";" + count + beforeChar.ToString();
                            beforeChar = c;
                            count = 1;
                        }
                    }
                }
                str += ";" + count + beforeChar.ToString();
                File.WriteAllText(fileDialog.FileName, str);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Map File | *.jan";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string contents = File.ReadAllText(fileDialog.FileName);
                string inputStr = "";
                int i = 0;
                foreach(string str in contents.Split(';'))
                {
                    char[] ca = str.ToCharArray();
                    char id = ca[ca.Length - 1];
                    ca[ca.Length - 1] = ' ';
                    string strCount = new string(ca);
                    int count = int.Parse(strCount);
                    for(int i_ = 0; i_ < count; i_++)
                    {
                        inputStr += id.ToString();
                        i++;
                        if (i == maxWidth)
                        {
                            inputStr += "\n";
                            i = 0;
                        }
                    }
                }
                richTextBox1.Clear();
                richTextBox1.Text = inputStr;
            }
        }
        #endregion

        #region SecondTry
        private bool overMap = false;
        private bool leftPressed = false;
        private List<GridField> grid;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(overMap && leftPressed)
            {
                GridField field = GetGridField(e.Location);
                if(field != null)
                {
                    if (!field.Solid)
                    {
                        grid.Remove(field);
                        bufferGraphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(field.X, field.Y, field.Width, field.Height));
                        screenGraphics.DrawImage(bufferBitmap, 0,0);
                        field.Solid = true;
                        grid.Add(field);
                    }
                }
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            overMap = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            overMap = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftPressed = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftPressed = false;
        }

        private GridField GetGridField(Point pt)
        {
            foreach(GridField field in grid)
            {
                if (field.IsPositionIn(pt))
                    return field;
            }
            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fieldIds = "";
            for (int y = 0; y < 512; y += 16)
            {
                for (int x = 0; x < 512; x += 16)
                {
                    GridField field = GetGridField(new Point(x+2, y+2));
                    if (field.Solid)
                        fieldIds += "=";
                    else
                        fieldIds += "_";
                }
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Map File | *.jan";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                int count = 0;
                char beforeChar = ' ';
                string str = "";
                foreach (char c in fieldIds.ToCharArray())
                {
                    if (beforeChar == ' ')
                    {
                        beforeChar = c;
                        count++;
                    }
                    else
                    {
                        if (beforeChar == c)
                        {
                            count++;
                        }
                        else
                        {
                            if (str == "")
                                str = count + beforeChar.ToString();
                            else
                                str += ";" + count + beforeChar.ToString();
                            beforeChar = c;
                            count = 1;
                        }
                    }
                }
                str += ";" + count + beforeChar.ToString();
                File.WriteAllText(fileDialog.FileName, str);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Map File | *.jan";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string contents = File.ReadAllText(fileDialog.FileName);
                string inputStr = "";
                foreach (string str in contents.Split(';'))
                {
                    char[] ca = str.ToCharArray();
                    char id = ca[ca.Length - 1];
                    ca[ca.Length - 1] = ' ';
                    string strCount = new string(ca);
                    int count = int.Parse(strCount);
                    for (int i_ = 0; i_ < count; i_++)
                    {
                        inputStr += id.ToString();
                    }
                }
                int i = 0;
                grid.Clear();
                for (int _y = 0; _y < 512; _y += 16)
                {
                    for (int _x = 0; _x < 512; _x += 16)
                    {
                        char c = inputStr.ToCharArray()[i];
                        i++;
                        if (c == '=')
                        {
                            GridField field = new GridField(_x, _y);
                            field.Solid = true;
                            bufferGraphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(field.X, field.Y, field.Width, field.Height));
                            grid.Add(field);
                        }
                        else
                        {
                            GridField field = new GridField(_x, _y);
                            grid.Add(field);
                        }
                    }
                }
                screenGraphics.DrawImage(bufferBitmap, 0, 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bufferGraphics.Clear(Color.Black);
            grid = new List<GridField>();
            for (int x = 0; x < 512; x += 16)
            {
                for (int y = 0; y < 512; y += 16)
                {
                    grid.Add(new GridField(x, y));
                }
            }
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
        }
        #endregion

        #region AStar Pathfinding
        private void button6_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0].Split(new string[] { ";" }, StringSplitOptions.None)[0]);
            int y = int.Parse(textBox1.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0].Split(new string[] { ";" }, StringSplitOptions.None)[1]);
            int _x = int.Parse(textBox1.Text.Split(new string[] { " - " }, StringSplitOptions.None)[1].Split(new string[] { ";" }, StringSplitOptions.None)[0]);
            int _y = int.Parse(textBox1.Text.Split(new string[] { " - " }, StringSplitOptions.None)[1].Split(new string[] { ";" }, StringSplitOptions.None)[1]);
            PathFinder finder = new PathFinder(grid, new Point(x,y), new Point(_x, _y));
            foreach (Point pt in finder.FindPath()) 
            {
                GridField field = new GridField(pt.X * 16, pt.Y * 16);
                bufferGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(field.X, field.Y, field.Width, field.Height));
                screenGraphics.DrawImage(bufferBitmap, 0, 0);
            }
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadingScreen.Start(panel1);
            ControlManager.Initialize(bufferBitmap, bufferGraphics, screenGraphics);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Close();
        }

        private Size oldMaximum;
        private Size oldNormal;

        private void button7_Click(object sender, EventArgs e)
        {
            TopMost = true;
            MaximumSize = new Size(0, 0);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TopMost = false;
            MaximumSize = oldMaximum;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Normal;
        }
    }
}

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

namespace LevelCreator
{
    public partial class MainForm : Form
    {
        private Graphics bufferGraphics;
        private Bitmap bufferBitmap;
        private Graphics screenGraphics;
        private Map map;
        private bool leftPressed;

        public MainForm()
        {
            map = new Map();
            InitializeComponent();
            bufferBitmap = new Bitmap(mapPanel.Width, mapPanel.Height);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
            screenGraphics = mapPanel.CreateGraphics();

            ImageList imageList = new ImageList();
            imageList.Images.Add("iconSolid", Properties.Resources.icon_field_solid);
            imageList.Images.Add("iconWay", Properties.Resources.icon_field_way);
            imageList.Images.Add("iconSpawn", Properties.Resources.icon_field_spawn);
            constructionKitListView.LargeImageList = imageList;
            ListViewItem wayItem = constructionKitListView.Items.Add("Way Field");
            wayItem.ImageKey = "iconWay";
            ListViewItem solidItem = constructionKitListView.Items.Add("Solid Field");
            solidItem.ImageKey = "iconSolid";
            ListViewItem spawnItem = constructionKitListView.Items.Add("Spawn Field");
            spawnItem.ImageKey = "iconSpawn";
        }

        private void mapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftPressed = true;
                Field field = GetField(e.Location);
                if(field != null)
                {
                    int i = GetIndex(field);
                    if (constructionKitListView.SelectedItems.Count <= 0)
                        return;
                    switch (constructionKitListView.SelectedItems[0].Text)
                    {
                        case "Way Field":
                            map.Fields[i].Type = FieldType.WAY;
                            bufferGraphics.FillRectangle(new SolidBrush(Color.Black), map.Fields[i].X, map.Fields[i].Y, 16, 16);
                            screenGraphics.DrawImage(bufferBitmap, 0, 0);
                            break;
                        case "Solid Field":
                            map.Fields[i].Type = FieldType.SOLID;
                            bufferGraphics.FillRectangle(new SolidBrush(Color.Blue), map.Fields[i].X, map.Fields[i].Y, 16, 16);
                            screenGraphics.DrawImage(bufferBitmap, 0, 0);
                            break;
                        case "Spawn Field":
                            bufferGraphics.FillRectangle(new SolidBrush(Color.Black), map.Fields[GetIndexOfPlayerSpawn()].X, map.Fields[GetIndexOfPlayerSpawn()].Y, 16, 16);
                            bufferGraphics.FillEllipse(new SolidBrush(Color.Gold), map.Fields[i].X, map.Fields[i].Y, 16, 16);
                            bufferGraphics.FillPie(new SolidBrush(Color.Black), map.Fields[i].X, map.Fields[i].Y, 16, 16, -40, 80);
                            map.Fields[GetIndexOfPlayerSpawn()].Type = FieldType.WAY;
                            map.Fields[i].Type = FieldType.PLAYER_SPAWN;
                            screenGraphics.DrawImage(bufferBitmap, 0, 0);
                            break;
                    }
                }
            }
        }

        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftPressed)
            {
                Field field = GetField(e.Location);
                if (field != null)
                {
                    int i = GetIndex(field);
                    if (constructionKitListView.SelectedItems.Count <= 0)
                        return;
                    switch (constructionKitListView.SelectedItems[0].Text)
                    {
                        case "Way Field":
                            map.Fields[i].Type = FieldType.WAY;
                            bufferGraphics.FillRectangle(new SolidBrush(Color.Black), map.Fields[i].X, map.Fields[i].Y, 16, 16);
                            screenGraphics.DrawImage(bufferBitmap, 0, 0);
                            break;
                        case "Solid Field":
                            map.Fields[i].Type = FieldType.SOLID;
                            bufferGraphics.FillRectangle(new SolidBrush(Color.Blue), map.Fields[i].X, map.Fields[i].Y, 16, 16);
                            screenGraphics.DrawImage(bufferBitmap, 0, 0);
                            break;
                    }
                }
            }
        }

        private void mapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftPressed = false;
        }

        private int GetIndexOfPlayerSpawn()
        {
            for (int i = 0; i < map.Fields.Length; i++)
                if (map.Fields[i].Type == FieldType.PLAYER_SPAWN)
                    return i;
            return 0;
        }

        private int GetIndex(Field field)
        {
            for (int i = 0; i < map.Fields.Length; i++)
                if (map.Fields[i] == field)
                    return i;
            return 0;
        }

        private Field GetField(Point pt)
        {
            foreach (Field field in map.Fields)
            {
                if(field != null)
                    if (field.IsPositionIn(pt))
                        return field;
            }
            return null;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fieldIds = "";
            for (int y = 0; y < 512; y += 16)
            {
                for (int x = 0; x < 512; x += 16)
                {
                    Field field = GetField(new Point(x + 2, y + 2));
                    switch (field.Type)
                    {
                        case FieldType.POINT:
                            fieldIds += "o";
                            continue;
                        case FieldType.FRUIT:
                            fieldIds += "?";
                            continue;
                        case FieldType.PLAYER_SPAWN:
                            fieldIds += "+";
                            continue;
                        case FieldType.BGHOST_SPAWN:
                            fieldIds += "b";
                            continue;
                        case FieldType.IGHOST_SPAWN:
                            fieldIds += "i";
                            continue;
                        case FieldType.PGHOST_SPAWN:
                            fieldIds += "p";
                            continue;
                        case FieldType.CGHOST_SPAWN:
                            fieldIds += "c";
                            continue;
                        case FieldType.SOLID:
                            fieldIds += ":";
                            continue;
                        case FieldType.WAY:
                            fieldIds += "_";
                            continue;
                        case FieldType.POWER_UP:
                            fieldIds += "*";
                            continue;
                    }
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
    }
}

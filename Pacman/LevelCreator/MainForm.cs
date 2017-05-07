using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}

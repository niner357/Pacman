using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace RunLengthEncoding.Utils
{
    public class LoadingScreen
    {
        public static void Start(Panel panel)
        {
            Bitmap bufferBitmap = new Bitmap(panel.Width, panel.Height);
            Graphics bufferGraphics = Graphics.FromImage(bufferBitmap);
            Graphics screenGraphics = panel.CreateGraphics();
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_0, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_1, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_2, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_3, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_4, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_5, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_6, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_7, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_8, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_9, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_10, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_11, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_12, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_13, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_14, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_15, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_16, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_17, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_18, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_19, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
            Thread.Sleep(190);
            bufferGraphics.Clear(Color.Black);
            bufferGraphics.DrawImage(GDIUtils.ResizeImage(Properties.Resources.res_loading_20, panel.Width, panel.Height), 0, 0);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
        }
    }
}

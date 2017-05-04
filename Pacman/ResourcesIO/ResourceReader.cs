using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.IO.Compression;

namespace ResourcesIO
{
    public class ResourceReader
    {
        public string Path { get; private set; }

        public string ResoureFile { get; private set; }

        public RichTextBox DebugTextBox { get; private set; }

        public ResourceReader(string resourceFile)
        {
            ResoureFile = resourceFile;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\files";
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }

        public ResourceReader(string resourceFile, string path)
        {
            ResoureFile = resourceFile;
            Path = path;
        }

        public ResourceReader(string resourceFile, RichTextBox debuTextBox)
        {
            ResoureFile = resourceFile;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\files";
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            DebugTextBox = debuTextBox;
        }

        public ResourceReader(string resourceFile, string path, RichTextBox debuTextBox)
        {
            ResoureFile = resourceFile;
            Path = path;
            DebugTextBox = debuTextBox;
        }

        public void Read()
        {
            ZipFile.ExtractToDirectory(ResoureFile, Path);
        }

        private void Log(string msg)
        {
            if (DebugTextBox != null)
            {
                DebugTextBox.Text = DebugTextBox.Text + "\n" + msg;
            }
        }
    }
}

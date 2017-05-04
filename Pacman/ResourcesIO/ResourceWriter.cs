using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.IO.Compression;
namespace ResourcesIO
{
    /// <summary>
    /// Its the writer that writes all Resources in a File
    /// </summary>
    public class ResourceWriter
    {
        public RichTextBox DebugTextBox { get; private set; }
        
        public List<string> ResourcesPaths { get; private set; }

        public string Name { get; private set; }

        public string Path { get; private set; }

        public string OutputPath { get; private set; }

        public ResourceWriter(string name, List<string> resourcesPaths)
        {
            Name = name;
            ResourcesPaths = resourcesPaths;
            DebugTextBox = null;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\exported";
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }

        public ResourceWriter(string name, List<string> resourcesPaths, string path)
        {
            Name = name;
            ResourcesPaths = resourcesPaths;
            Path = path;
        }

        public ResourceWriter(string name, List<string> resourcesPaths, RichTextBox debugTextBox)
        {
            Name = name;
            ResourcesPaths = resourcesPaths;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\exported";
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            DebugTextBox = debugTextBox;
        }

        public ResourceWriter(string name, List<string> resourcesPaths, string path, RichTextBox debugTextBox)
        {
            Name = name;
            ResourcesPaths = resourcesPaths;
            DebugTextBox = debugTextBox;
            Path = path;
        }

        public void Write()
        {
            string tempPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\temp";
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            foreach(string file in Directory.GetFiles(tempPath))
            {
                File.Delete(file);
            }
            foreach(string file in ResourcesPaths)
            {
                File.Copy(file, tempPath + "\\" + System.IO.Path.GetFileName(file));
            }
            OutputPath = Path + "\\" + Options.NameAdditional + Name + Options.Extension;
            ZipArchive archive = ZipFile.Open(OutputPath, ZipArchiveMode.Create);
            foreach (string file in Directory.GetFiles(tempPath))
            {
                archive.CreateEntryFromFile(file, System.IO.Path.GetFileNameWithoutExtension(file));
            }
        }

        private void Log(string msg)
        {
            if(DebugTextBox != null)
            {
                DebugTextBox.Text = DebugTextBox.Text + "\n" + msg;
            }
        }
    }
}

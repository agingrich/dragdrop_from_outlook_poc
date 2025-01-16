using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace DragDropPOC
{
    public partial class DocumentExplorer : UserControl
    {
        public DocumentExplorer()
        {
            InitializeComponent();
            DocumentDirectorySelector.DocumentDirectoryChanged += this.DocumentDirectoryChanged;
        }

        public void RefreshFiles()
        {
            FileInfo[] fileinfos = DocumentSettings.DocumentDirectoryInfo.GetFiles();
            LvItem[] lvitems = (from fi in fileinfos select LvItem.Create(fi)).ToArray();
            ListViewItem[] items = (from lvi in lvitems select lvi.ToListViewItem()).ToArray();

            this.lvDocuments.Items.Clear();
            this.lvDocuments.Items.AddRange(items);
        }

        private void DocumentExplorer_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.directoryWatcher.Path = DocumentSettings.DocumentDirectory;
                this.RefreshFiles();
            }
        }

        private void directoryWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            this.RefreshFiles();
        }

        private void lvDocuments_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Contains("FileGroupDescriptor"))
            {
                MemoryStream ms = (MemoryStream)e.Data.GetData("FileGroupDescriptor");
                string[] filenames = FileGroupDescriptor.GetFileNames(ms);

                for (int i = 0; i < filenames.Length; i++)
                {
                    byte[] data = FileContents.GetFileContents(e.Data, i);
                    File.WriteAllBytes(Path.Combine(DocumentSettings.DocumentDirectoryInfo.FullName, filenames[i]), data);
                }
            }
        }

        private void lvDocuments_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Contains("FileGroupDescriptor"))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DocumentDirectoryChanged(object sender, EventArgs e)
        {
            this.directoryWatcher.Path = DocumentSettings.DocumentDirectory;
            this.RefreshFiles();
        }
    }
}

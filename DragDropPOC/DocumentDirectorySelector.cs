using System;
using System.Windows.Forms;

namespace DragDropPOC
{
    public partial class DocumentDirectorySelector : UserControl
    {
        public static event EventHandler DocumentDirectoryChanged;

        public DocumentDirectorySelector()
        {
            InitializeComponent();
        }

        private void DocumentDirectorySelector_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.txtDocumentDirectory.Text = DocumentSettings.DocumentDirectory;
                this.folderBrowserDg.SelectedPath = DocumentSettings.DocumentDirectory;
            }
        }

        private void btnBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.folderBrowserDg.ShowDialog() == DialogResult.OK)
            {
                DocumentSettings.DocumentDirectory = this.folderBrowserDg.SelectedPath;
                this.txtDocumentDirectory.Text = this.folderBrowserDg.SelectedPath;

                if (DocumentDirectoryChanged != null)
                    DocumentDirectoryChanged(this, new EventArgs());
            }
        }
    }
}

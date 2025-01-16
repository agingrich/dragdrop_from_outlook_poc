
namespace DragDropPOC
{
    partial class DocumentExplorer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvDocuments = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.directoryWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.directoryWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // lvDocuments
            // 
            this.lvDocuments.AllowDrop = true;
            this.lvDocuments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDateModified,
            this.colType,
            this.colSize});
            this.lvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDocuments.FullRowSelect = true;
            this.lvDocuments.HideSelection = false;
            this.lvDocuments.Location = new System.Drawing.Point(0, 0);
            this.lvDocuments.Name = "lvDocuments";
            this.lvDocuments.Size = new System.Drawing.Size(441, 272);
            this.lvDocuments.TabIndex = 0;
            this.lvDocuments.UseCompatibleStateImageBehavior = false;
            this.lvDocuments.View = System.Windows.Forms.View.Details;
            this.lvDocuments.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvDocuments_DragDrop);
            this.lvDocuments.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvDocuments_DragEnter);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 147;
            // 
            // colDateModified
            // 
            this.colDateModified.Text = "Date modified";
            this.colDateModified.Width = 111;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 81;
            // 
            // directoryWatcher
            // 
            this.directoryWatcher.EnableRaisingEvents = true;
            this.directoryWatcher.SynchronizingObject = this;
            this.directoryWatcher.Changed += new System.IO.FileSystemEventHandler(this.directoryWatcher_Changed);
            this.directoryWatcher.Created += new System.IO.FileSystemEventHandler(this.directoryWatcher_Changed);
            this.directoryWatcher.Deleted += new System.IO.FileSystemEventHandler(this.directoryWatcher_Changed);
            // 
            // DocumentExplorer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvDocuments);
            this.Name = "DocumentExplorer";
            this.Size = new System.Drawing.Size(441, 272);
            this.Load += new System.EventHandler(this.DocumentExplorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.directoryWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDocuments;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDateModified;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.IO.FileSystemWatcher directoryWatcher;
    }
}

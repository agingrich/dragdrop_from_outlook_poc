
namespace DragDropPOC
{
    partial class DocumentDirectorySelector
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
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDg = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDocumentDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document Directory:";
            // 
            // txtDocumentDirectory
            // 
            this.txtDocumentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentDirectory.Location = new System.Drawing.Point(113, 3);
            this.txtDocumentDirectory.Name = "txtDocumentDirectory";
            this.txtDocumentDirectory.Size = new System.Drawing.Size(351, 20);
            this.txtDocumentDirectory.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.Location = new System.Drawing.Point(470, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(51, 13);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.TabStop = true;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnBrowse_LinkClicked);
            // 
            // DocumentDirectorySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDocumentDirectory);
            this.Controls.Add(this.label1);
            this.Name = "DocumentDirectorySelector";
            this.Size = new System.Drawing.Size(524, 25);
            this.Load += new System.EventHandler(this.DocumentDirectorySelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDg;
        private System.Windows.Forms.TextBox txtDocumentDirectory;
        private System.Windows.Forms.LinkLabel btnBrowse;
    }
}


namespace DragDropPOC
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.documentDirectorySelector1 = new DragDropPOC.DocumentDirectorySelector();
            this.documentExplorer1 = new DragDropPOC.DocumentExplorer();
            this.SuspendLayout();
            // 
            // documentDirectorySelector1
            // 
            this.documentDirectorySelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentDirectorySelector1.Location = new System.Drawing.Point(12, 12);
            this.documentDirectorySelector1.Name = "documentDirectorySelector1";
            this.documentDirectorySelector1.Size = new System.Drawing.Size(536, 25);
            this.documentDirectorySelector1.TabIndex = 1;
            // 
            // documentExplorer1
            // 
            this.documentExplorer1.AllowDrop = true;
            this.documentExplorer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentExplorer1.Location = new System.Drawing.Point(12, 43);
            this.documentExplorer1.Name = "documentExplorer1";
            this.documentExplorer1.Size = new System.Drawing.Size(536, 210);
            this.documentExplorer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 265);
            this.Controls.Add(this.documentDirectorySelector1);
            this.Controls.Add(this.documentExplorer1);
            this.Name = "Form1";
            this.Text = "Drag/Drop from Outlook PoC";
            this.ResumeLayout(false);

        }

        #endregion

        private DocumentExplorer documentExplorer1;
        private DocumentDirectorySelector documentDirectorySelector1;
    }
}


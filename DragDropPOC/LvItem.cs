using System;
using System.IO;
using System.Windows.Forms;

namespace DragDropPOC
{
    public class LvItem
    {
        public string Name { get; set; }
        public string DateModified { get; set; }
        public string FileType { get; set; }
        public string Size { get; set; }

        public static LvItem Create(FileInfo fileInfo)
        {
            LvItem item = new LvItem()
            {
                Name = fileInfo.Name,
                DateModified = fileInfo.LastWriteTime.ToString(),
                FileType = fileInfo.Extension
            };

            if (fileInfo.Length < 1024)
                item.Size = string.Format("{0} B", fileInfo.Length);
            else if (fileInfo.Length < 1048576)
                item.Size = string.Format("{0} KB", Math.Ceiling((Decimal)fileInfo.Length / 1024));
            else if (fileInfo.Length < 1073741824)
                item.Size = string.Format("{0} MB", Math.Ceiling((Decimal)fileInfo.Length / 1048576));
            else
                item.Size = string.Format("{0} GB", Math.Ceiling((Decimal)fileInfo.Length / 1073741824));

            return item;
        }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(
                new string[] {
                        this.Name,
                        this.DateModified,
                        this.FileType,
                        this.Size
                }
            );
        }
    }
}

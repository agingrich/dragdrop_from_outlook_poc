using System.IO;

namespace DragDropPOC
{
    public static class DocumentSettings
    {
        private static DirectoryInfo _documentDirectoryInfo = null;

        public static DirectoryInfo DocumentDirectoryInfo
        {
            get
            {
                string docDir = Properties.Settings.Default.DocumentDirectory;

                if (!Directory.Exists(docDir))
                {
                    _documentDirectoryInfo = Directory.CreateDirectory(docDir);
                }

                if (_documentDirectoryInfo == null || _documentDirectoryInfo.FullName.ToLower() != docDir.ToLower())
                {
                    _documentDirectoryInfo = new DirectoryInfo(docDir);
                }

                return _documentDirectoryInfo;
            }
        }

        public static string DocumentDirectory
        {
            get => Properties.Settings.Default.DocumentDirectory;
            set => Properties.Settings.Default.DocumentDirectory = value;
        }
    }
}

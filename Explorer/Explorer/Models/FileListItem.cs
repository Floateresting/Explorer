using Xamarin.Forms;

namespace Explorer.Models {
    public enum FileListItemType {
        File,
        Folder
    }

    public class FileListItem {
        public string FullPath { get; set; }

        public string Text { get; set; }

        public FileListItemType Type { get; set; }

        public ImageSource ImageSource { get; set; }

        public Command<string> TappedCommand { get; set; }
    }
}

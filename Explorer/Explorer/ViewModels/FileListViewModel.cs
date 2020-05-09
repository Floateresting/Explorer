using Explorer.Models;
using System.Collections.ObjectModel;

namespace Explorer.ViewModels {
    public class FileListViewModel : BaseViewModel {

        private ObservableCollection<FileListItem> children;
        public ObservableCollection<FileListItem> Children {
            get { return this.children; }
            set { this.SetProperty(ref this.children, value); }
        }

        public FileListViewModel() { }
    }
}

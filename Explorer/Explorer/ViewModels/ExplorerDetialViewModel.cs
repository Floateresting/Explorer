using Explorer.Models;
using Explorer.Services;
using Explorer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Explorer.ViewModels {
    public class ExplorerDetailViewModel : BaseViewModel {
        #region Public Properties

        public INavigation Navigation { get; set; }
        public string FullPath { get; set; }

        private ObservableCollection<AddressBarItem> addressBarItems;
        public ObservableCollection<AddressBarItem> AddressBarItems {
            get { return this.addressBarItems; }
            set {
                this.SetProperty(ref this.addressBarItems, value);
            }
        }

        public FileListViewModel FileList { get; set; }
        #endregion

        #region Contructor

        public ExplorerDetailViewModel(string path) {
            this.FullPath = path;
            this.AddressBarItems = this.GetAddressBarItem().Result;
            this.FileList = new FileListViewModel {
                Children = this.GetChildren().Result
            };
        }
        #endregion

        #region Commands

        private async Task OnFolderTapped(string path) {
            await this.Navigation.PushAsync(new ExplorerDetailPage {
                BindingContext = new ExplorerDetailViewModel(path) {
                    Navigation = this.Navigation
                }
            });
        }

        private async Task OnFileTapped(string path) {
            await Launcher.OpenAsync(new OpenFileRequest {
                File = new ReadOnlyFile(path)
            });
        }

        private async Task OnAddressBarTapped(string path) {
            // if the user clicked on the current folder
            if(this.FullPath == path) {
                DependencyService.Get<IToastService>().ShortAlert("Refreshed");
            } else {
                this.FullPath = path;
                this.AddressBarItems = await this.GetAddressBarItem();
            }
            this.FileList.Children = await this.GetChildren();
        }
        #endregion

        #region Helpers

        internal async Task<ObservableCollection<FileListItem>> GetChildren() {
            List<FileListItem> children = new List<FileListItem>();
            string[] items;

            // Search for directories and files
            try {
                // Directories
                items = Directory.GetDirectories(this.FullPath);
                Array.Sort(items);
                if(items.Length > 0) {
                    children.AddRange(items.Select(d => new FileListItem {
                        FullPath = d,
                        Text = Path.GetFileName(d),
                        Type = FileListItemType.Folder,
                        ImageSource = ImageSource.FromResource("Explorer.Icons.folder.ico"),
                        TappedCommand = new Command<string>(async (path) => await this.OnFolderTapped(path))
                    }));
                }

                // Files
                items = Directory.GetFiles(this.FullPath);
                if(items.Length > 0) {
                    children.AddRange(items.Select(f => new FileListItem {
                        FullPath = f,
                        Text = Path.GetFileName(f),
                        Type = FileListItemType.File,
                        ImageSource = ImageSource.FromResource("Explorer.Icons.file.ico"),
                        TappedCommand = new Command<string>(async (path) => await this.OnFileTapped(path))
                    }));
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex);
            }
            return await Task.FromResult(new ObservableCollection<FileListItem>(children));
        }

        internal async Task<ObservableCollection<AddressBarItem>> GetAddressBarItem() {
            string[] folders = this.FullPath.Split('/');
            return await Task.FromResult(new ObservableCollection<AddressBarItem>(
                folders.Select((f, i) => new AddressBarItem {
                    FullPath = string.Join("/", folders.Take(i + 1)),
                    Text = f + "/",
                    TappedCommand = new Command<string>(async (path) => await this.OnAddressBarTapped(path)),
                })));
        }
        #endregion
    }
}

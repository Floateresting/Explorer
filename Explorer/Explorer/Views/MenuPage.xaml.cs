using Explorer.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Explorer.Views {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage {
        private MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        private readonly List<HomeMenuItem> menuItems;
        public MenuPage() {
            this.InitializeComponent();

            this.menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            this.ListViewMenu.ItemsSource = this.menuItems;
            this.ListViewMenu.SelectedItem = this.menuItems[0];
            this.ListViewMenu.ItemSelected += (sender, e) => {
                if(e.SelectedItem == null) {
                    return;
                }

                int id = (int)((HomeMenuItem)e.SelectedItem).Id;
                this.RootPage.NavigateFromMenu(id);
            };
        }
    }
}
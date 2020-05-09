using Explorer.CustomControls;
using Explorer.Models;
using Explorer.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Explorer.Views {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage {

        private readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage() {
            this.InitializeComponent();
            //this.MasterBehavior = MasterBehavior.Popover;
            this.MasterBehavior = MasterBehavior.Split;
            this.MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)this.Detail);
        }

        public void NavigateFromMenu(int id) {
            if(!this.MenuPages.ContainsKey(id)) {
                switch(id) {
                    case (int)MenuItemType.Browse:
                        this.MenuPages.Add(id, new CustomNavigationPage(new ExplorerDetailPage()));
                        break;
                    case (int)MenuItemType.About:
                        this.MenuPages.Add(id, new CustomNavigationPage(new AboutPage()));
                        break;
                }
            }

            NavigationPage newPage = this.MenuPages[id];

            if(newPage != null && this.Detail != newPage) {
                this.Detail = newPage;

                //if(Device.RuntimePlatform == Device.Android) {
                //    await Task.Delay(100);
                //}

                this.IsPresented = false;
            }
        }
    }
}
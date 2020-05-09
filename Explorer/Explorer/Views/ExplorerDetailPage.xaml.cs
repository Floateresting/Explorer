using Explorer.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Explorer.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExplorerDetailPage : ContentPage {

        private const string Root = "/storage/emulated/0";
        #region Constructor 

        public ExplorerDetailPage() {
            this.BindingContext = new ExplorerDetailViewModel(Root) { Navigation = this.Navigation };

            this.InitializeComponent();
        }


        #endregion

        private void OnStackLayoutSizeChanged(object sender, EventArgs e) {
            this.AddressBarScrollView.ScrollToAsync(
                this.AddressBarStackLayout,
                ScrollToPosition.End,
                true);
        }
    }
}
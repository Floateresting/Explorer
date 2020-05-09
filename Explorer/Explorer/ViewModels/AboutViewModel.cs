using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Explorer.ViewModels {
    public class AboutViewModel : BaseViewModel {
        public string Title { get; set; }
        public AboutViewModel() {
            this.Title = "About";
            this.OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
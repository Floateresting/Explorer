using Xamarin.Forms;

namespace Explorer.Models {
    public class AddressBarItem {
        public string FullPath { get; set; }
        public string Text { get; set; }
        public Command<string> TappedCommand { get; set; }
    }
}

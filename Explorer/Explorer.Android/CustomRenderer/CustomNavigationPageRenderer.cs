using Android.Content;
using Explorer.CustomControls;
using Explorer.Droid.CustomRenderer;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace Explorer.Droid.CustomRenderer {
    /// <summary>
    /// NavigationPage with no animation
    /// </summary>
    public class CustomNavigationPageRenderer : NavigationPageRenderer {
        public CustomNavigationPageRenderer(Context context) : base(context) {
        }

        protected override Task<bool> OnPopViewAsync(Page page, bool animated) {
            return base.OnPopViewAsync(page, false);
        }

        protected override Task<bool> OnPushAsync(Page page, bool animated) {
            return base.OnPushAsync(page, false);
        }
    }
}
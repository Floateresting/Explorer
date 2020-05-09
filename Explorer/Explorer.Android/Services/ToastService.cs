using Android.App;
using Android.OS;
using Android.Widget;
using Explorer.Services;

[assembly: Xamarin.Forms.Dependency(typeof(Message))]
namespace Explorer.Droid.Services {
    public class ToastService : IToastService {
        public void LongAlert(string message) {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message) {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}
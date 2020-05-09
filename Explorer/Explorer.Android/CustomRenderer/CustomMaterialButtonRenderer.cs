using Android.Content;
using Explorer.CustomControls;
using Explorer.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomMaterialButtonRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Explorer.Droid.CustomRenderer {
    public class CustomMaterialButtonRenderer : MaterialButtonRenderer {
        public CustomMaterialButtonRenderer(Context context) : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e) {
            base.OnElementChanged(e);
            this.Control?.SetPadding(0, 0, 0, 0);
        }
    }
}

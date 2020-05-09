using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Explorer {
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this.Source == null ? null : ImageSource.FromResource(this.Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        }
    }
}

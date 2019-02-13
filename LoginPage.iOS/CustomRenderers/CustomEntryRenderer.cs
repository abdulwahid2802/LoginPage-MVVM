using System;
using LoginPage.iOS.CustomRenderers;
using LoginPage.Toolkit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace LoginPage.iOS.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var view = (CustomEntry)Element;

            this.Control.BorderStyle = UIKit.UITextBorderStyle.Bezel;
            this.Control.Layer.BorderWidth = 1;
            this.Control.Layer.BorderColor = Color.White.ToCGColor();
            this.Control.Layer.CornerRadius = 10;
            this.Control.TintColor = UIColor.White;
        }
    }
}

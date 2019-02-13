using System;
using Android.Graphics.Drawables;
using LoginPage.Droid.CustomRenderers;
using LoginPage.Toolkit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace LoginPage.Droid.CustomRenderers
{
	public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            GradientDrawable gd = new GradientDrawable();
            gd.SetStroke(2, global::Android.Graphics.Color.White);
            gd.SetCornerRadius(25);

            this.Control.SetBackgroundDrawable(gd);
            this.Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            this.Control.SetHintTextColor(Color.FromHex("75ffffff").ToAndroid());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginPage.Views
{
    public partial class ContentPage1 : ContentPage
    {
        Random random = new Random();
        public ContentPage1()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            await this.RotateTo(15, 1000, new Easing(t =>
                                                        Math.Sin(Math.PI * t) *
                                                        Math.Sin(Math.PI * 20 * t)));





            // Swing down from lower-left corner.
            button.AnchorX = 0;
            button.AnchorY = 1;
            await button.RotateTo(90, 3000,
            new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));
            // Drop to the bottom of the screen.
            await button.TranslateTo(0, (Height - button.Height) / 2 - button.Width,1000, Easing.BounceOut);
           // Prepare AnchorX and AnchorY for next rotation.
            button.AnchorX = 1;
            button.AnchorY = 0;

            // Compensate for the change in AnchorX and AnchorY.
            button.TranslationX -= button.Width - button.Height; 
            button.TranslationY += button.Width + button.Height;

            // Fall over.
            await button.RotateTo(180, 1000, Easing.BounceOut);

            await Task.WhenAll
            (
                button.FadeTo(0, 4000),
                button.TranslateTo(0, -Height, 5000, Easing.CubicIn)
            );

            // After three seconds, return the Button to normal.
            await Task.Delay(3000);
            button.TranslationX = 0;
            button.TranslationY = 0;
            button.Rotation = 0;
            button.Opacity = 1;

        }
    }
}

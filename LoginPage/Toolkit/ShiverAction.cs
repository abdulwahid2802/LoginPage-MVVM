using System;
using Xamarin.Forms;

namespace LoginPage.Toolkit
{
    public class ShiverAction : TriggerAction<VisualElement>
    {
        public ShiverAction()
        {
            Length = 1000;
            Angle = 15;
            Distance = 3;
            Vibrations = 10;
        }

        public int Length { get; set; }

        public int Vibrations { get; set; }

        public double Angle { get; set; }

        public double Distance { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            //sender.Rotation = 0; //used when shivering rotation axis

            sender.TranslationX = 0;
            sender.AnchorX = .5;
            sender.AnchorY = .5;
            await sender.TranslateTo(Distance, 0, (uint)Length, new Easing(t => Math.Sin(Math.PI * t) * Math.Sin(Math.PI * 2 * Vibrations * t)));

            //await sender.TranslateTo(-15, 0, 50);
            //await sender.TranslateTo(15, 0, 50);
            //await sender.TranslateTo(-10, 0, 50); 
            //await sender.TranslateTo(10, 0, 50);
            //await sender.TranslateTo(-5, 0, 50);
            //await sender.TranslateTo(5, 0, 50);
            //await sender.TranslateTo(0, 0, 50);
        }
    }
}

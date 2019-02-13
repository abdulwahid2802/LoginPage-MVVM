using System;
using System.Collections.Generic;
using Xamanimation;
using Xamarin.Forms;

namespace LoginPage.Views
{
    public partial class DynamicLoginPage : ContentPage
    {
        public DynamicLoginPage()
        {
            InitializeComponent();

            InitAnimation();
        }

        private void InitAnimation()
        {
            if(Resources["backgroundAnimation"] is ColorAnimation colorAnimation)
            {
                colorAnimation.Begin();
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if(width > height)
            {
                mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(lowerPanel, 0);
                Grid.SetColumn(lowerPanel, 1);

                return;
            }

            mainGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
            mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);

            Grid.SetRow(lowerPanel, 1);
            Grid.SetColumn(lowerPanel, 0);

        }
    }
}

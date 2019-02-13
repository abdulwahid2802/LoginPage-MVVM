using System;
using System.Collections.Generic;
using Xamanimation;
using Xamarin.Forms;

namespace LoginPage.Views
{
    public partial class CustomLoginPage : ContentPage
    {
        public CustomLoginPage()
        {
            InitializeComponent();

            InitAniation();


        }

        private void InitAniation()
        {
                if (Resources["colorAnimation"] is ColorAnimation colorAnimation)
                {
                    colorAnimation.Begin();
                }
        }
    }
}

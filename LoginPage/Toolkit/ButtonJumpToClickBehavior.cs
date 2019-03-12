﻿//
// ButtonJumpToClickBehavior.cs
//
// Author:
//       Abduvokhid <wakhid2802@gmail.com>
//
// Copyright (c) 2019 
// 2/26/2019
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginPage.Toolkit
{
    public class ButtonJumpToClickBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Clicked += Bindable_Clicked;
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.Clicked -= Bindable_Clicked;
        }

        async void Bindable_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                await btn.ScaleTo(1.05, 250, Easing.SpringIn);
                await Task.Delay(100);
                await btn.ScaleTo(1.0, 150, Easing.SpringOut);
            }
        }

    }
}
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace LoginPage.ViewModel
{
    public class LoginPageViewModel : ViewModelBase
    {
        string _bannerLarge;
        string _bannerSmall;
        string _loginEntryText;
        string _passwordEntryText;

        string _loginErrorText;
        string _passwordErrorText;

        Command _signInCommand;
        Command _signUpCommand;

        bool _loginErrorOpacity;
        bool _passwordErrorOpacity;



        public LoginPageViewModel()
        {

            LargeBanner = "Welcome To Xamarin.Forms";
            SmallBanner = "Cross Platform apps made easy";

            LoginErrorText = "*please check your login input";
            PasswordErrorText = "*please check your password input";

            _signInCommand = new Command(
                execute: () =>
            {
            }, 
                canExecute: () =>
            {
                return !(LoginErrorOpacity || PasswordErrorOpacity);
            });

            _signUpCommand = new Command(
                execute: () =>
            {
            },
                canExecute: () =>
            {
                return false;
            });

            LoginErrorOpacity = true;
            PasswordErrorOpacity = true;
        }

        public string LargeBanner
        {
            set { SetProperty(ref _bannerLarge, value); }
            get { return _bannerLarge; }
        }

        public string SmallBanner
        {
            set { SetProperty(ref _bannerSmall, value); }
            get { return _bannerSmall; }
        }

        public string LoginEntryText
        {
            set 
            { 
                SetProperty(ref _loginEntryText, value);
                LoginErrorOpacity = !ValidateLogin();

            }
            get { return _loginEntryText; }
        }

        public string PasswordEntryText
        {
            set 
            { 
                SetProperty(ref _passwordEntryText, value);
                PasswordErrorOpacity = !ValidatePassword();
            }

            get { return _passwordEntryText; }
        }

        public string LoginErrorText
        {
            set { SetProperty(ref _loginErrorText, value); }
            get { return _loginErrorText; }
        }

        public string PasswordErrorText
        {
            set { SetProperty(ref _passwordErrorText, value); }
            get { return _passwordErrorText; }
        }

        public bool LoginErrorOpacity
        {
            get { return _loginErrorOpacity; }
            private set 
            { 
                SetProperty(ref _loginErrorOpacity, value);
                RefreshCanExecute();
            }
        }

        public bool PasswordErrorOpacity
        {
            get { return _passwordErrorOpacity; }
            private set 
            { 
                SetProperty(ref _passwordErrorOpacity, value);
                RefreshCanExecute();
            }
        }

        bool ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(_loginEntryText))
                return false;

            try
            {
                return Regex.IsMatch(_loginEntryText,
                                     @"^([a-zA-z1-9]{6,20})+$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            }
            catch(RegexMatchTimeoutException e)
            {
                return false;
            }

        }

        bool ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(_passwordEntryText))
                return false;

            try
            {
                return Regex.IsMatch(_passwordEntryText,
                                     @"^([a-zA-z]{6,20})+$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
        }

        public Command SignInCommand
        {
            get { return _signInCommand; }
        }

        public Command SignUpCommand
        {
            get { return _signUpCommand; }
        }


        void RefreshCanExecute()
        {
            ((Command)SignInCommand).ChangeCanExecute();
            ((Command)SignUpCommand).ChangeCanExecute();
        }

    }
}

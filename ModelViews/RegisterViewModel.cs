using AppBM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppBM.ModelViews
{
    public class RegisterViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private string conf_password;

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public string Conf_Password
        {
            get { return conf_password; }
            set { SetProperty(ref conf_password, value); }
        }

        public Command RegisterCommand { get; }
        public Command LoginPageCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            LoginPageCommand = new Command(OnLoginClicked);
        }

        private async void OnRegisterClicked(object obj)
        {
            IsBusy = true;

            try
            {
                if ((username == null) || (password == null) || (conf_password == null))
                {
                    await App.Current.MainPage.DisplayAlert("Warning", "Your Username or Password is Null", "Ok");
                }
                else if (password != conf_password)
                {
                    await App.Current.MainPage.DisplayAlert("Invalid", "Your Password Not Same", "Ok");
                }
                else
                {
                    await App.MyDatabase.AddUsersAsync(new ListUsers { Username = username, Password = password });

                    await App.Current.MainPage.DisplayAlert("Success","Succesfull Register","Ok");

                    App.Current.MainPage = new Login();
                }
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error",e.Message,"Ok");
            }

            IsBusy = false;
        }

        public void OnLoginClicked(object obj)
        {
            App.Current.MainPage = new Login();
        }
    }
}

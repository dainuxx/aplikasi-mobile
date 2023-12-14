using AppBM.Models;
using AppBM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppBM.ModelViews
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        // Untuk Binding Username
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        // Untuk Binding Password
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        // Untuk tombol login
        public Command LoginCommand { get; }
        public Command RegisterPageCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterPageCommand = new Command(OnSignUpClicked);
        }


        private async void OnLoginClicked(object obj)
        {
            IsBusy = true;

            try
            {
                ListUsers data = await App.MyDatabase.GetSpecificUsersAsync(username, password);
                if (data != null)
                {
                    App.Current.MainPage = new MainPage();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid", "Username or Password Not Found", "ok");
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "ok");
            }

            IsBusy = false;
        }

        public void OnSignUpClicked(object obj)
        {
            App.Current.MainPage = new Register();
        }
    }
}

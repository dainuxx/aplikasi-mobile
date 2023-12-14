using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBM.Services;
using System.IO;
using AppBM.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppBM
{
    public partial class App : Application
    {
        private static Database _database;
        public static Database MyDatabase
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "ListData.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            Application.Current.Properties["id"] = "2055";
            // Halaman Utama MainPage.xaml

            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

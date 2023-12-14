using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBM.Views.Bab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindingListString : ContentPage
    {

        public BindingListString(string title)
        {
            InitializeComponent();
            Title = title;

            List<string> items = new List<string> { "First", "Second", "Third" };
            listView.ItemsSource = items;

            listView.ItemTapped += async (sender, e) =>
            {
                await DisplayAlert("Tapped", e.Item.ToString() + " was selected","OK");
                ((ListView)sender).SelectedItem = null;
            };
        }
    }
}

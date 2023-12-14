using AppBM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBM.Views.Bab2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewBab2 : ContentPage
    {

        public ListViewBab2(string title)
        {
            InitializeComponent();
            Title = title;

            var list = new List<ListItem>();
            list.Add(new ListItem { Id = 1, Title= "Penggunaan StackLayout"});
            list.Add(new ListItem { Id = 2, Title= "Penggunaan Relative Layout"});
            list.Add(new ListItem { Id = 3, Title= "Penggunaan AbsoluteLayout"});
            list.Add(new ListItem { Id = 4, Title= "Penggunaan GridLayout"});

            MyListView.ItemsSource = list;
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ListItem;
            if (item == null)
                return;

            if (item.Id == 1)
            {
                Navigation.PushAsync(new SampleStackLayout(item.Title));
            }
            else if(item.Id == 2)
            {
                Navigation.PushAsync(new RelativeLayout(item.Title));
            }
            else if(item.Id == 3)
            {
                Navigation.PushAsync(new AbsoluteLayout(item.Title));
            }
            else
            {
                Navigation.PushAsync(new GridLayout(item.Title));
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}

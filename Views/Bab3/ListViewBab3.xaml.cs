using AppBM.Models;
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
    public partial class ListViewBab3 : ContentPage
    {

        public ListViewBab3(string title)
        {
            InitializeComponent();
            Title = title;

            var list = new List<ListItem>();
            list.Add(new ListItem { Id = 1, Title= "Penggunaan StackLayout"});
            list.Add(new ListItem { Id = 2, Title= "Penggunaan AbsoluteLayout"});

            MyListView.ItemsSource = list;
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ListItem;
            if (item == null)
                return;

            if (item.Id == 1)
            {
                Navigation.PushAsync(new BindingListString(item.Title));
            }
            else
            {
                Navigation.PushAsync(new BindingToDataModel());
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}

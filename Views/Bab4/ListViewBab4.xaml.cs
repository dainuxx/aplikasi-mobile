using AppBM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBM.Views.Bab4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewBab4 : ContentPage
    {

        public ListViewBab4(string title)
        {
            InitializeComponent();
            Title = title;

            var list = new List<ListItem>();
            list.Add(new ListItem { Id = 1, Title= "Navigation Page untuk full-page modals 1"});
            list.Add(new ListItem { Id = 2, Title= "Navigation Page untuk full-page modals 2" });
            list.Add(new ListItem { Id = 3, Title= "Menggunakan Popup untuk membuat popup alert"});
            list.Add(new ListItem { Id = 4, Title= "Menggunakan Display Action Sheets" });
            list.Add(new ListItem { Id = 5, Title= "Mengirimkan Data Antar Page" });

            MyListView.ItemsSource = list;
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ListItem;
            if (item == null)
                return;

            if(item.Id == 1)
            {
                Navigation.PushAsync(new ModalPage());
            }
            else if(item.Id == 2)
            {
                Navigation.PushAsync(new Contacts.MainModalPage());
            }
            else if (item.Id == 3)
            {
                Navigation.PushAsync(new PopupMainPage());
            }
            else if (item.Id == 4)
            {
                Navigation.PushAsync(new PopupMenu());
            }
            else
            {
                Navigation.PushAsync(new NavigationPage1());
            }
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}

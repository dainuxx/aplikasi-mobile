using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBM.Models;
using AppBM.Views.Bab4;

namespace AppBM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEditDataModel : ContentPage
	{
        // Add
		public AddEditDataModel ()
		{
			InitializeComponent ();
            Title = "Add List";
            btnSave.Text = "Save";
		}

        //Edit
        private ListItem _data;

        public AddEditDataModel(ListItem data)
        {
            InitializeComponent();
            Title = "Edit List";
            btnSave.Text = "Update";
            _data = data;
            txtTitle.Text = _data.Title;
            txtDescription.Text = _data.Description;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Add
            if (string.IsNullOrWhiteSpace(txtTitle.Text) && string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                await DisplayAlert("Warning","Input value is Null" ,"OK");
            }
            else if(_data != null)
            {
                UpdateListItem();
            }
            else
            {
                AddListItem();
            }
        }

        private async void AddListItem()
        {
            await App.MyDatabase.AddListAsync(new ListItem { Title = txtTitle.Text, Description = txtDescription.Text });

            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;

            await DisplayAlert("Success", "Item Added Successfully", "Ok");
            await Navigation.PopAsync();
        }

        private async void UpdateListItem()
        {
            _data.Title = txtTitle.Text;
            _data.Description = txtDescription.Text;

            await App.MyDatabase.UpdateListAsync(_data);

            await DisplayAlert("Success", "Item Updated Successfully", "Ok");
            await Navigation.PopAsync();
        }
    }
}
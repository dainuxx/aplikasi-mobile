using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBM.Views.Bab4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModalSecondPage : ContentPage
	{
		public ModalSecondPage ()
		{
			InitializeComponent ();
		}

        protected async void Navigate(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBM.Views.Bab1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SampleView1 : ContentPage
	{
		public SampleView1 (string title)
		{
			InitializeComponent ();
            Title = title;

            btnHello.Clicked += BtnHello_Clicked;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, e) =>
            {
                helloImg.Opacity = 0.5;
                await Task.Delay(200);
                helloImg.Opacity = 1;
            };
            helloImg.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void BtnHello_Clicked(object sender, EventArgs e)
        {
            lblDetail.Text = entryHello.Text;
        }
    }
}
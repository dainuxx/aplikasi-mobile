﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBM.Views.Bab2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridLayout : ContentPage
	{
		public GridLayout (string title)
		{
			InitializeComponent ();
            Title = title;
		}
	}
}
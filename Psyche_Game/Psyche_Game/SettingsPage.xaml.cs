﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Psyche_Game
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#F9A11B");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.WhiteSmoke;
        }
	}
}
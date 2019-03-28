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
	public partial class CustomizationPage : ContentPage
	{
		public CustomizationPage ()
		{
			InitializeComponent ();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("3B91CC"); ;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.WhiteSmoke;
        }

        async void OnLaunchClicked(object sender, EventArgs e)
        {
            GamePage GameInstance = new GamePage() { BackgroundImage = "psyche_launchpad.png"  };
            NavigationPage.SetHasNavigationBar(GameInstance, false);

            await Navigation.PushAsync(GameInstance);
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
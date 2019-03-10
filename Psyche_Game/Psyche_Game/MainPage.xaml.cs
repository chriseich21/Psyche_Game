using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Psyche_Game
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
            //await Navigation.PopAsync();
        }
        async void OnOptionsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
            //await Navigation.PopAsync();
        }
        async void OnLearnMoreClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LearnPage());
            //await Navigation.PopAsync();
        }
        async void OnExitButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
        }
    }
}

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
            LaunchPage GameInstance = new LaunchPage() { BackgroundImage = "psyche_launchpad.png"  };
            NavigationPage.SetHasNavigationBar(GameInstance, true);

            await Navigation.PushAsync(GameInstance);
            //await Navigation.PopAsync();
        }
        async void OnOptionsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
            //await Navigation.PopAsync();
        }
        async void OnLearnMoreClicked(object sender, EventArgs e)
        {
            LearnPage learnPage = new LearnPage() { BackgroundColor = Color.FromHex("1C0F2A") };
            await Navigation.PushAsync(learnPage);
            //await Navigation.PopAsync();
        }
        /*async void OnExitButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
        }*/
    }
}

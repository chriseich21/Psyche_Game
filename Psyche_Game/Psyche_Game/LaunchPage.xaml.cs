using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Psyche_Game
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LaunchPage : ContentPage
	{
        //create gameView
        CocosSharpView gameView;

        public LaunchPage()
        {
            //creta ean dlcor the launch page
            InitializeComponent();
            BackgroundColor = Color.FromHex("4698CF");
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("4698CF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.WhiteSmoke;
           
        }

        //button to launhc the game 
        async void OnLaunchClicked(object sender, EventArgs e){
            GamePage GameInstance = new GamePage() { BackgroundColor = Color.Black };
            GameInstance.Content = new GameView();
            NavigationPage.SetHasNavigationBar(GameInstance, false);
         //rcoket picture
            var rocket = this.FindByName("Rocket");
            await ((StackLayout)rocket).TranslateTo(0, -1000, 1000);

            await Navigation.PushAsync(GameInstance);
            
            //Navigation.InsertPageBefore(GameInstance, Navigation.NavigationStack[0]);
            //await Navigation.PopToRootAsync();

        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
         
            await Navigation.PopAsync();
        }
    }
}
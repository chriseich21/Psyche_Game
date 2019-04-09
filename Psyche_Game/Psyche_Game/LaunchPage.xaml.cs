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
        CocosSharpView gameView;

        public LaunchPage()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("4698CF");
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("4698CF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.WhiteSmoke;
           
        }

        async void OnLaunchClicked(object sender, EventArgs e){
            GamePage GameInstance = new GamePage() { BackgroundColor = Color.Black, Content = new GameView() { BackgroundColor=Color.Black} };
            NavigationPage.SetHasNavigationBar(GameInstance, false);
         
            var rocket = this.FindByName("Rocket");
            await ((StackLayout)rocket).TranslateTo(0, -1000, 1000);

            //  await Navigation.PushAsync(GameInstance);
            Navigation.InsertPageBefore(GameInstance, Navigation.NavigationStack[0]);
            await Navigation.PopToRootAsync();

        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
         
            await Navigation.PopAsync();
        }
    }
}
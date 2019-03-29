using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Psyche_Game
{
    public partial class App : Application
    {
        public static int Height { get; set; }
        public static int Width { get; set; }
        public static int Density { get; set; }

        public App()
        {
            InitializeComponent();


            MainPage Menu = new MainPage() { BackgroundImage = "psyche_menu_background.png" };
            NavigationPage.SetHasNavigationBar(Menu, false);
            MainPage = new NavigationPage(Menu) { BarBackgroundColor = Color.Black, BarTextColor = Color.White};
            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

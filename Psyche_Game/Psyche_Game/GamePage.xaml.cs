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
	public partial class GamePage : ContentPage
	{
        //private GameView gameView;
        public GamePage ()
		{
			InitializeComponent ();
            //gameView = gv;
            
        }

        public void TriggerWin() {
           WinPage page = new WinPage() { BackgroundColor = Color.FromHex("4698CF") };
            //Navigation.PushAsync(page);
            //Navigation.InsertPageBefore(page, Navigation.NavigationStack[0]);
            Navigation.PushModalAsync(page);
        }

        public void TriggerLoss()
        {
            LosePage page = new LosePage() { BackgroundColor = Color.FromHex("4698CF") };
            //Navigation.PushAsync(page);
            Navigation.PushModalAsync(page);
        }
	}
}
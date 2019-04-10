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
		public GamePage ()
		{
			InitializeComponent ();
            
        }
        //async
        public void TriggerWin() {
         //   WinPage page = new WinPage();
         //   await Navigation.PushAsync(page);
        }
        //async
        public async void TriggerLoss()
        {
         //   LosePage page = new LosePage();
            await Navigation.PushAsync(new LosePage());
        }
	}
}
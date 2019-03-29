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
	public partial class LearnPage : ContentPage
	{
		public LearnPage ()
		{
			InitializeComponent ();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#F17C33");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.WhiteSmoke;
        }
	}
}
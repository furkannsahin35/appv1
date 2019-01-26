using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace buddyV2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageLogin : ContentPage
	{
		public PageLogin ()
		{
			InitializeComponent ();
		}
        private async void _maingirisbutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageLogin());
            
        }
        private async void _kayıtbutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageLogin2());
        }
    }
}
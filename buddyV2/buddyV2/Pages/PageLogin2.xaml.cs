using Firebase.Xamarin.Auth;
using Plugin.Connectivity;
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
	public partial class PageLogin2 : ContentPage
	{
		public PageLogin2 ()
		{
			InitializeComponent ();
            
        }
        private async void _geri2button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageLogin());

        }
        private async void _kayitolbutton_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (!string.IsNullOrEmpty(_kullaniciadientry.Text) && !string.IsNullOrEmpty(_sifreentry.Text)
                     && !string.IsNullOrEmpty(_mailentry.Text) )
            {
                if (_sifreentry.TextColor == Color.Red)
                {
                    await DisplayAlert("UYARI", "şifre en az 6 karakter olmalıdır", "tamam");
                }
                else
                {
                    if (_mailentry.TextColor == Color.Red)
                    {
                        await DisplayAlert("uyarı", "geçerli bir mail adresi giriniz", "tamam");
                    }
                    else
                    {
                        try
                            {
                                this.IsBusy = true;
                                
                                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDNf5R90NdhXacsJvhahzlCHzGSWGUA4ns"));
                                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(_mailentry.Text, _sifreentry.Text);
                                await DisplayAlert("bilgi", "kayıt işlemi başarıyla yapıldı. giriş yapabilirsiniz", "tamam");
                                //await Navigation.PushModalAsync(new FirstScreen());
                                await Navigation.PopAsync();
                                this.IsBusy = false;
                               
                            }
                            catch (Exception)
                            {
                                await DisplayAlert("uyarı", "kayıt işlemi yapılamadı, farklı e-mail ile tekrar deneyin.", "tamam");
                                this.IsBusy = false;
                            }
                    }

                }
            }
            else
            {
                await DisplayAlert("uyarı", "boş alanları doldurunuz", "tamam");
            }
        }
            else
            {
                await DisplayAlert("uyarı", "internet bağlantısını kontrol edin", "tamam");
    }

}
    }
}
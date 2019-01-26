using buddyV2.helpers;
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
	public partial class PageLogin1 : ContentPage
	{
        public PageLogin1()
        {
            InitializeComponent();
            loginActivity.IsVisible = false;
            _mailentry.Text = Settings.GeneralSettings;
            _sifreentry.Text = Settings.GeneralSettingsPass;
        }

        private async void geributton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageLogin());

        }
        private async void girisbutton_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (string.IsNullOrEmpty(_mailentry.Text) || string.IsNullOrEmpty(_sifreentry.Text))
                {
                    await DisplayAlert("uyarı", "kullanici adı veya şifre boş olamaz", "tamam");
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


                            var loginFirebase = DependencyService.Get<IFirebaseAuthenticator>();
                            loginFirebase?.LoginWithEmailPassword(_mailentry.Text, _sifreentry.Text);
                            this.IsBusy = true;

                            loginActivity.IsVisible = true;
                            loginActivity.IsRunning = true;
                            await Task.Delay(2000);
                            if (Device.RuntimePlatform == Device.Android)
                            {
                                await Navigation.PushAsync(new MainPage());
                            }
                            else if (Device.RuntimePlatform == Device.iOS)
                            {
                                await Navigation.PushAsync(new MainPage());
                            }

                            this.IsBusy = false;

                            loginActivity.IsVisible = false;
                            loginActivity.IsRunning = false;
                        }
                        catch (Exception)
                        {
                            await DisplayAlert("uyarı", "mail adresi veya şifre yanlış", "tamam");

                        }
                    }


                }

            }
        }
    }
}

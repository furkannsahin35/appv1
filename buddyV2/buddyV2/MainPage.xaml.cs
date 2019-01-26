using buddyV2.helpers;
using buddyV2.Item;
using buddyV2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace buddyV2
{
    public partial class MainPage : MasterDetailPage
    {
        public List<ProfilPageItems> ProfilList { get; set; }
        public List<MasterDetail> MenuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            MenuList = new List<MasterDetail>();
            
            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page6 = new MasterDetail() { Title = "Profil", Icon = "menu.png", TargetType = typeof(PageUserProfile) };
            var page1 = new MasterDetail() { Title = "Ana Sayfa", Icon = "home.png", TargetType = typeof(MainPage4Share) };
            var page2 = new MasterDetail() { Title = "Zıpkın", Icon = "harpoon.png", TargetType = typeof(PageZıpkın) };
            var page3 = new MasterDetail() { Title = "CO2 tablosu", Icon = "saat.png", TargetType = typeof(PageCO2) };
            var page4 = new MasterDetail() { Title = "Agırlık Hesapları", Icon = "agirlik.png", TargetType = typeof(PageAgırlık) };
            var page5 = new MasterDetail() { Title = "Balık Çeşitler ", Icon = "balik.png", TargetType = typeof(PageBalık) }; 
            var page7 = new MasterDetail() { Title = "Item 7", Icon = "menu.png", TargetType = typeof(PageZıpkın) };
            var page8 = new MasterDetail() { Title = "Item 8", Icon = "menu.png", TargetType = typeof(PageZıpkın) };
            var page9 = new MasterDetail() { Title = "Item 9", Icon = "menu.png", TargetType = typeof(PageZıpkın) };

            // Adding menu items to menuList
            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page4);
            MenuList.Add(page5);
            MenuList.Add(page6);
            MenuList.Add(page7);
            MenuList.Add(page8);
            MenuList.Add(page9);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage4Share)));
            ProfilList = new List<ProfilPageItems>();
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterDetail)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Uyarı!", "Uygulamadan çıkmak istiyor musunuz?", "Evet", "Hayır");
                if (!result) return;
                await this.Navigation.PopAsync();
                var closer = DependencyService.Get<ICloseApplication>();
                closer?.closeApplication();
            });

            return true;
        }
    }
    }


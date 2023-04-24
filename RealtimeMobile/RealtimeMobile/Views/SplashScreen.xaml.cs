using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealtimeMobile.Views
{
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            OpenPage();
        }

        void OpenPage()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(1000);

                App.Current.MainPage = new NavigationPage(new LoginRegisterPage());
                return;
            });
        }
    }
}


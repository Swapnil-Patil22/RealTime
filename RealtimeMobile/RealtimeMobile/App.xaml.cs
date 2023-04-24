using System;
using System.Globalization;
using System.Net.Mime;
using RealtimeMobile.Helper;
using RealtimeMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealtimeMobile
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            var setlang = Manager.LanguageManager.Instance.GetLanguage();
            if (setlang == "English")
            {
                AppResources.Culture = new CultureInfo("en");
            }
            else if (setlang == "Arabic")
            {
                AppResources.Culture = new CultureInfo("ar");
            }
            else
            {
                AppResources.Culture = new CultureInfo("en");
            }
            if (string.IsNullOrEmpty(setlang))
            {
                Manager.LanguageManager.Instance.SetLanguage("Arabic");
            }
            else
            {
                Manager.LanguageManager.Instance.SetLanguage(setlang);
            }
            MainPage = new SplashScreen(); //new MainPage();
            MainPage.FlowDirection = Settings.Instance.GetFlowDirection();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}


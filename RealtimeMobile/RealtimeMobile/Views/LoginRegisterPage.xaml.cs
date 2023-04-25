using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using RealtimeMobile.Helper;
using RealtimeMobile.Manager;
using RealtimeMobile.PopUps;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace RealtimeMobile.Views
{
    public partial class LoginRegisterPage : ContentPage
    {
        public LoginRegisterPage()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            var lang = Manager.LanguageManager.Instance.GetLanguage();
            if (lang == "English")
            {
                langChangeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
            }
            else if (lang == "Arabic")
            {
                langChangeButton.HorizontalOptions = LayoutOptions.StartAndExpand;
            }
        }

        void langChangeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var popup = new LanguageSelectionPopup();
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //var setlang = LanguageManager.Instance.GetLanguage();
            //if (string.IsNullOrEmpty(setlang))
            //{
            //    Manager.LanguageManager.Instance.SetLanguage("English");
            //}
            //else if (setlang == "English")
            //{
            //    try
            //    {
            //        //LanguageManager.Instance.SetLanguage("Arabic");
            //        //AppResources.Culture = new CultureInfo("ar");
            //        CultureInfo language = new CultureInfo("ar");
            //        Thread.CurrentThread.CurrentUICulture = language;
            //        AppResources.Culture = language;
            //        langChangeButton.Text = RealtimeMobile.AppResources_ar.LanguageName;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //}
            //else
            //{
            //    LanguageManager.Instance.SetLanguage("English");
            //    AppResources.Culture = new CultureInfo("en");
            //    langChangeButton.Text = AppResources.LanguageName;
            //}
        }

        async void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
           await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        async void RegisterButton_Clicked(System.Object sender, System.EventArgs e)
        {
           await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.FlowDirection = Settings.Instance.GetFlowDirection();
            var lang = Manager.LanguageManager.Instance.GetLanguage();
            if (lang == "English")
            {
                langChangeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
            }
            else if (lang == "Arabic")
            {
                langChangeButton.HorizontalOptions = LayoutOptions.StartAndExpand;
            }
        }
    }
}


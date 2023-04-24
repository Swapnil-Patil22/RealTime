using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
        }

        void langChangeButton_Clicked(System.Object sender, System.EventArgs e)
        {

            var popup = new LanguageSelectionPopup();
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
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
    }
}


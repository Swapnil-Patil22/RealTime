using System;
using System.Collections.Generic;
using System.Globalization;
using RealtimeMobile.Helper;
using RealtimeMobile.Views;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace RealtimeMobile.PopUps
{
    public partial class LanguageSelectionPopup : PopupPage
    {
        public LanguageSelectionPopup()
        {
            InitializeComponent();
            this.FlowDirection = Settings.Instance.GetFlowDirection();
            var lang = Manager.LanguageManager.Instance.GetLanguage();
            if (lang == "English")
            {
                englishRadioButton.IsChecked = true;
            }
            else if (lang == "Arabic")
            {
                arabicRadioButton.IsChecked = true;
            }
        }

        void EnglishTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            arabicRadioButton.IsChecked = false;
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync(true);
            AppResources.Culture = new CultureInfo("en");
            Manager.LanguageManager.Instance.SetLanguage("English");
            Application.Current.MainPage = new NavigationPage(new LoginRegisterPage()
            {
                FlowDirection = Settings.Instance.GetFlowDirection()
            });
        }

        void ArabicTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            englishRadioButton.IsChecked = false;
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync(true);
            AppResources.Culture = new CultureInfo("ar");
            Manager.LanguageManager.Instance.SetLanguage("Arabic");
            Application.Current.MainPage = new NavigationPage(new LoginRegisterPage()
            {
                FlowDirection = Settings.Instance.GetFlowDirection()
            });
        }
    }
}


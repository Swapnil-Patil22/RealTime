using System;
using System.Collections.Generic;
using System.Globalization;
using RealtimeMobile.Helper;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace RealtimeMobile.PopUps
{	
	public partial class LanguageSelectionPopup : PopupPage
    {	
		public LanguageSelectionPopup ()
		{
            this.FlowDirection = Settings.Instance.GetFlowDirection();
            InitializeComponent ();
		}

        void EnglishTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            MessagingCenter.Send<LanguageSelectionPopup>(this, "refreshPage");
            arabicRadioButton.IsChecked = false;
            AppResources.Culture = new CultureInfo("en");
            Manager.LanguageManager.Instance.SetLanguage("English");
            this.FlowDirection = Settings.Instance.GetFlowDirection();
        }

        void ArabicTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            MessagingCenter.Send<LanguageSelectionPopup>(this, "refreshPage");
            englishRadioButton.IsChecked = false;
            AppResources.Culture = new CultureInfo("ar");
            Manager.LanguageManager.Instance.SetLanguage("Arabic");
            this.FlowDirection = Settings.Instance.GetFlowDirection();
        }
    }
}


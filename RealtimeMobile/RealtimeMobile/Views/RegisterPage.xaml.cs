using System;
using System.Collections.Generic;
using RealtimeMobile.Helper;
using Xamarin.Forms;

namespace RealtimeMobile.Views
{	
	public partial class RegisterPage : ContentPage
	{	
		public RegisterPage ()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            this.FlowDirection = Settings.Instance.GetFlowDirection();
            InitializeComponent ();
            var lang = Manager.LanguageManager.Instance.GetLanguage();
            if (lang == "English")
            {
                backBtn.Rotation = 0;
                fullNameEntry.HorizontalTextAlignment = TextAlignment.Start;
                idNumberEntry.HorizontalTextAlignment = TextAlignment.Start;
                emailEntry.HorizontalTextAlignment = TextAlignment.Start;
                mobileNumberEntry.HorizontalTextAlignment = TextAlignment.Start;
                passwordEntry.HorizontalTextAlignment = TextAlignment.Start;
                confirmPasswordEntry.HorizontalTextAlignment = TextAlignment.Start;
            }
            else if (lang == "Arabic")
            {
                backBtn.Rotation = 180;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fullNameEntry.HorizontalTextAlignment = TextAlignment.End;
                    idNumberEntry.HorizontalTextAlignment = TextAlignment.End;
                    emailEntry.HorizontalTextAlignment = TextAlignment.End;
                    mobileNumberEntry.HorizontalTextAlignment = TextAlignment.End;
                    passwordEntry.HorizontalTextAlignment = TextAlignment.End;
                    confirmPasswordEntry.HorizontalTextAlignment = TextAlignment.End;
                }
            }
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}


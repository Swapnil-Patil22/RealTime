using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using RealtimeMobile.Helper;
using RealtimeMobile.Models;
using RealtimeMobile.PopUps;
using Xamarin.Forms;

namespace RealtimeMobile.Views
{	
	public partial class LoginPage : ContentPage
    {
        public static bool IsRememberMe = false;
        private CountryModel SelectedCountry;

        public LoginPage ()
		{
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            this.FlowDirection = Settings.Instance.GetFlowDirection();
            InitializeComponent ();
            CountrySelectedCommand = new Command(country => ExecuteCountrySelectedCommand(country as CountryModel));
            MessagingCenter.Subscribe<LanguageSelectionPopup>(this, "refreshPage", (sender) =>
            {
                this.FlowDirection = Settings.Instance.GetFlowDirection();
            });
            var lang = Manager.LanguageManager.Instance.GetLanguage();
            if (lang == "English")
            {
                backbtn.Rotation = 0;
            }
            else if (lang == "Arabic")
            {
                backbtn.Rotation = 180;
            }
        }

        private void ExecuteCountrySelectedCommand(CountryModel countryModel)
        {
            SelectedCountry = countryModel;
            countryFlagImage.Source = countryModel.FlagUrl;
        }

        public ICommand CountrySelectedCommand { get; private set; }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var popup = new CountryPopup(SelectedCountry)
            {
                CountrySelectedCommand = CountrySelectedCommand
            };
             Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
        }

        void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            if (IsRememberMe)
            {
                IsRememberMe = !IsRememberMe;
                rememberMeBtn.ImageSource = "squarerounded.png";
            }
            else
            {
                IsRememberMe = !IsRememberMe;
                rememberMeBtn.ImageSource = "";
            }
        }

       async void SignUp_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        void langChangeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var popup = new LanguageSelectionPopup();
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
        }
    }


    public class ShowPasswordTriggerAction : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        bool _hidePassword = true;

        public bool HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HidePassword)));
                }
            }
            get => _hidePassword;
        }

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}


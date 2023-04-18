using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RealtimeMobile.Models;
using RealtimeMobile.PopUps;
using RealtimeMobile.Utils;
using Xamarin.Forms;

namespace RealtimeMobile.ViewModels
{
	public class MainPageViewModel : BaseViewModel
    {

        private CountryModel _selectedCountry;

        public MainPageViewModel()
        {
            SelectedCountry = CountryUtils.GetCountryModelByName("United States");
            ShowPopupCommand = new Command(async _ => await ExecuteShowPopupCommand());
            CountrySelectedCommand = new Command(country => ExecuteCountrySelectedCommand(country as CountryModel));
        }

        public CountryModel SelectedCountry
        {
            get => _selectedCountry;
            set => SetProperty(ref _selectedCountry, value);
        }


        public ICommand ShowPopupCommand { get; }
        public ICommand CountrySelectedCommand { get; }

        private Task ExecuteShowPopupCommand()
        {
            var popup = new CountryPopup(SelectedCountry)
            {
                CountrySelectedCommand = CountrySelectedCommand
            };
            return Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
        }

        private void ExecuteCountrySelectedCommand(CountryModel country)
        {
            SelectedCountry = country;
        }
    }
}

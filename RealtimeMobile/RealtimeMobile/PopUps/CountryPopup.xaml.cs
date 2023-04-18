using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RealtimeMobile.CustomControls;
using RealtimeMobile.Models;
using RealtimeMobile.Utils;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
namespace RealtimeMobile.PopUps
{	
	public partial class CountryPopup : PopupPage
    {
        private static List<CountryModel> _countries;
        private CountryModel _selectedCountry;

        public CountryPopup(CountryModel selectedCountry)
        {
            InitializeComponent();
            if (_countries == null || !_countries.Any())
            {
                LoadCountries();
            }
            VisibleCountries = new ObservableCollection<CountryModel>(_countries);

            SelectedCountry = selectedCountry;
            CommonCountriesList.SetBinding(ListView.ItemsSourceProperty, new Binding(nameof(VisibleCountries), source: this));
        }

        public ICommand CountrySelectedCommand { get; set; }

        public ObservableCollection<CountryModel> VisibleCountries { get; }

        public CountryModel SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }

        private void CloseBtn_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            CountrySelectedCommand?.Execute(SelectedCountry);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void LoadCountries()
        {
            _countries = new List<CountryModel>();
            var isoCountries = CountryUtils.GetCountriesByIso3166();
            _countries.AddRange(isoCountries.Select(c => new CountryModel
            {
                CountryName = c.EnglishName,
            }));
        }

        private void CommonCountriesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedCountry = e.SelectedItem as CountryModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}

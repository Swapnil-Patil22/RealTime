using System;
using System.Collections.Generic;
using RealtimeMobile.Models;
using Xamarin.Forms;

namespace RealtimeMobile.CustomControls
{	
	public partial class CountryControl : StackLayout
    {
        public static readonly BindableProperty CountryProperty = BindableProperty.Create(
            nameof(Country),
            typeof(CountryModel),
            typeof(CountryControl),
            default,
            BindingMode.TwoWay,
            propertyChanged: (bindable, value, newValue) => (bindable as CountryControl)?.UpdateCountry(newValue as CountryModel));

        public CountryModel Country
        {
            get => (CountryModel)GetValue(CountryProperty);
            set => SetValue(CountryProperty, value);
        }

        public CountryControl()
        {
            InitializeComponent();
        }

        private void UpdateCountry(CountryModel model)
        {
            CountryNameLabel.Text = model?.CountryName;
        }
    }
}

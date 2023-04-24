using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealtimeMobile.Views;
using Xamarin.Forms;

namespace RealtimeMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}


using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RealtimeMobile.Views
{	
	public partial class RegisterPage : ContentPage
	{	
		public RegisterPage ()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
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


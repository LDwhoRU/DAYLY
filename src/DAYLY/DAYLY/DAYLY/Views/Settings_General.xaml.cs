using System;
using System.Collections.Generic;
using DAYLY.Views;
using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_General : ContentPage
    {
        public static Default settingsDefault = new Default();
        
        public Settings_General()
        {
            InitializeComponent();
            BindingContext = settingsDefault;
        }

        async void OnAppThemeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_AppTheme());
        }

        protected override void OnAppearing()
        {
            InitializeComponent();
        }
    }
}
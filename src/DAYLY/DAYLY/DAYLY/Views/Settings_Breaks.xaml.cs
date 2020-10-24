using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_Breaks : ContentPage
    {
        public Settings_Breaks()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsDefault;
        }

        async void OnDefaultBreakDurationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DefaultBreakDuration());
        }

        protected override void OnAppearing()
        {
            InitializeComponent();
        }
    }
}

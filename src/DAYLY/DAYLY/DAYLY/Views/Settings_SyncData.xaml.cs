﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_SyncData : ContentPage
    {
        public Settings_SyncData()
        {
            InitializeComponent();
            BindingContext = Settings_General.settingsDefault;
        }

        async void OnSyncIntervalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_SyncInterval());
        }

        protected override void OnAppearing()
        {
            InitializeComponent();
        }
    }
}

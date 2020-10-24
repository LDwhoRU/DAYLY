using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using DAYLY.Views;
using DAYLY.ViewModels;

namespace DAYLY.Views
{
    public partial class Settings_Main : ContentPage
    {
        public static SettingsViewModel settingsViewModel = new SettingsViewModel();

        public Settings_Main()
        {
            InitializeComponent();
            settingsViewModel.Initialise(Navigation);
            BindingContext = settingsViewModel;
        }

        async void OnGeneralSettingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_General());
        }

        async void OnRemindersSettingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_Reminders());
        }

        async void OnAutomationSettingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_Automation());
        }

        async void OnBreaksSettingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_Breaks());
        }

        async void OnSyncDataSettingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_SyncData());
        }
    }

    
}

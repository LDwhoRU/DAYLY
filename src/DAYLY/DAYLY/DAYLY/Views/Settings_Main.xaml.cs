using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using DAYLY.Views;

namespace DAYLY.Views
{
    public partial class Settings_Main : ContentPage
    {
        public Settings_Main()
        {
            InitializeComponent();
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

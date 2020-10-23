using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_Reminders : ContentPage
    {
        public Settings_Reminders()
        {
            InitializeComponent();
            BindingContext = Settings_General.settingsDefault;
        }

        async void OnDailyReminderTimeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DailyReminderTime());
        }

        async void OnEventAlertClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DailyReminderTime());
        }

        async void OnTasksReminderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DailyReminderTime());
        }

        async void OnReminderRingtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DailyReminderTime());
        }

        protected override void OnAppearing()
        {
            InitializeComponent();
        }
    }
}

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
            if (Settings_General.settingsDefault.TimeFormatStr.Substring(0, 2) == "12")
            {
                await Navigation.PushAsync(new Settings_DailyReminderTime());
            }
            else
            {
                await Navigation.PushAsync(new Settings_DailyReminderTime24());
            }
        }

        async void OnDefaultEventAlertClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DefaultEventAlert());
        }

        async void OnTasksReminderClicked(object sender, EventArgs e)
        {
            if (Settings_General.settingsDefault.TimeFormatStr.Substring(0, 2) == "12")
            {
                await Navigation.PushAsync(new Settings_TasksReminder());
            }
            else
            {
                await Navigation.PushAsync(new Settings_TasksReminder24());
            }
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

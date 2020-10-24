using System;
using System.Collections.Generic;
using System.Diagnostics;
using DAYLY.Views;
using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_General : ContentPage
    {
        public Settings_General()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsDefault;
        }

        async void OnAppThemeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_AppTheme());
        }

        async void OnFirstDayOfWeekClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_FirstDayOfWeek());
        }

        async void OnDayStartTimeClicked(object sender, EventArgs e)
        {
            if (Settings_Main.settingsDefault.TimeFormatStr.Substring(0,2) == "12")
            {
                await Navigation.PushAsync(new Settings_DayStartTime());
            } else
            {
                await Navigation.PushAsync(new Settings_DayStartTime24());
            }
        }

        async void OnDefaultEventDurationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DefaultEventDuration());
        }

        async void OnDefaultViewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_DefaultView());
        }

        async void OnShowWeekNumbersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_ShowWeekNumbers());
        }

        async void OnTimeFormatClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_TimeFormat());
        }

        async void OnAppLockClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_AppLock());
        }

        async void OnCountdownModeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_CountdownMode());
        }

        protected override void OnAppearing()
        {
            InitializeComponent();
        }
    }
}
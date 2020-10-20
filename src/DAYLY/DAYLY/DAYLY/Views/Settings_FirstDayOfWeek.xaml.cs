using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_FirstDayOfWeek : ContentPage
    {
        public Settings_FirstDayOfWeek()
        {
            InitializeComponent();
            BindingContext = Settings_General.settingsDefault;
        }

        private void OnSaturdayClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 0); ;
            Settings_General.settingsDefault.FirstDayOfWeekStr = "Saturday";
            Settings_General.settingsDefault.FirstDayOfWeekPos = "0";
        }

        private void OnSundayClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 3);
            Settings_General.settingsDefault.FirstDayOfWeekStr = "Sunday";
            Settings_General.settingsDefault.FirstDayOfWeekPos = "3";
        }

        private void OnMondayClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 6);
            Settings_General.settingsDefault.FirstDayOfWeekStr = "Monday";
            Settings_General.settingsDefault.FirstDayOfWeekPos = "6";
        }
    }
}

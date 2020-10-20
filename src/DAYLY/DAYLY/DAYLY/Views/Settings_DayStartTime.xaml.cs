using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_DayStartTime : ContentPage
    {
        public Settings_DayStartTime()
        {
            InitializeComponent();
            BindingContext = Settings_General.settingsDefault;
        }

        private void On6AMClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 0);
            Settings_General.settingsDefault.DayStartTime = new TimeSpan(6, 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = "0";
        }

        private void On7AMClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 3);
            Settings_General.settingsDefault.DayStartTime = new TimeSpan(7, 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = "3";
        }

        private void On8AMClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 6);
            Settings_General.settingsDefault.DayStartTime = new TimeSpan(8, 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = "6";
        }

        private void On9AMClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 9);
            Settings_General.settingsDefault.DayStartTime = new TimeSpan(9, 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = "9";
        }

        private void On10AMClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 12);
            Settings_General.settingsDefault.DayStartTime = new TimeSpan(10, 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = "12";
        }

        private void On11AMClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 15);
            Settings_General.settingsDefault.DayStartTime = new TimeSpan(11, 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = "15";
        }

        private void On12PMClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 18);
            Settings_General.settingsDefault.DayStartTime = new TimeSpan(12, 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = "18";
        }

        private string getTimeFormat(TimeSpan tsTime)
        {
            string startTime = string.Empty;
            string tFormat = Settings_General.settingsDefault.TimeFormat;

            if (tFormat.Substring(0, 2) == "12")
            {
                startTime = tsTime.ToString().Substring(0, 5);
                
                if (startTime.Substring(0,1) == "0")
                {
                    startTime = startTime.Substring(1) + " AM";
                    Debug.WriteLine(startTime);
                }
                else if (startTime.Substring(0, 2) == "12")
                {
                    startTime = startTime.Substring(0, 5) + " PM";
                }
                else
                {
                    startTime = startTime.Substring(0, 5) + " AM";
                }
            } else if (tFormat.Substring(0, 2) == "24")
            {
                startTime = tsTime.ToString().Substring(0, 5);
            }

            Debug.WriteLine("test value: " + new TimeSpan(8, 0, 0).ToString().Substring(0, 5));
            return startTime;
        }
    }
}

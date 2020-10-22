using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DAYLY.Views;

namespace DAYLY.ViewModels
{
    public class Settings_DayStartTimeViewModel : INotifyPropertyChanged
    {
        public Settings_DayStartTimeViewModel()
        {
            ChangeDayStartTime = new Command<string>(changeDayStartTime);
        }

        public ICommand ChangeDayStartTime { get; }

        void changeDayStartTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');

            Settings_General.settingsDefault.DayStartTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = timeStr[1];
            OnPropertyChanged(nameof(DayStartTimePos));
        }

        public string DayStartTimePos => $"{Settings_General.settingsDefault.DayStartTimePos}";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static string getTimeFormat(TimeSpan tsTime)
        {
            string startTime = string.Empty;
            string tFormat = Settings_General.settingsDefault.TimeFormat;

            if (tFormat.Substring(0, 2) == "12")
            {
                startTime = tsTime.ToString().Substring(0, 5);

                if (startTime.Substring(0, 1) == "0")
                {
                    startTime = startTime.Substring(1) + " AM";
                }
                else if (startTime.Substring(0, 2) == "12")
                {
                    startTime = startTime.Substring(0, 5) + " PM";
                }
                else
                {
                    startTime = startTime.Substring(0, 5) + " AM";
                }
            }
            else if (tFormat.Substring(0, 2) == "24")
            {
                startTime = tsTime.ToString().Substring(0, 5);
            }

            return startTime;
        }
    }
}

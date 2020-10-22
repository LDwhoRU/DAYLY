using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DAYLY.Views;

namespace DAYLY.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
            ChangeFirstDayOfWeekCommand = new Command<string>(changeFirstDayOfWeek);
            ChangeDayStartTime = new Command<string>(changeDayStartTime);
            ChangeDefaultEventDurationCommand = new Command<string>(changeDefaultEvenDuration);
        }

        public ICommand ChangeFirstDayOfWeekCommand { get; }
        public ICommand ChangeDayStartTime { get; }
        public ICommand ChangeDefaultEventDurationCommand { get; }

        void changeFirstDayOfWeek(string newDay)
        {
            string[] dayStr = newDay.Split(',');
            Settings_General.settingsDefault.FirstDayOfWeekStr = dayStr[0];
            Settings_General.settingsDefault.FirstDayOfWeekPos = dayStr[1];
            OnPropertyChanged(nameof(FirstDayOfWeekPos));
        }

        void changeDayStartTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');

            Settings_General.settingsDefault.DayStartTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = timeStr[1];
            OnPropertyChanged(nameof(DayStartTimePos));
        }

        void changeDefaultEvenDuration(string newDuration)
        {
            string[] posStr = newDuration.Split(',');
            Settings_General.settingsDefault.DefaultEventDuration = Default.stringToInt(posStr[0]);
            Settings_General.settingsDefault.DefaultEventDurationPos = posStr[1];
            Settings_General.settingsDefault.DefaultEventDurationStr = posStr[0] + " minutes";
            OnPropertyChanged(nameof(DefaultEventDurationPos));
        }

        public string FirstDayOfWeekPos => $"{Settings_General.settingsDefault.FirstDayOfWeekPos}";
        public string DayStartTimePos => $"{Settings_General.settingsDefault.DayStartTimePos}";
        public string DefaultEventDurationPos => $"{Settings_General.settingsDefault.DefaultEventDurationPos}";

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

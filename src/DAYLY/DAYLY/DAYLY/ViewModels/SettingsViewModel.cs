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
            ChangeAppThemeCommand = new Command<string>(changeAppTheme);
            ChangeFirstDayOfWeekCommand = new Command<string>(changeFirstDayOfWeek);
            ChangeDayStartTime = new Command<string>(changeDayStartTime);
            ChangeDefaultEventDurationCommand = new Command<string>(changeDefaultEvenDuration);
            ChangeDefaultViewCommand = new Command<string>(changeDefaultView);
            ChangeShowWeekNumbersCommand = new Command<string>(changeShowWeekNumbers);
            ChangeTimeFormatCommand = new Command<string>(changeTimeFormat);
        }

        public ICommand ChangeAppThemeCommand { get; }
        public ICommand ChangeFirstDayOfWeekCommand { get; }
        public ICommand ChangeDayStartTime { get; }
        public ICommand ChangeDefaultEventDurationCommand { get; }
        public ICommand ChangeDefaultViewCommand { get; }
        public ICommand ChangeShowWeekNumbersCommand { get; }
        public ICommand ChangeTimeFormatCommand { get; }


        private void changeAppTheme(string newTheme)
        {
            string[] themeStr = newTheme.Split(',');
            Settings_General.settingsDefault.AppThemeStr = themeStr[0];
            Settings_General.settingsDefault.AppThemePos = themeStr[1];
            OnPropertyChanged(nameof(AppThemePos));

        }

        private void changeFirstDayOfWeek(string newDay)
        {
            string[] dayStr = newDay.Split(',');
            Settings_General.settingsDefault.FirstDayOfWeekStr = dayStr[0];
            Settings_General.settingsDefault.FirstDayOfWeekPos = dayStr[1];
            OnPropertyChanged(nameof(FirstDayOfWeekPos));
        }

        private void changeDayStartTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');

            Settings_General.settingsDefault.DayStartTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DayStartTimePos = timeStr[1];
            OnPropertyChanged(nameof(DayStartTimePos));
        }

        private void changeDefaultEvenDuration(string newDuration)
        {
            string[] posStr = newDuration.Split(',');
            Settings_General.settingsDefault.DefaultEventDuration = Default.stringToInt(posStr[0]);
            Settings_General.settingsDefault.DefaultEventDurationStr = posStr[0] + " minutes";
            Settings_General.settingsDefault.DefaultEventDurationPos = posStr[1];
            OnPropertyChanged(nameof(DefaultEventDurationPos));
        }

        private void changeDefaultView(string newView)
        {
            string[] viewStr = newView.Split(',');
            Settings_General.settingsDefault.DefaultViewStr = viewStr[0];
            Settings_General.settingsDefault.DefaultViewPos = viewStr[1];
            OnPropertyChanged(nameof(DefaultViewPos));
        }

        private void changeShowWeekNumbers(string newView)
        {
            string[] viewStr = newView.Split(',');
            Settings_General.settingsDefault.ShowWeekNumbersStr = viewStr[0];
            Settings_General.settingsDefault.ShowWeekNumbersPos = viewStr[1];
            OnPropertyChanged(nameof(ShowWeekNumbersPos));
        }

        private void changeTimeFormat(string newTimeF)
        {
            string[] timeFStr = newTimeF.Split(',');
            Settings_General.settingsDefault.TimeFormatStr = timeFStr[0] + " hour";
            Settings_General.settingsDefault.TimeFormatPos = timeFStr[1];
            OnPropertyChanged(nameof(TimeFormatPos));
        }

        public string AppThemePos => $"{Settings_General.settingsDefault.AppThemePos}";
        public string FirstDayOfWeekPos => $"{Settings_General.settingsDefault.FirstDayOfWeekPos}";
        public string DayStartTimePos => $"{Settings_General.settingsDefault.DayStartTimePos}";
        public string DefaultEventDurationPos => $"{Settings_General.settingsDefault.DefaultEventDurationPos}";
        public string DefaultViewPos => $"{Settings_General.settingsDefault.DefaultViewPos}";
        public string ShowWeekNumbersPos => $"{Settings_General.settingsDefault.ShowWeekNumbersPos}";
        public string TimeFormatPos => $"{Settings_General.settingsDefault.TimeFormatPos}";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static string getTimeFormat(TimeSpan tsTime)
        {
            string startTime = string.Empty;
            string tFormat = Settings_General.settingsDefault.TimeFormatStr;

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

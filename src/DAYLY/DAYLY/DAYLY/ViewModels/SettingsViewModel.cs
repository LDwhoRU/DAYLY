using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DAYLY.Views;
using System.Diagnostics;

namespace DAYLY.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private const int DAY_HOURS = 24;
        private const int HOUR_MINUTES = 60;

        public SettingsViewModel()
        {
            ChangeAppThemeCommand = new Command<string>(changeAppTheme);
            ChangeFirstDayOfWeekCommand = new Command<string>(changeFirstDayOfWeek);
            ChangeDayStartTimeCommand = new Command<string>(changeDayStartTime);
            ChangeDefaultEventDurationCommand = new Command<string>(changeDefaultEvenDuration);
            ChangeDefaultViewCommand = new Command<string>(changeDefaultView);
            ChangeShowWeekNumbersCommand = new Command<string>(changeShowWeekNumbers);
            ChangeTimeFormatCommand = new Command<string>(changeTimeFormat);
            ChangeAppLockCommand = new Command<string>(changeAppLock);
            ChangeCountdownModeCommand = new Command<string>(changeCountdownMode);
            ChangeDailyReminderTimeCommand = new Command<string>(changeDailyReminderTime);
            ChangeDefaultAlertTimeCommand = new Command<string>(changeDefaultAlertTime);
            ChangeTasksReminderCommand = new Command<string>(changeTasksReminder);
            ChangeReminderRingtoneCommand = new Command<string>(changeReminderRingtone);
            ChangeReminderDefaultCommand = new Command<string>(changeReminderDefault);
        }

        public ICommand ChangeAppThemeCommand { get; }
        public ICommand ChangeFirstDayOfWeekCommand { get; }
        public ICommand ChangeDayStartTimeCommand { get; }
        public ICommand ChangeDefaultEventDurationCommand { get; }
        public ICommand ChangeDefaultViewCommand { get; }
        public ICommand ChangeShowWeekNumbersCommand { get; }
        public ICommand ChangeTimeFormatCommand { get; }
        public ICommand ChangeAppLockCommand { get; }
        public ICommand ChangeCountdownModeCommand { get; }
        public ICommand ChangeDailyReminderTimeCommand { get; }
        public ICommand ChangeDefaultAlertTimeCommand { get; }
        public ICommand ChangeTasksReminderCommand { get; }
        public ICommand ChangeReminderRingtoneCommand { get; }
        public ICommand ChangeReminderDefaultCommand { get; }

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
            Settings_General.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_General.settingsDefault.DayStartTime);
            Settings_General.settingsDefault.DailyReminderTimeStr = getTimeFormat(Settings_General.settingsDefault.DailyReminderTime);
            Settings_General.settingsDefault.TasksReminderStr = getTimeFormat(Settings_General.settingsDefault.TasksReminderTime) + " on the day";
            Settings_General.settingsDefault.ReminderDefaultMorningStr = getTimeFormat(Settings_General.settingsDefault.ReminderDefaultMorning);
            Settings_General.settingsDefault.ReminderDefaultAfternoonStr = getTimeFormat(Settings_General.settingsDefault.ReminderDefaultAfternoon);
            Settings_General.settingsDefault.ReminderDefaultEveningStr = getTimeFormat(Settings_General.settingsDefault.ReminderDefaultEvening);
            OnPropertyChanged(nameof(TimeFormatPos));
        }

        private void changeAppLock(string newLock)
        {
            string[] lockStr = newLock.Split(',');
            Settings_General.settingsDefault.AppLockStr = lockStr[0];
            Settings_General.settingsDefault.AppLockPos = lockStr[1];
            OnPropertyChanged(nameof(AppLockPos));
        }

        private void changeCountdownMode(string newMode)
        {
            string[] modeStr = newMode.Split(',');
            Settings_General.settingsDefault.CountdownModeStr = modeStr[0];
            Settings_General.settingsDefault.CountdownModePos = modeStr[1];
            OnPropertyChanged(nameof(CountdownModePos));
        }

        private void changeDailyReminderTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            Settings_General.settingsDefault.DailyReminderTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_General.settingsDefault.DailyReminderTimeStr = getTimeFormat(Settings_General.settingsDefault.DailyReminderTime);
            Settings_General.settingsDefault.DailyReminderTimePos = timeStr[1];
            OnPropertyChanged(nameof(DailyReminderTimePos));
        }

        private void changeDefaultAlertTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            Settings_General.settingsDefault.DefaultEventAlertMins = getMinutes(timeStr[0], timeStr[1]);
            Settings_General.settingsDefault.DefaultEventAlertStr = timeStr[0] + " " + timeStr[1] + " prior";
            Settings_General.settingsDefault.DefaultEventAlertPos = timeStr[2];
            OnPropertyChanged(nameof(DefaultAlertTimePos));
        }

        private void changeTasksReminder(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            Settings_General.settingsDefault.TasksReminderTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_General.settingsDefault.TasksReminderStr = getTimeFormat(Settings_General.settingsDefault.TasksReminderTime) + " on the day";
            Settings_General.settingsDefault.TasksReminderPos = timeStr[1];
            OnPropertyChanged(nameof(TasksReminderPos));
        }

        private void changeReminderRingtone(string newTone)
        {
            string[] toneStr = newTone.Split(',');
            Settings_General.settingsDefault.ReminderRingtoneStr = toneStr[0];
            Settings_General.settingsDefault.ReminderRingtonePos = toneStr[1];
            OnPropertyChanged(nameof(ReminderRingtonePos));
        }

        private void changeReminderDefault(string newReminder)
        {
            string[] reminderStr = newReminder.Split(',');

            if (reminderStr[0] == "Morning")
            {
                Settings_General.settingsDefault.ReminderDefaultMorning = new TimeSpan(Default.stringToInt(reminderStr[1]), 0, 0);
                Settings_General.settingsDefault.ReminderDefaultMorningStr = getTimeFormat(Settings_General.settingsDefault.ReminderDefaultMorning);
                Settings_General.settingsDefault.ReminderDefaultMorningPos = reminderStr[2];
                OnPropertyChanged(nameof(ReminderDefaultMorningPos));
            }
            else if (reminderStr[0] == "Afternoon")
            {
                Settings_General.settingsDefault.ReminderDefaultAfternoon = new TimeSpan(Default.stringToInt(reminderStr[1]), 0, 0);
                Settings_General.settingsDefault.ReminderDefaultAfternoonStr = getTimeFormat(Settings_General.settingsDefault.ReminderDefaultAfternoon);
                Settings_General.settingsDefault.ReminderDefaultAfternoonPos = reminderStr[2];
                OnPropertyChanged(nameof(ReminderDefaultAfternoonPos));
            }
            else if (reminderStr[0] == "Evening")
            {
                Settings_General.settingsDefault.ReminderDefaultEvening = new TimeSpan(Default.stringToInt(reminderStr[1]), 0, 0);
                Settings_General.settingsDefault.ReminderDefaultEveningStr = getTimeFormat(Settings_General.settingsDefault.ReminderDefaultEvening);
                Settings_General.settingsDefault.ReminderDefaultEveningPos = reminderStr[2];
                OnPropertyChanged(nameof(ReminderDefaultEveningPos));
            }
        }

        public string AppThemePos => $"{Settings_General.settingsDefault.AppThemePos}";
        public string FirstDayOfWeekPos => $"{Settings_General.settingsDefault.FirstDayOfWeekPos}";
        public string DayStartTimePos => $"{Settings_General.settingsDefault.DayStartTimePos}";
        public string DefaultEventDurationPos => $"{Settings_General.settingsDefault.DefaultEventDurationPos}";
        public string DefaultViewPos => $"{Settings_General.settingsDefault.DefaultViewPos}";
        public string ShowWeekNumbersPos => $"{Settings_General.settingsDefault.ShowWeekNumbersPos}";
        public string TimeFormatPos => $"{Settings_General.settingsDefault.TimeFormatPos}";
        public string AppLockPos => $"{Settings_General.settingsDefault.AppLockPos}";
        public string CountdownModePos => $"{Settings_General.settingsDefault.CountdownModePos}";
        public string DailyReminderTimePos => $"{Settings_General.settingsDefault.DailyReminderTimePos}";
        public string DefaultAlertTimePos => $"{Settings_General.settingsDefault.DefaultEventAlertPos}";
        public string TasksReminderPos => $"{Settings_General.settingsDefault.TasksReminderPos}";
        public string ReminderRingtonePos => $"{Settings_General.settingsDefault.ReminderRingtonePos}";
        public string ReminderDefaultMorningPos => $"{Settings_General.settingsDefault.ReminderDefaultMorningPos}";
        public string ReminderDefaultAfternoonPos => $"{Settings_General.settingsDefault.ReminderDefaultAfternoonPos}";
        public string ReminderDefaultEveningPos => $"{Settings_General.settingsDefault.ReminderDefaultEveningPos}";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string getTimeFormat(TimeSpan tsTime)
        {
            int twelthHour = 12;
            string startTime = tsTime.ToString().Substring(0, 5);
            string tFormat = Settings_General.settingsDefault.TimeFormatStr;

            if (tFormat.Substring(0, 2) == "12")
            {
                if (tsTime.Hours < 12)
                {
                    startTime = startTime.Substring(1) + " AM";
                }
                else if (tsTime.Hours == 12)
                {
                    startTime = startTime.Substring(0, 5) + " PM";
                }
                else
                {
                    TimeSpan temp = new TimeSpan(tsTime.Hours - twelthHour, 0, 0);
                    startTime = temp.ToString().Substring(1, 4) + " PM";
                }
            }

            return startTime;
        }

        private int getMinutes(string value, string unit)
        {
            int mins = 0;

            if (unit == "minutes")
            {
                mins = Default.stringToInt(value);
            }
            else if (unit == "hour" || unit == "hours")
            {
                mins = Default.stringToInt(value) * HOUR_MINUTES;
            }
            else if (unit == "day" || unit == "days")
            {
                mins = Default.stringToInt(value) * DAY_HOURS * HOUR_MINUTES;
            }

            return mins;
        }
    }
}

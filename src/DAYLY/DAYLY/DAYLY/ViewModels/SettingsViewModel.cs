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
            ChangeDefaultBreakDurationCommand = new Command<string>(changeDefaultBreakDuration);
            ChangeSyncIntervalCommand = new Command<string>(changeSyncInterval);
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
        public ICommand ChangeDefaultBreakDurationCommand { get; }
        public ICommand ChangeSyncIntervalCommand { get; }

        private void changeAppTheme(string newTheme)
        {
            string[] themeStr = newTheme.Split(',');
            Settings_Main.settingsDefault.AppThemeStr = themeStr[0];
            Settings_Main.settingsDefault.AppThemePos = themeStr[1];
            OnPropertyChanged(nameof(AppThemePos));

        }

        private void changeFirstDayOfWeek(string newDay)
        {
            string[] dayStr = newDay.Split(',');
            Settings_Main.settingsDefault.FirstDayOfWeekStr = dayStr[0];
            Settings_Main.settingsDefault.FirstDayOfWeekPos = dayStr[1];
            OnPropertyChanged(nameof(FirstDayOfWeekPos));
        }

        private void changeDayStartTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');

            Settings_Main.settingsDefault.DayStartTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_Main.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_Main.settingsDefault.DayStartTime);
            Settings_Main.settingsDefault.DayStartTimePos = timeStr[1];
            OnPropertyChanged(nameof(DayStartTimePos));
        }

        private void changeDefaultEvenDuration(string newDuration)
        {
            string[] posStr = newDuration.Split(',');
            Settings_Main.settingsDefault.DefaultEventDuration = Default.stringToInt(posStr[0]);
            Settings_Main.settingsDefault.DefaultEventDurationStr = posStr[0] + " minutes";
            Settings_Main.settingsDefault.DefaultEventDurationPos = posStr[1];
            OnPropertyChanged(nameof(DefaultEventDurationPos));
        }

        private void changeDefaultView(string newView)
        {
            string[] viewStr = newView.Split(',');
            Settings_Main.settingsDefault.DefaultViewStr = viewStr[0];
            Settings_Main.settingsDefault.DefaultViewPos = viewStr[1];
            OnPropertyChanged(nameof(DefaultViewPos));
        }

        private void changeShowWeekNumbers(string newView)
        {
            string[] viewStr = newView.Split(',');
            Settings_Main.settingsDefault.ShowWeekNumbersStr = viewStr[0];
            Settings_Main.settingsDefault.ShowWeekNumbersPos = viewStr[1];
            OnPropertyChanged(nameof(ShowWeekNumbersPos));
        }

        private void changeTimeFormat(string newTimeF)
        {
            string[] timeFStr = newTimeF.Split(',');
            Settings_Main.settingsDefault.TimeFormatStr = timeFStr[0] + " hour";
            Settings_Main.settingsDefault.TimeFormatPos = timeFStr[1];
            Settings_Main.settingsDefault.DayStartTimeStr = getTimeFormat(Settings_Main.settingsDefault.DayStartTime);
            Settings_Main.settingsDefault.DailyReminderTimeStr = getTimeFormat(Settings_Main.settingsDefault.DailyReminderTime);
            Settings_Main.settingsDefault.TasksReminderStr = getTimeFormat(Settings_Main.settingsDefault.TasksReminderTime) + " on the day";
            Settings_Main.settingsDefault.ReminderDefaultMorningStr = getTimeFormat(Settings_Main.settingsDefault.ReminderDefaultMorning);
            Settings_Main.settingsDefault.ReminderDefaultAfternoonStr = getTimeFormat(Settings_Main.settingsDefault.ReminderDefaultAfternoon);
            Settings_Main.settingsDefault.ReminderDefaultEveningStr = getTimeFormat(Settings_Main.settingsDefault.ReminderDefaultEvening);
            OnPropertyChanged(nameof(TimeFormatPos));
        }

        private void changeAppLock(string newLock)
        {
            string[] lockStr = newLock.Split(',');
            Settings_Main.settingsDefault.AppLockStr = lockStr[0];
            Settings_Main.settingsDefault.AppLockPos = lockStr[1];
            OnPropertyChanged(nameof(AppLockPos));
        }

        private void changeCountdownMode(string newMode)
        {
            string[] modeStr = newMode.Split(',');
            Settings_Main.settingsDefault.CountdownModeStr = modeStr[0];
            Settings_Main.settingsDefault.CountdownModePos = modeStr[1];
            OnPropertyChanged(nameof(CountdownModePos));
        }

        private void changeDailyReminderTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            Settings_Main.settingsDefault.DailyReminderTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_Main.settingsDefault.DailyReminderTimeStr = getTimeFormat(Settings_Main.settingsDefault.DailyReminderTime);
            Settings_Main.settingsDefault.DailyReminderTimePos = timeStr[1];
            OnPropertyChanged(nameof(DailyReminderTimePos));
        }

        private void changeDefaultAlertTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            Settings_Main.settingsDefault.DefaultEventAlertMins = getMinutes(timeStr[0], timeStr[1]);
            Settings_Main.settingsDefault.DefaultEventAlertStr = timeStr[0] + " " + timeStr[1] + " prior";
            Settings_Main.settingsDefault.DefaultEventAlertPos = timeStr[2];
            OnPropertyChanged(nameof(DefaultAlertTimePos));
        }

        private void changeTasksReminder(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            Settings_Main.settingsDefault.TasksReminderTime = new TimeSpan(Default.stringToInt(timeStr[0]), 0, 0);
            Settings_Main.settingsDefault.TasksReminderStr = getTimeFormat(Settings_Main.settingsDefault.TasksReminderTime) + " on the day";
            Settings_Main.settingsDefault.TasksReminderPos = timeStr[1];
            OnPropertyChanged(nameof(TasksReminderPos));
        }

        private void changeReminderRingtone(string newTone)
        {
            string[] toneStr = newTone.Split(',');
            Settings_Main.settingsDefault.ReminderRingtoneStr = toneStr[0];
            Settings_Main.settingsDefault.ReminderRingtonePos = toneStr[1];
            OnPropertyChanged(nameof(ReminderRingtonePos));
        }

        private void changeReminderDefault(string newReminder)
        {
            string[] reminderStr = newReminder.Split(',');

            if (reminderStr[0] == "Morning")
            {
                Settings_Main.settingsDefault.ReminderDefaultMorning = new TimeSpan(Default.stringToInt(reminderStr[1]), 0, 0);
                Settings_Main.settingsDefault.ReminderDefaultMorningStr = getTimeFormat(Settings_Main.settingsDefault.ReminderDefaultMorning);
                Settings_Main.settingsDefault.ReminderDefaultMorningPos = reminderStr[2];
                OnPropertyChanged(nameof(ReminderDefaultMorningPos));
            }
            else if (reminderStr[0] == "Afternoon")
            {
                Settings_Main.settingsDefault.ReminderDefaultAfternoon = new TimeSpan(Default.stringToInt(reminderStr[1]), 0, 0);
                Settings_Main.settingsDefault.ReminderDefaultAfternoonStr = getTimeFormat(Settings_Main.settingsDefault.ReminderDefaultAfternoon);
                Settings_Main.settingsDefault.ReminderDefaultAfternoonPos = reminderStr[2];
                OnPropertyChanged(nameof(ReminderDefaultAfternoonPos));
            }
            else if (reminderStr[0] == "Evening")
            {
                Settings_Main.settingsDefault.ReminderDefaultEvening = new TimeSpan(Default.stringToInt(reminderStr[1]), 0, 0);
                Settings_Main.settingsDefault.ReminderDefaultEveningStr = getTimeFormat(Settings_Main.settingsDefault.ReminderDefaultEvening);
                Settings_Main.settingsDefault.ReminderDefaultEveningPos = reminderStr[2];
                OnPropertyChanged(nameof(ReminderDefaultEveningPos));
            }
        }

        private void changeDefaultBreakDuration(string newDuration)
        {
            string[] durationStr = newDuration.Split(',');
            Settings_Main.settingsDefault.DefaultBreakDurationStr = durationStr[0] + " minutes";
            Settings_Main.settingsDefault.DefaultBreakDurationPos = durationStr[1];
            OnPropertyChanged(nameof(DefaultBreakDurationPos));
        }

        private void changeSyncInterval(string newInterval)
        {
            string[] intervalStr = newInterval.Split(',');
            Settings_Main.settingsDefault.SyncIntervalStr = Default.stringToInt(intervalStr[0]) == 1 ? "Every hour" : "Every " + intervalStr[0] + " hours";
            Settings_Main.settingsDefault.SyncIntervalPos = intervalStr[1];
            OnPropertyChanged(nameof(SyncIntervalPos));
        }

        public string AppThemePos => $"{Settings_Main.settingsDefault.AppThemePos}";
        public string FirstDayOfWeekPos => $"{Settings_Main.settingsDefault.FirstDayOfWeekPos}";
        public string DayStartTimePos => $"{Settings_Main.settingsDefault.DayStartTimePos}";
        public string DefaultEventDurationPos => $"{Settings_Main.settingsDefault.DefaultEventDurationPos}";
        public string DefaultViewPos => $"{Settings_Main.settingsDefault.DefaultViewPos}";
        public string ShowWeekNumbersPos => $"{Settings_Main.settingsDefault.ShowWeekNumbersPos}";
        public string TimeFormatPos => $"{Settings_Main.settingsDefault.TimeFormatPos}";
        public string AppLockPos => $"{Settings_Main.settingsDefault.AppLockPos}";
        public string CountdownModePos => $"{Settings_Main.settingsDefault.CountdownModePos}";
        public string DailyReminderTimePos => $"{Settings_Main.settingsDefault.DailyReminderTimePos}";
        public string DefaultAlertTimePos => $"{Settings_Main.settingsDefault.DefaultEventAlertPos}";
        public string TasksReminderPos => $"{Settings_Main.settingsDefault.TasksReminderPos}";
        public string ReminderRingtonePos => $"{Settings_Main.settingsDefault.ReminderRingtonePos}";
        public string ReminderDefaultMorningPos => $"{Settings_Main.settingsDefault.ReminderDefaultMorningPos}";
        public string ReminderDefaultAfternoonPos => $"{Settings_Main.settingsDefault.ReminderDefaultAfternoonPos}";
        public string ReminderDefaultEveningPos => $"{Settings_Main.settingsDefault.ReminderDefaultEveningPos}";
        public string DefaultBreakDurationPos => $"{Settings_Main.settingsDefault.DefaultBreakDurationPos}";
        public string SyncIntervalPos => $"{Settings_Main.settingsDefault.SyncIntervalPos}";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string getTimeFormat(TimeSpan tsTime)
        {
            int twelthHour = 12;
            string startTime = tsTime.ToString().Substring(0, 5);
            string tFormat = Settings_Main.settingsDefault.TimeFormatStr;

            if (tFormat.Substring(0, 2) == "12")
            {
                if (tsTime.Hours < 10)
                {
                    startTime = startTime.Substring(1) + " AM";
                }
                else if (tsTime.Hours < 12)
                {
                    startTime = startTime + " AM";
                }
                else if (tsTime.Hours == 12)
                {
                    startTime = startTime + " PM";
                }
                else if (tsTime.Hours < 22)
                {
                    string temp = new TimeSpan(tsTime.Hours - twelthHour, 0, 0).ToString().Substring(0, 5);
                    startTime = temp.ToString().Substring(1) + " PM";
                }
                else
                {
                    string temp = new TimeSpan(tsTime.Hours - twelthHour, 0, 0).ToString().Substring(0, 5);
                    startTime = temp + " PM";
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

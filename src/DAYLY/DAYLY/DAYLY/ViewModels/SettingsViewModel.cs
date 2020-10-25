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

        INavigation NavStack;

        public string _AppThemeStr;
        public string _AppThemePos;
        public string _FirstDayOfWeekStr;
        public string _FirstDayOfWeekPos;
        public TimeSpan _DayStartTime;
        public string _DayStartTimeStr;
        public string _DayStartTimePos;
        public int _DefaultEventDuration;
        public string _DefaultEventDurationStr;
        public string _DefaultEventDurationPos;
        public string _DefaultViewStr;
        public string _DefaultViewPos;
        public string _ShowWeekNumbersStr;
        public string _ShowWeekNumbersPos;
        public string _TimeFormatStr;
        public string _TimeFormatPos;
        public string _AppLockStr;
        public string _AppLockPos;
        public string _CountdownModeStr;
        public string _CountdownModePos;
        public TimeSpan _DailyReminderTime;
        public string _DailyReminderTimeStr;
        public string _DailyReminderTimePos;
        public int _DefaultEventAlertMins;
        public string _DefaultEventAlertStr;
        public string _DefaultEventAlertPos;
        public TimeSpan _TasksReminderTime;
        public string _TasksReminderStr;
        public string _TasksReminderPos;
        public string _ReminderRingtoneStr;
        public string _ReminderRingtonePos;
        public TimeSpan _ReminderDefaultMorning;
        public string _ReminderDefaultMorningStr;
        public string _ReminderDefaultMorningPos;
        public TimeSpan _ReminderDefaultAfternoon;
        public string _ReminderDefaultAfternoonStr;
        public string _ReminderDefaultAfternoonPos;
        public TimeSpan _ReminderDefaultEvening;
        public string _ReminderDefaultEveningStr;
        public string _ReminderDefaultEveningPos;
        public string _DefaultBreakDurationStr;
        public string _DefaultBreakDurationPos;
        public string _SyncIntervalStr;
        public string _SyncIntervalPos;
        public string _ProfilePicPath;
        public string _LogInOutBtnText;
        public bool _LoggedIn;

        public string AppThemeStr
        {
            get
            {
                return _AppThemeStr;
            }
            set
            {
                _AppThemeStr = value;
                OnPropertyChanged(nameof(AppThemeStr));
            }
        }

        public string AppThemePos
        {
            get
            {
                return _AppThemePos;
            }
            set
            {
                _AppThemePos = value;
                OnPropertyChanged(nameof(AppThemePos));
            }
        }

        public string FirstDayOfWeekStr
        {
            get
            {
                return _FirstDayOfWeekStr;
            }
            set
            {
                _FirstDayOfWeekStr = value;
                OnPropertyChanged(nameof(FirstDayOfWeekStr));
            }
        }

        public string FirstDayOfWeekPos
        {
            get
            {
                return _FirstDayOfWeekPos;
            }
            set
            {
                _FirstDayOfWeekPos = value;
                OnPropertyChanged(nameof(FirstDayOfWeekPos));
            }
        }

        public TimeSpan DayStartTime
        {
            get
            {
                return _DayStartTime;
            }
            set
            {
                _DayStartTime = value;
                OnPropertyChanged(nameof(DayStartTime));
            }
        }

        public string DayStartTimeStr
        {
            get
            {
                return _DayStartTimeStr;
            }
            set
            {
                _DayStartTimeStr = value;
                OnPropertyChanged(nameof(DayStartTimeStr));
            }
        }

        public string DayStartTimePos
        {
            get
            {
                return _DayStartTimePos;
            }
            set
            {
                _DayStartTimePos = value;
                OnPropertyChanged(nameof(DayStartTimePos));
            }
        }

        public int DefaultEventDuration
        {
            get
            {
                return _DefaultEventDuration;
            }
            set
            {
                _DefaultEventDuration = value;
                OnPropertyChanged(nameof(DefaultEventDuration));
            }
        }

        public string DefaultEventDurationStr
        {
            get
            {
                return _DefaultEventDurationStr;
            }
            set
            {
                _DefaultEventDurationStr = value;
                OnPropertyChanged(nameof(DefaultEventDurationStr));
            }
        }

        public string DefaultEventDurationPos
        {
            get
            {
                return _DefaultEventDurationPos;
            }
            set
            {
                _DefaultEventDurationPos = value;
                OnPropertyChanged(nameof(DefaultEventDurationPos));
            }
        }

        public string DefaultViewStr
        {
            get
            {
                return _DefaultViewStr;
            }
            set
            {
                _DefaultViewStr = value;
                OnPropertyChanged(nameof(DefaultViewStr));
            }
        }

        public string DefaultViewPos
        {
            get
            {
                return _DefaultViewPos;
            }
            set
            {
                _DefaultViewPos = value;
                OnPropertyChanged(nameof(DefaultViewPos));
            }
        }

        public string ShowWeekNumbersStr
        {
            get
            {
                return _ShowWeekNumbersStr;
            }
            set
            {
                _ShowWeekNumbersStr = value;
                OnPropertyChanged(nameof(ShowWeekNumbersStr));
            }
        }

        public string ShowWeekNumbersPos
        {
            get
            {
                return _ShowWeekNumbersPos;
            }
            set
            {
                _ShowWeekNumbersPos = value;
                OnPropertyChanged(nameof(ShowWeekNumbersPos));
            }
        }

        public string TimeFormatStr
        {
            get
            {
                return _TimeFormatStr;
            }
            set
            {
                _TimeFormatStr = value;
                OnPropertyChanged(nameof(TimeFormatStr));
            }
        }

        public string TimeFormatPos
        {
            get
            {
                return _TimeFormatPos;
            }
            set
            {
                _TimeFormatPos = value;
                OnPropertyChanged(nameof(TimeFormatPos));
            }
        }

        public string AppLockStr
        {
            get
            {
                return _AppLockStr;
            }
            set
            {
                _AppLockStr = value;
                OnPropertyChanged(nameof(AppLockStr));
            }
        }

        public string AppLockPos
        {
            get
            {
                return _AppLockPos;
            }
            set
            {
                _AppLockPos = value;
                OnPropertyChanged(nameof(AppLockPos));
            }
        }

        public string CountdownModeStr
        {
            get
            {
                return _CountdownModeStr;
            }
            set
            {
                _CountdownModeStr = value;
                OnPropertyChanged(nameof(CountdownModeStr));
            }
        }

        public string CountdownModePos
        {
            get
            {
                return _CountdownModePos;
            }
            set
            {
                _CountdownModePos = value;
                OnPropertyChanged(nameof(CountdownModePos));
            }
        }

        public TimeSpan DailyReminderTime
        {
            get
            {
                return _DailyReminderTime;
            }
            set
            {
                _DailyReminderTime = value;
                OnPropertyChanged(nameof(DailyReminderTime));
            }
        }

        public string DailyReminderTimeStr
        {
            get
            {
                return _DailyReminderTimeStr;
            }
            set
            {
                _DailyReminderTimeStr = value;
                OnPropertyChanged(nameof(DailyReminderTimeStr));
            }
        }

        public string DailyReminderTimePos
        {
            get
            {
                return _DailyReminderTimePos;
            }
            set
            {
                _DailyReminderTimePos = value;
                OnPropertyChanged(nameof(DailyReminderTimePos));
            }
        }

        public int DefaultEventAlertMins
        {
            get
            {
                return _DefaultEventAlertMins;
            }
            set
            {
                _DefaultEventAlertMins = value;
            }
        }

        public string DefaultEventAlertStr
        {
            get
            {
                return _DefaultEventAlertStr;
            }
            set
            {
                _DefaultEventAlertStr = value;
                OnPropertyChanged(nameof(DefaultEventAlertStr));
            }
        }

        public string DefaultEventAlertPos
        {
            get
            {
                return _DefaultEventAlertPos;
            }
            set
            {
                _DefaultEventAlertPos = value;
                OnPropertyChanged(nameof(DefaultEventAlertPos));
            }
        }

        public TimeSpan TasksReminderTime
        {
            get
            {
                return _TasksReminderTime;
            }
            set
            {
                _TasksReminderTime = value;
                OnPropertyChanged(nameof(TasksReminderTime));
            }
        }

        public string TasksReminderStr
        {
            get
            {
                return _TasksReminderStr;
            }
            set
            {
                _TasksReminderStr = value;
                OnPropertyChanged(nameof(TasksReminderStr));
            }
        }

        public string TasksReminderPos
        {
            get
            {
                return _TasksReminderPos;
            }
            set
            {
                _TasksReminderPos = value;
                OnPropertyChanged(nameof(TasksReminderPos));
            }
        }

        public string ReminderRingtoneStr
        {
            get
            {
                return _ReminderRingtoneStr;
            }
            set
            {
                _ReminderRingtoneStr = value;
                OnPropertyChanged(nameof(ReminderRingtoneStr));
            }
        }

        public string ReminderRingtonePos
        {
            get
            {
                return _ReminderRingtonePos;
            }
            set
            {
                _ReminderRingtonePos = value;
                OnPropertyChanged(nameof(ReminderRingtonePos));
            }
        }

        public TimeSpan ReminderDefaultMorning
        {
            get
            {
                return _ReminderDefaultMorning;
            }
            set
            {
                _ReminderDefaultMorning = value;
                OnPropertyChanged(nameof(ReminderDefaultMorning));
            }
        }

        public string ReminderDefaultMorningStr
        {
            get
            {
                return _ReminderDefaultMorningStr;
            }
            set
            {
                _ReminderDefaultMorningStr = value;
                OnPropertyChanged(nameof(ReminderDefaultMorningStr));
            }
        }

        public string ReminderDefaultMorningPos
        {
            get
            {
                return _ReminderDefaultMorningPos;
            }
            set
            {
                _ReminderDefaultMorningPos = value;
                OnPropertyChanged(nameof(ReminderDefaultMorningPos));
            }
        }

        public TimeSpan ReminderDefaultAfternoon
        {
            get
            {
                return _ReminderDefaultAfternoon;
            }
            set
            {
                _ReminderDefaultAfternoon = value;
                OnPropertyChanged(nameof(ReminderDefaultAfternoon));
            }
        }

        public string ReminderDefaultAfternoonStr
        {
            get
            {
                return _ReminderDefaultAfternoonStr;
            }
            set
            {
                _ReminderDefaultAfternoonStr = value;
                OnPropertyChanged(nameof(ReminderDefaultAfternoonStr));
            }
        }

        public string ReminderDefaultAfternoonPos
        {
            get
            {
                return _ReminderDefaultAfternoonPos;
            }
            set
            {
                _ReminderDefaultAfternoonPos = value;
                OnPropertyChanged(nameof(ReminderDefaultAfternoonPos));
            }
        }

        public TimeSpan ReminderDefaultEvening
        {
            get
            {
                return _ReminderDefaultEvening;
            }
            set
            {
                _ReminderDefaultEvening = value;
                OnPropertyChanged(nameof(ReminderDefaultEvening));
            }
        }

        public string ReminderDefaultEveningStr
        {
            get
            {
                return _ReminderDefaultEveningStr;
            }
            set
            {
                _ReminderDefaultEveningStr = value;
                OnPropertyChanged(nameof(ReminderDefaultEveningStr));
            }
        }

        public string ReminderDefaultEveningPos
        {
            get
            {
                return _ReminderDefaultEveningPos;
            }
            set
            {
                _ReminderDefaultEveningPos = value;
                OnPropertyChanged(nameof(ReminderDefaultEveningPos));
            }
        }

        public string DefaultBreakDurationStr
        {
            get
            {
                return _DefaultBreakDurationStr;
            }
            set
            {
                _DefaultBreakDurationStr = value;
                OnPropertyChanged(nameof(DefaultBreakDurationStr));
            }
        }

        public string DefaultBreakDurationPos
        {
            get
            {
                return _DefaultBreakDurationPos;
            }
            set
            {
                _DefaultBreakDurationPos = value;
                OnPropertyChanged(nameof(DefaultBreakDurationPos));
            }
        }

        public string SyncIntervalStr
        {
            get
            {
                return _SyncIntervalStr;
            }
            set
            {
                _SyncIntervalStr = value;
                OnPropertyChanged(nameof(SyncIntervalStr));
            }
        }

        public string SyncIntervalPos
        {
            get
            {
                return _SyncIntervalPos;
            }
            set
            {
                _SyncIntervalPos = value;
                OnPropertyChanged(nameof(SyncIntervalPos));
            }
        }

        public string ProfilePicPath
        {
            get
            {
                return _ProfilePicPath;
            }
            set
            {
                _ProfilePicPath = value;
                OnPropertyChanged(nameof(ProfilePicPath));
            }
        }

        public bool LoggedIn
        {
            get
            {
                return _LoggedIn;
            }
            set
            {
                _LoggedIn = value;
            }
        }

        public string LogInOutBtnText
        {
            get
            {
                return _LogInOutBtnText;
            }
            set
            {
                _LogInOutBtnText = value;
                OnPropertyChanged(nameof(LogInOutBtnText));
            }
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
        public ICommand LogInOutCommand { get; }

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
            LogInOutCommand = new Command(logInOut);
        }

        private void changeAppTheme(string newTheme)
        {
            string[] themeStr = newTheme.Split(',');
            AppThemeStr = themeStr[0];
            AppThemePos = themeStr[1];
        }

        private void changeFirstDayOfWeek(string newDay)
        {
            string[] dayStr = newDay.Split(',');
            FirstDayOfWeekStr = dayStr[0];
            FirstDayOfWeekPos = dayStr[1];
        }

        private void changeDayStartTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');

            DayStartTime = new TimeSpan(stringToInt(timeStr[0]), 0, 0);
            DayStartTimeStr = getTimeFormat(DayStartTime);
            DayStartTimePos = timeStr[1];
        }

        private void changeDefaultEvenDuration(string newDuration)
        {
            string[] posStr = newDuration.Split(',');
            DefaultEventDuration = stringToInt(posStr[0]);
            DefaultEventDurationStr = posStr[0] + " minutes";
            DefaultEventDurationPos = posStr[1];
        }

        private void changeDefaultView(string newView)
        {
            string[] viewStr = newView.Split(',');
            DefaultViewStr = viewStr[0];
            DefaultViewPos = viewStr[1];
        }

        private void changeShowWeekNumbers(string newView)
        {
            string[] viewStr = newView.Split(',');
            ShowWeekNumbersStr = viewStr[0];
            ShowWeekNumbersPos = viewStr[1];
        }

        private void changeTimeFormat(string newTimeF)
        {
            string[] timeFStr = newTimeF.Split(',');
            TimeFormatStr = timeFStr[0] + " hour";
            TimeFormatPos = timeFStr[1];
            DayStartTimeStr = getTimeFormat(DayStartTime);
            DailyReminderTimeStr = getTimeFormat(DailyReminderTime);
            TasksReminderStr = getTimeFormat(TasksReminderTime) + " on the day";
            ReminderDefaultMorningStr = getTimeFormat(ReminderDefaultMorning);
            ReminderDefaultAfternoonStr = getTimeFormat(ReminderDefaultAfternoon);
            ReminderDefaultEveningStr = getTimeFormat(ReminderDefaultEvening);
        }

        private void changeAppLock(string newLock)
        {
            string[] lockStr = newLock.Split(',');
            AppLockStr = lockStr[0];
            AppLockPos = lockStr[1];
        }

        private void changeCountdownMode(string newMode)
        {
            string[] modeStr = newMode.Split(',');
            CountdownModeStr = modeStr[0];
            CountdownModePos = modeStr[1];
        }

        private void changeDailyReminderTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            DailyReminderTime = new TimeSpan(stringToInt(timeStr[0]), 0, 0);
            DailyReminderTimeStr = getTimeFormat(DailyReminderTime);
            DailyReminderTimePos = timeStr[1];
        }

        private void changeDefaultAlertTime(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            DefaultEventAlertMins = getMinutes(timeStr[0], timeStr[1]);
            DefaultEventAlertStr = timeStr[0] + " " + timeStr[1] + " prior";
            DefaultEventAlertPos = timeStr[2];
        }

        private void changeTasksReminder(string newTime)
        {
            string[] timeStr = newTime.Split(',');
            TasksReminderTime = new TimeSpan(stringToInt(timeStr[0]), 0, 0);
            TasksReminderStr = getTimeFormat(TasksReminderTime) + " on the day";
            TasksReminderPos = timeStr[1];
        }

        private void changeReminderRingtone(string newTone)
        {
            string[] toneStr = newTone.Split(',');
            ReminderRingtoneStr = toneStr[0];
            ReminderRingtonePos = toneStr[1];
        }

        private void changeReminderDefault(string newReminder)
        {
            string[] reminderStr = newReminder.Split(',');

            if (reminderStr[0] == "Morning")
            {
                ReminderDefaultMorning = new TimeSpan(stringToInt(reminderStr[1]), 0, 0);
                ReminderDefaultMorningStr = getTimeFormat(ReminderDefaultMorning);
                ReminderDefaultMorningPos = reminderStr[2];
            }
            else if (reminderStr[0] == "Afternoon")
            {
                ReminderDefaultAfternoon = new TimeSpan(stringToInt(reminderStr[1]), 0, 0);
                ReminderDefaultAfternoonStr = getTimeFormat(ReminderDefaultAfternoon);
                ReminderDefaultAfternoonPos = reminderStr[2];
            }
            else if (reminderStr[0] == "Evening")
            {
                ReminderDefaultEvening = new TimeSpan(stringToInt(reminderStr[1]), 0, 0);
                ReminderDefaultEveningStr = getTimeFormat(ReminderDefaultEvening);
                ReminderDefaultEveningPos = reminderStr[2];
            }
        }

        private void changeDefaultBreakDuration(string newDuration)
        {
            string[] durationStr = newDuration.Split(',');
            DefaultBreakDurationStr = durationStr[0] + " minutes";
            DefaultBreakDurationPos = durationStr[1];
        }

        private void changeSyncInterval(string newInterval)
        {
            string[] intervalStr = newInterval.Split(',');
            SyncIntervalStr = stringToInt(intervalStr[0]) == 1 ? "Every hour" : "Every " + intervalStr[0] + " hours";
            SyncIntervalPos = intervalStr[1];
        }

        async void logInOut()
        {
            if (LoggedIn)
            {
                bool logout = await Application.Current.MainPage.DisplayAlert("Log out", "Are you sure you want to log out?", "Yes", "No");

                if (logout == true)
                {
                    LoggedIn = false;
                    LogInOutBtnText = "LOG IN";
                    ProfilePicPath = "user_placeholder.png";
                    Profile.profileViewModel.LoggedInVisible = "False";
                    Profile.profileViewModel.LoggedOutVisible = "True";
                }
            }
            else
            {
                await NavStack.PushModalAsync(new Profile_Login());
            }
        }

        public void Initialise(INavigation navigation)
        {
            NavStack = navigation;

            AppThemeStr = "Follow system";
            AppThemePos = "0";
            FirstDayOfWeekStr = "Sunday";
            FirstDayOfWeekPos = "3";
            DayStartTime = new TimeSpan(8, 0, 0);
            DayStartTimePos = "6";
            DayStartTimeStr = "8:00 AM";
            DefaultEventDurationStr = "120 minutes";
            DefaultEventDurationPos = "12";
            DefaultViewStr = "Day view";
            DefaultViewPos = "0";
            ShowWeekNumbersStr = "Start of semester";
            ShowWeekNumbersPos = "3";
            TimeFormatStr = "12 hour";
            TimeFormatPos = "0";
            AppLockStr = "PIN";
            AppLockPos = "3";
            CountdownModeStr = "Days remaining";
            CountdownModePos = "0";
            DailyReminderTime = new TimeSpan(8, 0, 0);
            DailyReminderTimeStr = "8:00 AM";
            DailyReminderTimePos = "6";
            DefaultEventAlertMins = 15;
            DefaultEventAlertStr = "15 minutes";
            DefaultEventAlertPos = "0";
            TasksReminderTime = new TimeSpan(17, 0, 0);
            TasksReminderStr = "5:00 PM on the day";
            TasksReminderPos = "0";
            ReminderRingtoneStr = "DAYLY";
            ReminderRingtonePos = "0";
            ReminderDefaultMorning = new TimeSpan(8, 0, 0);
            ReminderDefaultMorningStr = "8:00 AM";
            ReminderDefaultMorningPos = "6";
            ReminderDefaultAfternoon = new TimeSpan(14, 0, 0);
            ReminderDefaultAfternoonStr = "2:00 PM";
            ReminderDefaultAfternoonPos = "0";
            ReminderDefaultEvening = new TimeSpan(18, 0, 0);
            ReminderDefaultEveningStr = "6:00 PM";
            ReminderDefaultEveningPos = "0";
            DefaultBreakDurationStr = "15 minutes";
            DefaultBreakDurationPos = "0";
            SyncIntervalStr = "Every hour";
            SyncIntervalPos = "0";
            ProfilePicPath = "user_placeholder.png";
            LogInOutBtnText = "LOG IN";
            LoggedIn = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string getTimeFormat(TimeSpan tsTime)
        {
            int twelthHour = 12;
            string startTime = tsTime.ToString().Substring(0, 5);
            string tFormat = TimeFormatStr;

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
                mins = stringToInt(value);
            }
            else if (unit == "hour" || unit == "hours")
            {
                mins = stringToInt(value) * HOUR_MINUTES;
            }
            else if (unit == "day" || unit == "days")
            {
                mins = stringToInt(value) * DAY_HOURS * HOUR_MINUTES;
            }

            return mins;
        }

        private int stringToInt(string stringToConvert)
        {
            int result;

            try
            {
                int.TryParse(stringToConvert, out result);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        private void clearProfilePage()
        {

        }
    }
}

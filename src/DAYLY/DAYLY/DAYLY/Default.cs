using System;

namespace DAYLY
{
    public class Default
    {
        public string AppThemeStr { get; set; }
        public string AppThemePos { get; set; }
        public string FirstDayOfWeekStr { get; set; }
        public string FirstDayOfWeekPos { get; set; }
        public TimeSpan DayStartTime { get; set; }
        public string DayStartTimeStr { get; set; }
        public string DayStartTimePos { get; set; }
        public int DefaultEventDuration { get; set; }
        public string DefaultEventDurationStr { get; set; }
        public string DefaultEventDurationPos { get; set; }
        public string DefaultViewStr { get; set; }
        public string DefaultViewPos { get; set; }
        public string ShowWeekNumbersStr { get; set; }
        public string ShowWeekNumbersPos { get; set; }
        public string TimeFormatStr { get; set; }
        public string TimeFormatPos { get; set; }
        public string AppLockStr { get; set; }
        public string AppLockPos { get; set; }
        public string CountdownModeStr { get; set; }
        public string CountdownModePos { get; set; }
        public TimeSpan DailyReminderTime { get; set; }
        public string DailyReminderTimeStr { get; set; }
        public string DailyReminderTimePos { get; set; }
        public int DefaultEventAlertMins { get; set; }
        public string DefaultEventAlertStr { get; set; }
        public string DefaultEventAlertPos { get; set; }
        public TimeSpan TasksReminderTime { get; set; }
        public string TasksReminderStr { get; set; }
        public string TasksReminderPos { get; set; }
        public string ReminderRingtoneStr { get; set; }
        public string ReminderRingtonePos { get; set; }
        public TimeSpan ReminderDefaultMorning { get; set; }
        public string ReminderDefaultMorningStr { get; set; }
        public string ReminderDefaultMorningPos { get; set; }
        public TimeSpan ReminderDefaultAfternoon { get; set; }
        public string ReminderDefaultAfternoonStr { get; set; }
        public string ReminderDefaultAfternoonPos { get; set; }
        public TimeSpan ReminderDefaultEvening { get; set; }
        public string ReminderDefaultEveningStr { get; set; }
        public string ReminderDefaultEveningPos { get; set; }

        public void SetDefaults()
        {
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
            ReminderDefaultMorningPos= "6";
            ReminderDefaultAfternoon = new TimeSpan(14, 0, 0);
            ReminderDefaultAfternoonStr = "2:00 PM";
            ReminderDefaultAfternoonPos = "0";
            ReminderDefaultEvening = new TimeSpan(18, 0, 0);
            ReminderDefaultEveningStr = "6:00 PM";
            ReminderDefaultEveningPos = "0";
        }

        public static int stringToInt(string stringToConvert)
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

    }
}

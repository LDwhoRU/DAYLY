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

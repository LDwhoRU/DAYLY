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
        public string TimeFormat { get; set; }
        public int DefaultEventDuration { get; set; }
        public string DefaultEventDurationStr { get; set; }
        public string DefaultEventDurationPos { get; set; }
        public string DefaultViewStr { get; set; }
        public string DefaultViewPos { get; set; }

        public void SetDefaults()
        {
            AppThemeStr = "Follow system";
            AppThemePos = "0";
            FirstDayOfWeekStr = "Sunday";
            FirstDayOfWeekPos = "3";
            DayStartTime = new TimeSpan(8, 0, 0);
            DayStartTimePos = "6";
            DayStartTimeStr = "8:00 AM";
            TimeFormat = "12 hour";
            DefaultEventDurationStr = "120 minutes";
            DefaultEventDurationPos = "12";
            DefaultViewStr = "Day view";
            DefaultViewPos = "0";
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

using System;

namespace DAYLY.Models
{
    public class Event : Affair
    {
        
        public bool IsOnline { get; set; }
        public bool AllDay { get; set; }
        public TimeSpan StartTime { get; set; }
       
        public TimeSpan EndTime { get; set; }
        public string Location { get; set; }
    }
}
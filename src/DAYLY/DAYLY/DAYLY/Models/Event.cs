using System;

namespace DAYLY.Models
{
    public class Event : Affair
    {
        public bool IsOnline { get; set; }
        public bool AllDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace DAYLY.Models
{
    public class Event : Affair
    {
        
        public bool IsOnline { get; set; }
        public bool AllDay { get; set; }
        public TimeSpan StartTime { get; set; }
       
        public TimeSpan EndTime { get; set; }
        [Indexed]
        public int LocationId { get; set; }
    }
}
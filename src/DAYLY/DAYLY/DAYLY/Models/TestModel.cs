using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace DAYLY.Models
{
    public class TestEvent
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsOnline { get; set; }
        public bool AllDay { get; set; }

    }
}

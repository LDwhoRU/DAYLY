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
        public int id { get; set; }
        public string FirstEntry { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace DAYLY.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
    }
}
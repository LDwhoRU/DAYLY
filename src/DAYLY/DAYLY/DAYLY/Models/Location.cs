using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace DAYLY.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Alias { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }
    }
}

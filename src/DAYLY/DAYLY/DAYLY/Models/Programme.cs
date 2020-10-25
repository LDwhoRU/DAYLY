using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace DAYLY.Models
{
    public class Programme
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexColour { get; set; }
    }
}
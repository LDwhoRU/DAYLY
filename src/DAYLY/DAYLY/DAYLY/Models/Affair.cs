using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace DAYLY.Models
{
    public class Affair
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int RepeatInterval { get; set; }
        public int AlertInterval { get; set; }
        [Indexed]
        public int NoteId { get; set; }
        [Indexed]
        public int ProgrammeId { get; set; }
    }
}
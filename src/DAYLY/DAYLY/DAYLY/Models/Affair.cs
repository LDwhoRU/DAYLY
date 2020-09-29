using System;

namespace DAYLY.Models
{
    public class Affair
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int RepeatInterval { get; set; }
        public int AlertInterval { get; set; }
        public Note NoteEntry { get; set; }
        public Programme SelectedProgramme { get; set; }
    }
}
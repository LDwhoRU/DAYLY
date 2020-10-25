using System;
using SQLite;
namespace DAYLY.Models
{
    public class UserProfile
    {
        public string FullName { get; set; }
        [PrimaryKey]
        public string Email { get; set; }
        public string Password { get; set; }
        public int TasksRemaining { get; set; }
        public int TasksCompleted { get; set; }
        public int DaysSinceAccountCreated { get; set; }
        public string Organisation { get; set; }
        public string Course { get; set; }
    }
}

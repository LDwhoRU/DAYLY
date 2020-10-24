using System;
namespace DAYLY.Models
{
    public class UserProfile
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int TasksRemaining { get; set; }
        public int TasksCompleted { get; set; }
        public int DaysSinceAccountCreated { get; set; }
        public string Organisation { get; set; }
        public string Course { get; set; }
    }
}

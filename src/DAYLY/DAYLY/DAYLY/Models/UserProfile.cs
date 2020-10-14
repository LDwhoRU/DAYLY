using System;
namespace DAYLY.Models
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TasksRemaining { get; set; }
        public string TasksCompleted { get; set; }
        public string Organisation { get; set; }
        public string Course { get; set; }
    }
}

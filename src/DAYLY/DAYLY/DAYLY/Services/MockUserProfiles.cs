using System;
using SQLite;
using DAYLY.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAYLY.Services
{
    public class MockUserProfiles
    {
        public SQLiteConnection conn;
        List<UserProfile> userProfiles;

        public MockUserProfiles()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            CreateMockUsers();

            conn.CreateTable<UserProfile>();

            if (conn.Table<UserProfile>().Count() == 0)
            {
                foreach (UserProfile user in userProfiles)
                {
                    conn.Insert(user);
                }
            }

            conn.Close();
        }

        private void CreateMockUsers()
        {
            userProfiles = new List<UserProfile>();
            var rand = new Random();

            for (int i = 0; i < 11; i++)
            {
                userProfiles.Add(new UserProfile()
                {
                    FullName = "User " + i.ToString(),
                    Email = "user" + i.ToString() + "@email.com",
                    Password = "user" + i.ToString(),
                    TasksRemaining = rand.Next(31),
                    TasksCompleted = rand.Next(51),
                    DaysSinceAccountCreated = rand.Next(50, 301),
                    Organisation = "Organision " + i.ToString(),
                    Course = "Course " + i.ToString()
                });
            }
        }     
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using DAYLY;
using DAYLY.Models;
using SQLite;
using Xamarin.Forms;

namespace DAYLY.ViewModels
{
    public class NewEventViewModel
    {
        public SQLiteConnection conn;
        public NewEventViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            try
            {
                conn.DropTable<Event>();
                conn.DropTable<Note>();
                conn.DropTable<Programme>();
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.CreateTable<Note>();
            conn.CreateTable<Programme>();
            conn.CreateTable<Event>();
        }
        public void SaveEvent(string EventName, DateTime EventDate, TimeSpan EventStartTime, TimeSpan EventEndTime, bool EventOnline, bool EventAllDay)
        {
            int isSuccess;
            // Add Test Note
            Note newNote = new Note
            {
                Description = "Testing",
                URL = "www.url.com"
            };
            isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(newNote);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Add Programme
            Programme newProgramme = new Programme
            {
                Name = "Cal",
                HexColour = "FFFFFF"
            };
            isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(newProgramme);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Add Event
            Event newEvent = new Event
            {
                Name = EventName,
                Type = "Event",
                Date = EventDate,
                StartTime = EventStartTime,
                EndTime = EventEndTime,
                AllDay = EventAllDay,
                IsOnline = EventOnline,
                NoteId = newNote.Id,
                ProgrammeId = newProgramme.Id,
            };
            isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(newEvent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TimeConvert(TimeSpan initTime)
        {
            string timeSuffix = "AM";
            if (initTime.Hours > 12)
            {
                TimeSpan twelveHour = new TimeSpan(12, 0, 0);
                initTime = initTime.Subtract(twelveHour);
                timeSuffix = "PM";
            }
            return initTime.ToString().Substring(0, 5) + timeSuffix;
        }

        public string AUDateConvert(DateTime initDate)
        {
            return initDate.Day.ToString() + "/" + initDate.Month.ToString() + "/" + initDate.Year.ToString();
        }
    }
}

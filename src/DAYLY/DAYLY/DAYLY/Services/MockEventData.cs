using DAYLY.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAYLY.Services
{
    public class MockEventData : IDataStore<Event>
    {
        readonly List<Event> events;

        public MockEventData()
        {
            Programme red = new Programme();
            red.HexColour = "green";
            Programme pink = new Programme();
            pink.HexColour = "pink";
            DateTime datetime1 = new DateTime(2020, 10, 19, 8, 30, 0);
            DateTime datetime2 = new DateTime(2020, 10, 21, 9, 30, 0);
            DateTime datetime3 = new DateTime(2020, 10, 23, 9, 30, 0);
            DateTime datetime4 = new DateTime(2020, 10, 18, 9, 30, 0);
            DateTime datetime5 = new DateTime(2020, 10, 20, 9, 30, 0);
            DateTime datetime6 = new DateTime(2020, 10, 22, 9, 30, 0);
            DateTime datetime7 = new DateTime(2020, 10, 24, 9, 30, 0);
            TimeSpan span = new TimeSpan(7, 0, 0);
            TimeSpan span3= new TimeSpan(12, 0, 0);
            TimeSpan span2 = new TimeSpan(15, 0, 0);
            TimeSpan span4 = new TimeSpan(11, 0, 0);
            TimeSpan span5 = new TimeSpan(16, 0, 0);
            TimeSpan span6 = new TimeSpan(18, 0, 0);



            events = new List<Event>()

            {
                new Event {Name = "Monday test", Type = "tute", Date = datetime1, RepeatInterval = "Daily", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span, EndTime=span3,LocationId=1 },
                 new Event {Name = "2nd monday", Type = "tute", Date = datetime1, RepeatInterval = "Weekly", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span2, EndTime=span6,LocationId=1 },
                 new Event {Name = "wednesday dude", Type = "tute", Date = datetime2, RepeatInterval = "Weekly", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span4, EndTime=span3,LocationId=1},
                 new Event {Name = "friyayayayayayay", Type = "tute", Date = datetime3, RepeatInterval = "Weekly", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span5, EndTime=span6,LocationId=1 },
                    new Event {Name = "sunday type beat", Type = "tute", Date = datetime4, RepeatInterval = "Weekly", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span, EndTime=span2,LocationId=1 },
                     new Event {Name = "tuesdeee", Type = "tute", Date = datetime5, RepeatInterval = "Weekly", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span3, EndTime=span2,LocationId=1 },
                      new Event {Name = "thursssbrahhh", Type = "tute", Date = datetime6, RepeatInterval = "Weekly", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span4, EndTime=span5,LocationId=1 },
                       new Event {Name = "satatatatatata", Type = "tute", Date = datetime7, RepeatInterval = "Weekly", AlertInterval="15 Minutes", NoteId=1,ProgrammeId=1,AllDay=false,StartTime=span4, EndTime=span6,LocationId=1 },
     };
        }
        public async Task<bool> AddItemAsync(Event item)
        {
            events.Add(item);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetItemAsync(string id)
        {
            return await Task.FromResult(events.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(events);
        }

        public Task<bool> UpdateItemAsync(Event item)
        {
            throw new NotImplementedException();
        }
    }
}

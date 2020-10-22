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
                new Event { Id = "1", Name = "Monday test", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=red,AllDay=false,StartTime=span, EndTime=span3,Location="P5" },
                 new Event { Id = "3", Name = "2nd monday", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=pink,AllDay=false,StartTime=span2, EndTime=span6,Location="P5" },
                //new Event { Id = "2", Name = "CAB303", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=pink,AllDay=false,StartTime=span5, EndTime=span6,Location="P5" },
                 new Event { Id = "4", Name = "wednesday dude", Type = "tute", Date = datetime2, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=pink,AllDay=false,StartTime=span4, EndTime=span3,Location="P5" },
                 new Event { Id = "5", Name = "friyayayayayayay", Type = "tute", Date = datetime3, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=red,AllDay=false,StartTime=span5, EndTime=span6,Location="P5" },
                    new Event { Id = "6", Name = "sunday type beat", Type = "tute", Date = datetime4, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=red,AllDay=false,StartTime=span, EndTime=span2,Location="P5" },
                     new Event { Id = "6", Name = "tuesdeee", Type = "tute", Date = datetime5, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=pink,AllDay=false,StartTime=span3, EndTime=span2,Location="P5" },
                      new Event { Id = "6", Name = "thursssbrahhh", Type = "tute", Date = datetime6, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=red,AllDay=false,StartTime=span4, EndTime=span5,Location="P5" },
                       new Event { Id = "6", Name = "satatatatatata", Type = "tute", Date = datetime7, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=pink,AllDay=false,StartTime=span4, EndTime=span6,Location="P5" },
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

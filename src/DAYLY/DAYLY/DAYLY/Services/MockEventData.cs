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
            DateTime datetime1 = new DateTime(2020, 10, 19, 8, 30, 0);
            DateTime datetime2 = new DateTime(2020, 10, 21, 9, 30, 0);
            DateTime datetime3 = new DateTime(2020, 10, 23, 9, 30, 0);
            DateTime datetime4 = new DateTime(2020, 10, 18, 9, 30, 0);
            TimeSpan span = new TimeSpan(9, 0, 0);
            TimeSpan span3= new TimeSpan(12, 0, 0);
            TimeSpan span2 = new TimeSpan(15, 0, 0);
            TimeSpan span4 = new TimeSpan(11, 0, 0);
            TimeSpan span5 = new TimeSpan(16, 0, 0);
            TimeSpan span6 = new TimeSpan(18, 0, 0);



            events = new List<Event>()

            {
                new Event { Id = "1", Name = "CAB303", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=null,AllDay=false,StartTime=span, EndTime=span3,Location="P5" },
                 new Event { Id = "3", Name = "CAB303", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=null,AllDay=false,StartTime=span2, EndTime=span6,Location="P5" },
                //new Event { Id = "2", Name = "CAB303", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=null,AllDay=false,StartTime=span3, EndTime=span2,Location="P5" },
                 new Event { Id = "4", Name = "CAB303", Type = "tute", Date = datetime2, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=null,AllDay=false,StartTime=span4, EndTime=span3,Location="P5" },
                 new Event { Id = "5", Name = "CAB303", Type = "tute", Date = datetime3, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=null,AllDay=false,StartTime=span5, EndTime=span6,Location="P5" },
                  //  new Event { Id = "6", Name = "CAB303", Type = "tute", Date = datetime4, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=null,AllDay=false,StartTime=span, EndTime=span2,Location="P5" },
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

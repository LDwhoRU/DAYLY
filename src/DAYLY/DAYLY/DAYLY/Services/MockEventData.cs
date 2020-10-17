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
            DateTime datetime1 = new DateTime(2020, 10, 17, 8, 30, 0);
            DateTime datetime2 = new DateTime(2020, 10, 17, 9, 30, 0);

            events = new List<Event>()

            {
                new Event { Id = "1", Name = "CAB303", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteEntry=null,SelectedProgramme=null,AllDay=false,StartTime=datetime1,EndTime=datetime2,Location="P5" },
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

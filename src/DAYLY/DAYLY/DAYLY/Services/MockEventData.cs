﻿using DAYLY.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAYLY.Services
{
    public class MockEventData : IDataStore<Event>
    {
        public List<Event> events;
        public List<Calendar> programmes;
        public List<Note> Notess;
        public List<Location> locations;
        public MockEventData()
        {



            DateTime datetime1 = new DateTime(2020, 10, 19, 8, 30, 0);
            DateTime datetime2 = new DateTime(2020, 10, 21, 9, 30, 0);
            DateTime datetime3 = new DateTime(2020, 10, 25, 9, 30, 0);
            DateTime datetime4 = new DateTime(2020, 10, 18, 9, 30, 0);
            DateTime datetime5 = new DateTime(2020, 10, 20, 9, 30, 0);
            DateTime datetime6 = new DateTime(2020, 10, 22, 9, 30, 0);
            DateTime datetime7 = new DateTime(2020, 10, 24, 9, 30, 0);
            TimeSpan span = new TimeSpan(7, 0, 0);

            TimeSpan span3 = new TimeSpan(14, 0, 0);

            TimeSpan span2 = new TimeSpan(15, 0, 0);
            TimeSpan span4 = new TimeSpan(12, 0, 0);
            TimeSpan span5 = new TimeSpan(16, 0, 0);
            TimeSpan span6 = new TimeSpan(18, 0, 0);

            locations = new List<Location>
            {
                new Location{Id=1, Alias="someones house", Postcode=4120, State="QLD", StreetAddress="39 Gordon St", Suburb="Greenslopes"},
                  new Location{Id=2, Alias="next door", Postcode=4120, State="QLD", StreetAddress="37 Gordon St", Suburb="Greenslopes"},
                    new Location{Id=3, Alias="across the road", Postcode=4120, State="QLD", StreetAddress="39 Gordon St", Suburb="Greenslopes"},
            };
            programmes = new List<Calendar> {
            new Calendar{Id=1,Name="test",HexColour="#FF0000"},
            new Calendar{Id=2,Name="yeet",HexColour="#008000"}
            };
            Notess = new List<Note>() {

               new Note{Id=1,URL="www.google.com",Description="testing this epic dude stuff my guy"},
               new Note{Id=2,URL="www.facebook.com",Description="testing number 2 shmole"},
                new Note{Id=3,URL="www.reddit.com",Description="testing number 3 smole"},
                 new Note{Id=4,URL="www.myspace.com",Description="testing number 4 mole"},
                  new Note{Id=5,URL="www.github.com",Description="testing number 5 ole"},
                   new Note{Id=6,URL="www.op.gg",Description="testing number 6 aaaaa"},
                    new Note{Id=7,URL="www.website.com",Description="testing number 7 zzzz"},
                     new Note{Id=8,URL="www.redditmoment.com",Description="another description"},
                       new Note{Id=9,URL="www.bruhmoment.com",Description="bruh"},

           };


            events = new List<Event>()

            {
                new Event { Id = 1, Name = "Monday test", Type = "Lecture", Date = datetime3, RepeatInterval = "1", AlertInterval="1", NoteId=1,CalendarId=2,AllDay=false,IsOnline=false,StartTime=span, EndTime=span2,LocationId=1 },
                 new Event { Id = 3, Name = "2nd monday", Type = "Tutorial", Date = datetime3, RepeatInterval = "1", AlertInterval="1", NoteId=2,CalendarId=1,AllDay=false,IsOnline=false,StartTime=span2, EndTime=span6,LocationId=2 },
                //new Event { Id = "2", Name = "CAB303", Type = "tute", Date = datetime1, RepeatInterval = 1, AlertInterval=1, NoteId=3,ProgrammeId=1,AllDay=false,StartTime=span5, EndTime=span6,Location="P5" },
                //new Event { Id = 4, Name = "wednesday dude", Type = "tute", Date = datetime3, RepeatInterval = 1, AlertInterval=1, NoteId=4,ProgrammeId=2,AllDay=false,StartTime=span4, EndTime=span3,Location="P5" },
                 //new Event { Id = 5, Name = "friyayayayayayay", Type = "tute", Date = datetime3, RepeatInterval = 1, AlertInterval=1, NoteId=5,ProgrammeId=1,AllDay=false,StartTime=span5, EndTime=span6,Location="P5" },
                //    new Event { Id = 6, Name = "sunday type beat", Type = "tute", Date = datetime4, RepeatInterval = 1, AlertInterval=1, NoteId=6,ProgrammeId=1,AllDay=false,StartTime=span, EndTime=span2,Location="P5" },
                 //    new Event { Id = 6, Name = "tuesdeee", Type = "tute", Date = datetime5, RepeatInterval = 1, AlertInterval=1, NoteId=1,ProgrammeId=7,AllDay=false,StartTime=span3, EndTime=span2,Location="P5" },
                  //    new Event { Id = 6, Name = "thursssbrahhh", Type = "tute", Date = datetime6, RepeatInterval = 1, AlertInterval=1, NoteId=8,ProgrammeId=1,AllDay=false,StartTime=span4, EndTime=span5,Location="P5" },
                    //   new Event { Id = 6, Name = "satatatatatata", Type = "tute", Date = datetime7, RepeatInterval = 1, AlertInterval=1, NoteId=9,ProgrammeId=1,AllDay=false,StartTime=span4, EndTime=span6,Location="P5" },

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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(events);
        }
        public async Task<IEnumerable<Note>> GetNotesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Notess);
        }
        public async Task<IEnumerable<Calendar>> GetColoursAsync(bool forceRefresh = false)
        {
            //throw new NotImplementedException();
            return await Task.FromResult(programmes);
        }

        public Task<bool> UpdateItemAsync(Event item)
        {
            throw new NotImplementedException();
        }
    }
}

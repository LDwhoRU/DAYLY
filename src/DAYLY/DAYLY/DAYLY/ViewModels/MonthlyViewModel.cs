using DAYLY.Models;
using DAYLY.Services;
using DAYLY.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Models;

namespace DAYLY.ViewModels
{
    //When creating an event to have it displayed on the monthly view it must have a location,name and note
    //To refresh the monthly view for when new events are added you must press monthly again
    //unfortunatley couldnt get custom colours working on the monthly view as the package used wasn't flexible enough
    class MonthlyViewModel : BaseViewModel
    {
        private List<Event> zz;
        private SQLiteConnection conn;
        private List<Event> eventlist;
        private List<Calendar> colourlist;
        private List<Note> notelist;
        private List<Location> localist;

        public EventCollection Events { get; set; }
          public ObservableCollection<Event> Eventz { get; }
        public ObservableCollection<Note> notes { get; }
        public ObservableCollection<Location> locations { get; }
        public MonthlyViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            eventlist = conn.Table<Event>().ToList();
            colourlist = conn.Table<Calendar>().ToList();
            notelist = conn.Table<Note>().ToList();
            localist = conn.Table<Location>().ToList();
            //Task.Run(async () => await ExecuteLoadItemsCommand());

            Eventz = new ObservableCollection<Event>(eventlist);
            //   Console.WriteLine("below");
            //   Console.WriteLine(Eventz[1].Date);
            locations = new ObservableCollection<Location>(localist);
            notes = new ObservableCollection<Note>(notelist);
            Events = new EventCollection();
            Task.Run(async () => await Populate());

        }
        public Command MonthlyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Monthly());
                });

            }
        }
        public Command DailyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Daily());
                });

            }
        }
        public Command WeeklyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Weekly());
                });

            }
        }
        async Task Populate()
        {
            IsBusy = true;
         
                try {
           
               // Console.WriteLine(Eventz.ToString());
                int index = new int();
                int locindex = new int();
                for (int i = 0; i < Eventz.Count; i++) { //loop through how many events there are create a event list each time
                    Console.WriteLine("below me"); //this list is then added to the event collection which is bound to the calendar
                    zz = new List<Event>();
                    foreach (var not in notes)
                    {
                        if (not.Id == Eventz[i].NoteId)//find the index of the note that corresponds to the event
                        {
                            index = notes.IndexOf(not);
                        }
                    }
                    foreach (var local in locations)
                    {
                        if (local.Id == Eventz[i].NoteId)//find the index of the note that corresponds to the event
                        {
                            locindex = locations.IndexOf(local);
                        }
                    }
                    var temp = new List<Event>(Eventz);//create a temporary list to iterate through so the main list can be modified
                    zz.Add(new Event { Name =temp[i].Name, Type = notes[index].Description, StartTime = temp[i].StartTime, EndTime = temp[i].EndTime, AlertInterval ="Location: "+locations[locindex].Alias });
                    foreach (var eventt in temp) {
                   
                        if (eventt.Date == temp[i].Date&&eventt.Name!=temp[i].Name) {
                            foreach (var x in notes) //multiple events on the same date are found then removed
                            {
                                if (x.Id == eventt.NoteId)//finding the index that belongs to the second note
                                {
                                    index = notes.IndexOf(x);
                                }
                            }
                            zz.Add(new Event { Name = eventt.Name, Type = notes[index].Description, StartTime=eventt.StartTime,EndTime=eventt.EndTime, AlertInterval=locations[locindex].Alias});
                            //Console.WriteLine(eventt.Name);
                            Eventz.Remove(eventt);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine(zz[0].Name);
                    Events.Add(Eventz[i].Date,zz);
                }
           
             
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        
        //    Task.Run(async () => await ExecuteLoadItemsCommand());
        
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Eventz.Clear();
                var events = await DataStore.GetItemsAsync(true); //loading up mock data to be used
                foreach (var evett in events)
                {
                    Eventz.Add(evett);
                }
                MockEventData bb = new MockEventData();
                var not = await bb.GetNotesAsync(true);
                foreach(var nott in not)
                {
                    notes.Add(nott);
                }
           
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}

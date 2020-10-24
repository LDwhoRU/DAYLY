using DAYLY.Models;
using DAYLY.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Plugin.Calendar.Models;

namespace DAYLY.ViewModels
{
    //this view model also uses testdata can be altered in mockeventdata
    class MonthlyViewModel : BaseViewModel
    {
        private List<Event> zz;

        public EventCollection Events { get; set; }
          public ObservableCollection<Event> Eventz { get; }
        public ObservableCollection<Note> notes { get; }
        public MonthlyViewModel()
        {
            //Task.Run(async () => await ExecuteLoadItemsCommand());
           
            Eventz = new ObservableCollection<Event>();
            //   Console.WriteLine("below");
            //   Console.WriteLine(Eventz[1].Date);
            notes = new ObservableCollection<Note>();
            Events = new EventCollection();
            Task.Run(async () => await Populate());

        }
          async Task Populate()
        {
            IsBusy = true;
         
                try {
           
               // Console.WriteLine(Eventz.ToString());
                int index = new int();
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
                    var temp = new List<Event>(Eventz);//create a temporary list to iterate through so the main list can be modified
                    zz.Add(new Event { Name =temp[i].Name, Type = notes[index].Description });
                    foreach (var eventt in temp) {
                        if (eventt.Date == temp[i].Date&&eventt.Name!=temp[i].Name) {
                            foreach (var x in notes) //multiple events on the same date are found then removed
                            {
                                if (x.Id == eventt.NoteId)//finding the index that belongs to the second note
                                {
                                    index = notes.IndexOf(x);
                                }
                            }
                            zz.Add(new Event { Name = eventt.Name, Type = notes[index].Description });
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
                //var not = await bb.GetNotesAsync(true);
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

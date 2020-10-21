using DAYLY.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Plugin.Calendar.Models;

namespace DAYLY.ViewModels
{
    class MonthlyViewModel : BaseViewModel
    {
        public EventCollection Events { get; set; }
          public ObservableCollection<Event> Eventz { get; }
        public MonthlyViewModel()
        {
            Task.Run(async () => await ExecuteLoadItemsCommand());

            Eventz = new ObservableCollection<Event>();
            Console.WriteLine("below");
            Console.WriteLine(Eventz[1].Date);
            Events = new EventCollection
            
            //Events = Eventz;
            {
           //    [Eventz[1].Date] = new List<Event>
  //  {
       // new Event { Name = Eventz[1].Name, Type = "This is Cool event1's description!" },
      //  new Event { Name = Eventz[1].Name,  Type = "This is Cool event2's description!" }
  //  },
                // 5 days from today
         //       [Eventz[0].Date] = new List<Event>
   // {
   //  //   new Event { Name = Eventz[0].Name,  Type = "This is Cool event3's description!" },
     //   new Event { Name = Eventz[0].Name,  Type = "This is Cool event4's description!" }
   // },
                // 3 days ago
          //      [Eventz[2].Date] = new List<Event>
  //  {
    //    new Event { Name = Eventz[2].Name, Type = "This is Cool event5's description!" }
  //  },
                // custom date
         //       [Eventz[3].Date] = new List<Event>
  //  {
       // new Event { Name = Eventz[3].Name,  Type = "This is Cool event6's description!" }
   // }
            };
            List<Event> zz = new List<Event>();
            zz.Add(Eventz[1]);
            Events.Add((Eventz[1].Date), zz);
          
        //    Task.Run(async () => await ExecuteLoadItemsCommand());
        }
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
                foreach (var test in Eventz)
                {
                    // Console.WriteLine(test.StartTime.TimeOfDay);
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

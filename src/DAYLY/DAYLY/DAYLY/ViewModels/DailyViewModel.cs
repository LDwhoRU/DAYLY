using DAYLY.Models;
using DAYLY.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;

namespace DAYLY.ViewModels
{
    class DailyViewModel: BaseViewModel
    {
        bool[] times = new bool[16];//used to set is visible on elements
        string today;
        int[] spans = new int[16]; //used to figure out row span depending on time
        string[] colours = new string[16];//used to set colours
        string[] desc = new string[16];//used to set names
        string[] locations = new string[16];//set locations
        string[] notes = new string[16];//et notes
        public ObservableCollection<Event> Events { get; } //intialising all the global variables
        public ObservableCollection<Note> Notes { get; }
        public ObservableCollection<Location> Locations { get; }
        public ObservableCollection<Programme> Colours { get; }
        TimeSpan time8 = new TimeSpan(7, 0, 0);
        TimeSpan[] TimerArray = new TimeSpan[16];
        private SQLiteConnection conn;
        private List<Event> eventlist;
        private List<Programme> colourlist;
        private List<Note> notelist;
        private List<Location> locationlist;
        TimeSpan time1 = TimeSpan.FromHours(1);
        public DailyViewModel()
        {
            DateTime dt = DateTime.Today;
            conn = DependencyService.Get<Isqlite>().GetConnection();
            eventlist = conn.Table<Event>().ToList();
            colourlist = conn.Table<Programme>().ToList();
            notelist = conn.Table<Note>().ToList();
            locationlist = conn.Table<Location>().ToList();
            Events = new ObservableCollection<Event>(eventlist);
            Colours = new ObservableCollection<Programme>(colourlist);
            Notes = new ObservableCollection<Note>(notelist);
            Locations=new ObservableCollection<Location>(locationlist);
            Title = "testing";
           // Console.WriteLine("yeah we made it");
            Today = dt.DayOfWeek.ToString() + " " + dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
           // Task.Run(async () => await ExecuteLoadItemsCommand()); //loading the mock data
            GetTimes();
      
        }
        public string Today
        {

            get
            {
                return today;
            }
            set { SetProperty(ref today, value); }

        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;


            try
            {
                Events.Clear();
                Colours.Clear();
                var events = await DataStore.GetItemsAsync(true); //loading up mock data to be used
                foreach (var evett in events)
                {
                    Events.Add(evett);
                }
                MockEventData bb = new MockEventData();
                var col = await bb.GetColoursAsync(true);
                foreach (var colo in col)
                {
                    Colours.Add(colo);
                }
               
                var not = await bb.GetNotesAsync(true);
                foreach(var nots in not)
                {
                    //Console.WriteLine(not);
                    Notes.Add(nots);
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
        public void GetTimes()
        {
            TimerArray[0] = time8;
            //Console.WriteLine("yeah we made it");
            for (int i = 1; i < TimerArray.Length; i++) //populate the array with the times of day used
            {
                TimerArray[i] = TimerArray[i - 1].Add(time1);
                Console.WriteLine(TimerArray[i - 1]);//for some reason doesnt work without this
            }

            IsBusy = true;
            try
            {
                for (int i = 0; i < times.Length; i++)//set every thing to false to begin with and 
                {
                    times[i] = false;
                    spans[i] = 1;//make all rowspans 1 as null gives an error
                    colours[i] = "#FFFFFF";
                }
                foreach (var even in Events)
                {
                   
                    if (even.Date.DayOfWeek == DateTime.Today.DayOfWeek) {//loop through events if the date of the event is today loop through the different time slots if time matches one of the times
                        for (int i = 0; i < TimerArray.Length; i++) {//set that boolean to true as well as storing the other data
                           // Console.WriteLine("yeah we made it");
                            if (even.StartTime ==TimerArray[i]) {
                                times[i] = true;
                                desc[i] = even.Name;
                               // locations[i] = even.Location;
                                foreach(var no in Notes)
                                {
                                    Console.WriteLine(no.Description);
                                    if (no.Id == even.NoteId)
                                    {
                                        Console.WriteLine("in the if blicky");
                                        notes[i] = no.Description;
                                    }
                                }
                               
                                Console.WriteLine(TimerArray[i]);
                               // 
                                TimeSpan duration = even.EndTime.Subtract(even.StartTime);
                                spans[i] = duration.Hours+1;
                                Console.WriteLine(spans[i]);
                                foreach (var colour in Colours)
                                {
                                    Console.WriteLine(colour.HexColour);
                                    if (colour.Id == even.ProgrammeId)
                                    {
                                        colours[i] =colour.HexColour;
                                    }
                                }
                            }
                        }
                        foreach(var x in notes)
                        {
                            Console.WriteLine(x);
                        }
                    }
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
        public string[] Colorss {
            get { return colours; }
        }
        public string[] Nnotes
        {
            get { return notes; }
        }
        public string[] Desc
        {
            get { return desc;}
        }
        public string[] Location
        {
            get { return locations; }
        }
        public bool[] Times
        {
            
          get{ return times; }
        }
        public string[] Colourz {

            get { return colours; }
        }
        public int[] Spans
        {
           get{ return spans; }
        }
      
    }
}

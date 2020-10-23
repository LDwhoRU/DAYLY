using DAYLY.Models;
using DAYLY.Services;
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
        bool[] times = new bool[16];
        string today;
        int[] spans = new int[16];
        Color[] colours = new Color[16];
        string[] desc = new string[16];
        string[] locations = new string[16];
        string[] notes = new string[16];
        public ObservableCollection<Event> Events { get; }
        public ObservableCollection<Note> Notes { get; }
        public ObservableCollection<Programme> Colours { get; }
        TimeSpan time8 = new TimeSpan(7, 0, 0);
        TimeSpan[] TimerArray = new TimeSpan[16];
        TimeSpan time1 = TimeSpan.FromHours(1);
        public DailyViewModel()
        {
            DateTime dt = DateTime.Today;
            Events = new ObservableCollection<Event>();
            Colours = new ObservableCollection<Programme>();
            Notes = new ObservableCollection<Note>();
            Title = "testing";
           // Console.WriteLine("yeah we made it");
            Today = dt.DayOfWeek.ToString() + " " + dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
            Task.Run(async () => await ExecuteLoadItemsCommand());
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
                for (int i = 0; i < times.Length; i++)//set every thing to false to begin with
                {
                    times[i] = false;
                    spans[i] = 1;
                }
                foreach (var even in Events)
                {
                   // Console.WriteLine("yeah we made it");
                    if (even.Date.DayOfWeek == DateTime.Today.DayOfWeek) {
                        for (int i = 0; i < TimerArray.Length; i++) {
                           // Console.WriteLine("yeah we made it");
                            if (even.StartTime ==TimerArray[i]) {
                                times[i] = true;
                                desc[i] = even.Name;
                                locations[i] = even.Location;
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
                                        colours[i] = Xamarin.Forms.Color.FromHex(colour.HexColour);
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
        public Color[] Colorss {
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
        public Color[] Colourz {

            get { return colours; }
        }
        public int[] Spans
        {
           get{ return spans; }
        }
      
    }
}

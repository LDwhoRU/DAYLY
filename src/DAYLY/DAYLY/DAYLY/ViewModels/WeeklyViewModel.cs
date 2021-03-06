﻿using DAYLY.Models;
using DAYLY.Services;
using DAYLY.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DAYLY.ViewModels
{
    class WeeklyViewModel : BaseViewModel
    {
        bool[] mon = new bool[16];//only displays times from 7am-10pm
        bool[] tue = new bool[16];//intialising all the arrays used
        bool[] wed = new bool[16];
        bool[] thur = new bool[16];
        bool[] fri = new bool[16];
        bool[] sat = new bool[16];
        bool[] sun = new bool[16];
        string[] week = new string[7];
        string[][] elements = new string[7][];
        string[][] text = new string[7][];
        string[] montext = new string[16];
        string[] tuetext = new string[16];
        string[] wedtext = new string[16];
        string[] thurtext = new string[16];
        string[] fritext = new string[16];
        string[] sattext = new string[16];
        string[] suntext = new string[16];
        string[] moncol = new string[16];
        string[] tuecol = new string[16];
        string[] wedcol = new string[16];
        string[] thurcol = new string[16];
        string[] fricol = new string[16];
        string[] satcol = new string[16];
        string[] suncol = new string[16];
     //for some reason viewmodel isnt reinstantied when navigating for create new event after creating some events. So to show new events, after there are existing events, that have been created after pressing schedule you have to
     //click weekly again


        string today;

        string monday, tuesday, wednesday, thursday, friday, saturday, sunday;
        TimeSpan[] TimerArray = new TimeSpan[16];
        TimeSpan time8 = new TimeSpan(7, 0, 0);
        TimeSpan time1 = TimeSpan.FromHours(1);
        private SQLiteConnection conn;
        private List<Event> eventlist;
        private List<Calendar> colourlist;

        public ObservableCollection<Event> Events { get; set ; }
        public ObservableCollection<Calendar> Colours { get; set; }
        public WeeklyViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            eventlist = conn.Table<Event>().ToList();
            colourlist = conn.Table<Calendar>().ToList();
            Events = new ObservableCollection<Event>(eventlist);
            Colours = new ObservableCollection<Calendar>(colourlist);
            TimerArray[0] = time8;
            Title = "Weekly";
            DateTime dt = DateTime.Today;
           


            Today = dt.DayOfWeek.ToString() + " " + dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString(); //figure out the current day of the week
            GetWeek();

            WeekTime();                                                                                                             //  Task.Run(async () => await ExecuteLoadItemsCommand());//load the test data
                                                                                                                                    // intialise();



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

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Events.Clear();
                var events = await DataStore.GetItemsAsync(true); //loading up mock data to be used
                foreach (var evett in events)
                {
                    //    Events.Add(evett);
                //    Events.Add(evett);
                }
                MockEventData bb = new MockEventData();
                var col = await bb.GetColoursAsync(true);
                foreach (var colo in col)
                {
                    Colours.Add(colo);
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

        public void GetWeek()
        {
            IsBusy = true;
            try
            {

           
                var Sun = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Sunday); //calculating the first day of the week, sunday then using this to figoure out the rest of the week
                var Monday = Sun.AddDays(1);
                var Tues = Monday.AddDays(1);
                var Wed = Tues.AddDays(1);
                var Thurs = Wed.AddDays(1);
                var Fri = Thurs.AddDays(1);
                var Sat = Fri.AddDays(1);

                monday = Monday.Day.ToString();
                tuesday = Tues.Day.ToString();
                wednesday = Wed.Day.ToString();
                thursday = Thurs.Day.ToString();
                friday = Fri.Day.ToString();
                saturday = Sat.Day.ToString();
                sunday = Sun.Day.ToString();
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

        public void WeekTime()
        {
            bool[][] bweek = new bool[][] { sun, mon, tue, wed, thur, fri, sat };//mutlidimensional array for making frames visible on view
            IsBusy = true;
            week[0] = sunday; //adding days of the week to array
            week[1] = monday;
            week[2] = tuesday;
            week[3] = wednesday;
            week[4] = thursday;
            week[5] = friday;
            week[6] = saturday;
            elements[0] = suncol; //populating the colour array with indivdual string array for each day of week
            elements[1] = moncol;
            elements[2] = tuecol;
            elements[3] = wedcol;
            elements[4] = thurcol;
            elements[5] = fricol;
            elements[6] = satcol;
            text[0] = suntext; //same as above but with text
            text[1] = montext;
            text[2] = tuetext;
            text[3] = wedtext;
            text[4] = thurtext;
            text[5] = fritext;
            text[6] = sattext;

            //   Console.WriteLine(time8);

            for (int i = 1; i < TimerArray.Length; i++) //populate the array with the times of day used
            {
                TimerArray[i] = TimerArray[i - 1].Add(time1);
                Console.WriteLine(TimerArray[i - 1]);
            }

            try
            {
                int dayy = 0;
                foreach (var day in week)
                {
                    for (int i = 0; i < sun.Length; i++)//set every thing to false to begin with
                    {
                        bweek[dayy][i] = false;
                        elements[dayy][i] = "#FFFFFF";
                    }

                    foreach (var even in Events)
                    {

                        if ((int)even.Date.DayOfWeek == dayy && even.Date.Day.ToString() == day)//if the day of the week is equal to the day of the loop
                        {
                            Console.WriteLine("I made it");
                            for (int i = 0; i < TimerArray.Length; i++)
                            {

                                if (even.StartTime.Hours == TimerArray[i].Hours)//if the time of the event is equal to the time off the loop round down to the hours, couldnt implement dynamic start times
                                {
                                    bweek[dayy][i] = true; //set that time to true
                                    foreach (var col in Colours)
                                    {
                                        if (col.Id == even.CalendarId)
                                        {
                                            elements[dayy][i] = col.HexColour;
                                        }
                                    }
                                    //elements[dayy][i] = even.SelectedProgramme.HexColour; //assign that times colour and text
                                    text[dayy][i] = even.Name;
                                    //elements[dayy][i] = even.SelectedProgramme.HexColour;
                                    //  Console.WriteLine(even.SelectedProgramme.HexColour);
                                    TimeSpan duration = even.EndTime.Subtract(even.StartTime);
                                    int hours = duration.Hours; //calculating the duration

                                    int z = 1;
                                    for (int j = i; z <= hours; j++) //using duration to see how many other times need to be set to true
                                    {
                                        bweek[dayy][j] = true;
                                        elements[dayy][j] = elements[dayy][i];
                                        text[dayy][j] = even.Name;
                                        z++;
                                        Console.WriteLine(j);
                                    }
                                    // Console.WriteLine(hours);
                                }

                            }


                        }



                    }
                    dayy++;
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
        //returning the array of day texts
        public string[] SunText
        {
            get { return text[0]; }
        }
        public string[] MonText
        {
            get { return text[1]; }
        }
        public string[] TueText
        {
            get { return text[2]; }
        }
        public string[] WedText
        {
            get { return text[3]; }
        }
        public string[] ThurText
        {
            get { return text[4]; }
        }
        public string[] FriText
        {
            get { return text[5]; }
        }
        public string[] SatText
        {
            get { return text[6]; }
        }
        //returning array of day colours
        public string[] MonColours
        {
            get
            {
                return elements[1];
            }
        }
        public string[] SunColours
        {
            get
            {
                return elements[0];
            }
        }
        public string[] TueColours
        {
            get
            {
                return elements[2];
            }
        }
        public string[] WedColours
        {
            get
            {
                return elements[3];
            }
        }
        public string[] ThurColours
        {
            get
            {
                return elements[4];
            }
        }
        public string[] FriColours
        {
            get
            {
                return elements[5];
            }
        }
        public string[] SatColours
        {
            get
            {
                return elements[6];
            }
        }

        //returning boolean array of days
        public string Monday
        {
            get
            {
                return monday;
            }
        }
        public string Tuesday
        {
            get
            {
                return tuesday;
            }
        }
        public string Wednesday
        {
            get
            {
                return wednesday;
            }
        }
        public string Thursday
        {
            get
            {
                return thursday;
            }
        }
        public string Friday
        {
            get
            {
                return friday;
            }
        }
        public string Saturday
        {
            get
            {
                return saturday;
            }
        }
        public string Sunday
        {
            get
            {
                return sunday;
            }
        }
        public string Today
        {

            get
            {
                return today;
            }
            set { SetProperty(ref today, value); }

        }
        public bool[] Mon
        {
            get
            {
                return mon;
            }

         
            set
            {
                SetProperty(ref mon, value);
                // SunText(value);
            }
        }

        public bool[] Tue
        {
            get
            {
                return tue;
            }
            set
            {
                SetProperty(ref tue, value);
                // SunText(value);
            }

        }

        public bool[] Wed
        {
            get
            {
                return wed;
            }
            set
            {
                SetProperty(ref wed, value);
                // SunText(value);
            }
        }

        public bool[] Thur
        {
            get
            {
                return thur;
            }
            set
            {
                SetProperty(ref thur, value);
                // SunText(value);
            }
        }

        public bool[] Fri
        {
            get
            {
                return fri;
            }
            set
            {
                SetProperty(ref fri, value);
                // SunText(value);
            }

        }

        public bool[] Sat
        {
            get
            {
                return sat;
            }
            set
            {
                SetProperty(ref sat, value);
                // SunText(value);
            }

        }

        public bool[] Sun
        {
            get
            {
                return sun;
            }
            set
            {
                SetProperty(ref sun, value);
                // SunText(value);
            }

        }


    }
}

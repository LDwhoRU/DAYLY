using DAYLY.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DAYLY.ViewModels
{
    class WeeklyViewModel : BaseViewModel
    {
        bool mon8, mon9, mon10, mon11, mon12, mon13, mon14, mon15, mon16, mon17, mon18, mon19,mon20,mon21,mon22;
        bool tue8, tue9, tue10, tue11, tue12, tue13, tue14, tue15, tue16, tue17, tue18, tue19, tue20, tue21, tue22;
        bool wed8, wed9, wed10, wed11, wed12, wed13, wed14, wed15, wed16, wed17, wed18, wed19, wed20, wed21, wed22;
        bool thur8, thur9, thur10, thur11, thur12, thur13, thur14, thur15, thur16, thur17, thur18, thur19, thur20, thur21, thur22;
        bool fri8, fri9, fri10, fri11, fri12, fri13, fri14, fri15, fri16, fri17, fri18, fri19, fri20, fri21, fri22;
        bool sat8, sat9, sat10, sat11, sat12, sat13, sat14, sat15, sat16, sat17, sat18, sat19, sat20, sat21, sat22;
        bool sun8, sun9, sun10, sun11, sun12, sun13, sun14, sun15, sun16, sun17, sun18, sun19, sun20, sun21, sun22;
        string nmon8, nmon9, nmon10, nmon11, nmon12, nmon13, nmon14, nmon15, nmon16, nmon17, nmon18, nmon19, nmon20, nmon21, nmon22;
        string today;
         string monday, tuesday, wednesday, thursday,friday,saturday,sunday;
        public ObservableCollection<Event> Events { get; }
     
        public WeeklyViewModel()
        {

            Title = "Weekly";
            DateTime dt = DateTime.Today;
            Events = new ObservableCollection<Event>();
            Today = dt.DayOfWeek.ToString() + " " + dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
            Task.Run(async () => await ExecuteLoadItemsCommand());
             GetWeek();
             MonTime();
            TueTime();
            WedTime();
            ThurTime();
            FriTime();
            SatTime();
            SunTime();
            Console.WriteLine(mon12);
           // Console.WriteLine(monday);
          //  Console.WriteLine(mon8);
           
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Events.Clear();
                var events = await DataStore.GetItemsAsync(true);
                foreach (var evett in events)
                {
                    Events.Add(evett);
                }
                foreach(var test in Events)
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

          public void GetWeek()
        {
            IsBusy = true;
            try
            {
               var Monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                var Tues = Monday.AddDays(1);
                var Wed = Tues.AddDays(1);
                var Thurs = Wed.AddDays(1);
                var Fri = Thurs.AddDays(1);
                var Sat = Fri.AddDays(1);
                var Sun = Sat.AddDays(1);
                
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
        public void MonTime()
        {
            Console.WriteLine("pog");
            IsBusy = true;
          TimeSpan  time8 = new TimeSpan(8, 0, 0);
            TimeSpan time9 = new TimeSpan(9, 0, 0);
            TimeSpan time10 = new TimeSpan(10, 0, 0);
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            TimeSpan time14 = new TimeSpan(14, 0, 0);
            TimeSpan time15 = new TimeSpan(15, 0, 0);
            TimeSpan time16 = new TimeSpan(16, 0, 0);
            TimeSpan time17 = new TimeSpan(17, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time22 = new TimeSpan(22, 0, 0);
            TimeSpan time19 = new TimeSpan(19, 0, 0);
            TimeSpan time20 = new TimeSpan(20, 0, 0);
            TimeSpan time21 = new TimeSpan(21, 0, 0);
            //   Console.WriteLine(time8);
            try
            {
                foreach(var even in Events)
                {
                   
                    if ((int)even.Date.DayOfWeek==1&&even.Date.Day.ToString()==monday)
                    {
                        Console.WriteLine("I made it");
                        if (even.StartTime == time8) {
                            mon8 = true;
                        }
                        else if (even.StartTime == time9)
                        {
                           
                            mon9 = true;
                        }
                        else if (even.StartTime == time10)
                        {

                            mon10 = true;
                        }
                        else if (even.StartTime == time11)
                        {

                            mon11 = true;
                        }
                        else if (even.StartTime == time12)
                        {

                            mon12 = true;
                        }
                        else if (even.StartTime == time13)
                        {

                            mon13 = true;
                        }
                        else if (even.StartTime == time14)
                        {

                            mon14 = true;
                        }
                        else if (even.StartTime == time15)
                        {

                            mon15 = true;
                        }
                        else if (even.StartTime == time16)
                        {

                            mon16 = true;
                        }
                        else if (even.StartTime == time17)
                        {

                            mon17 = true;
                        }
                        else if (even.StartTime == time18)
                        {

                            mon18 = true;
                        }
                        else if (even.StartTime == time19)
                        {

                            mon19 = true;
                        }
                        else if (even.StartTime == time20)
                        {

                            mon20 = true;
                        }
                        else if (even.StartTime == time21)
                        {

                            mon21 = true;
                        }
                        else if (even.StartTime == time22)
                        {

                            mon22 = true;
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
        public void TueTime()
        {
            Console.WriteLine("pog");
            IsBusy = true;
            TimeSpan time8 = new TimeSpan(8, 0, 0);
            TimeSpan time9 = new TimeSpan(9, 0, 0);
            TimeSpan time10 = new TimeSpan(10, 0, 0);
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            TimeSpan time14 = new TimeSpan(14, 0, 0);
            TimeSpan time15 = new TimeSpan(15, 0, 0);
            TimeSpan time16 = new TimeSpan(16, 0, 0);
            TimeSpan time17 = new TimeSpan(17, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time22 = new TimeSpan(22, 0, 0);
            TimeSpan time19 = new TimeSpan(19, 0, 0);
            TimeSpan time20 = new TimeSpan(20, 0, 0);
            TimeSpan time21 = new TimeSpan(21, 0, 0);
            //   Console.WriteLine(time8);
            try
            {
                foreach (var even in Events)
                {

                    if ((int)even.Date.DayOfWeek == 2 && even.Date.Day.ToString() == tuesday)
                    {
                        Console.WriteLine("I made it");
                        if (even.StartTime == time8)
                        {
                            tue8 = true;
                        }
                        else if (even.StartTime == time9)
                        {

                            tue9 = true;
                        }
                        else if (even.StartTime == time10)
                        {

                            tue10 = true;
                        }
                        else if (even.StartTime == time11)
                        {

                            tue11 = true;
                        }
                        else if (even.StartTime == time12)
                        {

                            tue12 = true;
                        }
                        else if (even.StartTime == time13)
                        {

                            tue13 = true;
                        }
                        else if (even.StartTime == time14)
                        {

                            tue14 = true;
                        }
                        else if (even.StartTime == time15)
                        {

                            tue15 = true;
                        }
                        else if (even.StartTime == time16)
                        {

                            tue16 = true;
                        }
                        else if (even.StartTime == time17)
                        {

                            tue17 = true;
                        }
                        else if (even.StartTime == time18)
                        {

                            tue18 = true;
                        }
                        else if (even.StartTime == time19)
                        {

                            tue19 = true;
                        }
                        else if (even.StartTime == time20)
                        {

                            tue20 = true;
                        }
                        else if (even.StartTime == time21)
                        {

                            tue21 = true;
                        }
                        else if (even.StartTime == time22)
                        {
                            tue22 = true;
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
        public void WedTime()
        {
            Console.WriteLine("pog");
            IsBusy = true;
            TimeSpan time8 = new TimeSpan(8, 0, 0);
            TimeSpan time9 = new TimeSpan(9, 0, 0);
            TimeSpan time10 = new TimeSpan(10, 0, 0);
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            TimeSpan time14 = new TimeSpan(14, 0, 0);
            TimeSpan time15 = new TimeSpan(15, 0, 0);
            TimeSpan time16 = new TimeSpan(16, 0, 0);
            TimeSpan time17 = new TimeSpan(17, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time22 = new TimeSpan(22, 0, 0);
            TimeSpan time19 = new TimeSpan(19, 0, 0);
            TimeSpan time20 = new TimeSpan(20, 0, 0);
            TimeSpan time21 = new TimeSpan(21, 0, 0);
            //   Console.WriteLine(time8);
            try
            {
                foreach (var even in Events)
                {

                    if ((int)even.Date.DayOfWeek == 3 && even.Date.Day.ToString() == wednesday)
                    {
                        Console.WriteLine("I made it");
                        if (even.StartTime == time8)
                        {
                            wed8 = true;
                        }
                        else if (even.StartTime == time9)
                        {
                            wed9 = true;
                        }
                        else if (even.StartTime == time10)
                        {

                            wed10 = true;
                        }
                        else if (even.StartTime == time11)
                        {

                            wed11 = true;
                        }
                        else if (even.StartTime == time12)
                        {

                            wed12 = true;
                        }
                        else if (even.StartTime == time13)
                        {

                            wed13 = true;
                        }
                        else if (even.StartTime == time14)
                        {

                            wed14 = true;
                        }
                        else if (even.StartTime == time15)
                        {

                            wed15 = true;
                        }
                        else if (even.StartTime == time16)
                        {

                            wed16 = true;
                        }
                        else if (even.StartTime == time17)
                        {

                            wed17 = true;
                        }
                        else if (even.StartTime == time18)
                        {

                            wed18 = true;
                        }
                        else if (even.StartTime == time19)
                        {

                            wed19 = true;
                        }
                        else if (even.StartTime == time20)
                        {

                            wed20 = true;
                        }
                        else if (even.StartTime == time21)
                        {

                            wed21 = true;
                        }
                        else if (even.StartTime == time22)
                        {

                            wed22 = true;
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
        public void ThurTime()
        {
            Console.WriteLine("pog");
            IsBusy = true;
            TimeSpan time8 = new TimeSpan(8, 0, 0);
            TimeSpan time9 = new TimeSpan(9, 0, 0);
            TimeSpan time10 = new TimeSpan(10, 0, 0);
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            TimeSpan time14 = new TimeSpan(14, 0, 0);
            TimeSpan time15 = new TimeSpan(15, 0, 0);
            TimeSpan time16 = new TimeSpan(16, 0, 0);
            TimeSpan time17 = new TimeSpan(17, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time22 = new TimeSpan(22, 0, 0);
            TimeSpan time19 = new TimeSpan(19, 0, 0);
            TimeSpan time20 = new TimeSpan(20, 0, 0);
            TimeSpan time21 = new TimeSpan(21, 0, 0);
            //   Console.WriteLine(time8);
            try
            {
                foreach (var even in Events)
                {

                    if ((int)even.Date.DayOfWeek == 4 && even.Date.Day.ToString() == thursday)
                    {
                        Console.WriteLine("I made it");
                        if (even.StartTime == time8)
                        {
                            thur8 = true;
                        }
                        else if (even.StartTime == time9)
                        {

                            thur9 = true;
                        }
                        else if (even.StartTime == time10)
                        {

                            thur10 = true;
                        }
                        else if (even.StartTime == time11)
                        {

                            thur11 = true;
                        }
                        else if (even.StartTime == time12)
                        {

                            thur12 = true;
                        }
                        else if (even.StartTime == time13)
                        {

                            thur13 = true;
                        }
                        else if (even.StartTime == time14)
                        {

                            thur14 = true;
                        }
                        else if (even.StartTime == time15)
                        {

                            thur15 = true;
                        }
                        else if (even.StartTime == time16)
                        {

                            thur16 = true;
                        }
                        else if (even.StartTime == time17)
                        {

                            thur17 = true;
                        }
                        else if (even.StartTime == time18)
                        {

                            thur18 = true;
                        }
                        else if (even.StartTime == time19)
                        {

                            thur19 = true;
                        }
                        else if (even.StartTime == time20)
                        {

                            thur20 = true;
                        }
                        else if (even.StartTime == time21)
                        {

                            thur21 = true;
                        }
                        else if (even.StartTime == time22)
                        {

                            thur22 = true;
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
        public void FriTime()
        {
            Console.WriteLine("pog");
            IsBusy = true;
            TimeSpan time8 = new TimeSpan(8, 0, 0);
            TimeSpan time9 = new TimeSpan(9, 0, 0);
            TimeSpan time10 = new TimeSpan(10, 0, 0);
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            TimeSpan time14 = new TimeSpan(14, 0, 0);
            TimeSpan time15 = new TimeSpan(15, 0, 0);
            TimeSpan time16 = new TimeSpan(16, 0, 0);
            TimeSpan time17 = new TimeSpan(17, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time22 = new TimeSpan(22, 0, 0);
            TimeSpan time19 = new TimeSpan(19, 0, 0);
            TimeSpan time20 = new TimeSpan(20, 0, 0);
            TimeSpan time21 = new TimeSpan(21, 0, 0);
            //   Console.WriteLine(time8);
            try
            {
                foreach (var even in Events)
                {

                    if ((int)even.Date.DayOfWeek == 5 && even.Date.Day.ToString() == friday)
                    {
                        Console.WriteLine("I made it");
                        if (even.StartTime == time8)
                        {
                            fri8 = true;
                        }
                        else if (even.StartTime == time9)
                        {

                            fri9 = true;
                        }
                        else if (even.StartTime == time10)
                        {

                            fri10 = true;
                        }
                        else if (even.StartTime == time11)
                        {

                            fri11 = true;
                        }
                        else if (even.StartTime == time12)
                        {

                            fri12 = true;
                        }
                        else if (even.StartTime == time13)
                        {

                            fri13 = true;
                        }
                        else if (even.StartTime == time14)
                        {

                            fri14 = true;
                        }
                        else if (even.StartTime == time15)
                        {

                            fri15 = true;
                        }
                        else if (even.StartTime == time16)
                        {

                            fri16 = true;
                        }
                        else if (even.StartTime == time17)
                        {

                            fri17 = true;
                        }
                        else if (even.StartTime == time18)
                        {

                            fri18 = true;
                        }
                        else if (even.StartTime == time19)
                        {

                            fri19 = true;
                        }
                        else if (even.StartTime == time20)
                        {

                            fri20 = true;
                        }
                        else if (even.StartTime == time21)
                        {

                            fri21 = true;
                        }
                        else if (even.StartTime == time22)
                        {

                            fri22 = true;
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
        public void SatTime()
        {
            Console.WriteLine("pog");
            IsBusy = true;
            TimeSpan time8 = new TimeSpan(8, 0, 0);
            TimeSpan time9 = new TimeSpan(9, 0, 0);
            TimeSpan time10 = new TimeSpan(10, 0, 0);
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            TimeSpan time14 = new TimeSpan(14, 0, 0);
            TimeSpan time15 = new TimeSpan(15, 0, 0);
            TimeSpan time16 = new TimeSpan(16, 0, 0);
            TimeSpan time17 = new TimeSpan(17, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time22 = new TimeSpan(22, 0, 0);
            TimeSpan time19 = new TimeSpan(19, 0, 0);
            TimeSpan time20 = new TimeSpan(20, 0, 0);
            TimeSpan time21 = new TimeSpan(21, 0, 0);
            //   Console.WriteLine(time8);
            try
            {
                foreach (var even in Events)
                {

                    if ((int)even.Date.DayOfWeek == 6 && even.Date.Day.ToString() == saturday)
                    {
                        Console.WriteLine("I made it");
                        if (even.StartTime == time8)
                        {
                            sat8 = true;
                        }
                        else if (even.StartTime == time9)
                        {

                            sat9 = true;
                        }
                        else if (even.StartTime == time10)
                        {

                            sat10 = true;
                        }
                        else if (even.StartTime == time11)
                        {

                            sat11 = true;
                        }
                        else if (even.StartTime == time12)
                        {

                            sat12 = true;
                        }
                        else if (even.StartTime == time13)
                        {

                            sat13 = true;
                        }
                        else if (even.StartTime == time14)
                        {

                            sat14 = true;
                        }
                        else if (even.StartTime == time15)
                        {

                            sat15 = true;
                        }
                        else if (even.StartTime == time16)
                        {

                            sat16 = true;
                        }
                        else if (even.StartTime == time17)
                        {

                            sat17 = true;
                        }
                        else if (even.StartTime == time18)
                        {

                            sat18 = true;
                        }
                        else if (even.StartTime == time19)
                        {

                            sat19 = true;
                        }
                        else if (even.StartTime == time20)
                        {

                            sat20 = true;
                        }
                        else if (even.StartTime == time21)
                        {

                            sat21 = true;
                        }
                        else if (even.StartTime == time22)
                        {

                            sat22 = true;
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
        public void SunTime()
        {
            Console.WriteLine("pog");
            IsBusy = true;
            TimeSpan time8 = new TimeSpan(8, 0, 0);
            TimeSpan time9 = new TimeSpan(9, 0, 0);
            TimeSpan time10 = new TimeSpan(10, 0, 0);
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            TimeSpan time14 = new TimeSpan(14, 0, 0);
            TimeSpan time15 = new TimeSpan(15, 0, 0);
            TimeSpan time16 = new TimeSpan(16, 0, 0);
            TimeSpan time17 = new TimeSpan(17, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time22 = new TimeSpan(22, 0, 0);
            TimeSpan time19 = new TimeSpan(19, 0, 0);
            TimeSpan time20 = new TimeSpan(20, 0, 0);
            TimeSpan time21 = new TimeSpan(21, 0, 0);
            //   Console.WriteLine(time8);
            try
            {
                foreach (var even in Events)
                {

                    if ((int)even.Date.DayOfWeek == 0 && even.Date.Day.ToString() == sunday)
                    {
                        Console.WriteLine("I made it");
                        if (even.StartTime == time8)
                        {
                            sun8 = true;
                        }
                        else if (even.StartTime == time9)
                        {

                            sun9 = true;
                        }
                        else if (even.StartTime == time10)
                        {

                            sun10 = true;
                        }
                        else if (even.StartTime == time11)
                        {

                            sun11 = true;
                        }
                        else if (even.StartTime == time12)
                        {

                            sun12 = true;
                        }
                        else if (even.StartTime == time13)
                        {

                            sun13 = true;
                        }
                        else if (even.StartTime == time14)
                        {

                            sun14 = true;
                        }
                        else if (even.StartTime == time15)
                        {

                            sun15 = true;
                        }
                        else if (even.StartTime == time16)
                        {

                            sun16 = true;
                        }
                        else if (even.StartTime == time17)
                        {

                            sun17 = true;
                        }
                        else if (even.StartTime == time18)
                        {

                            sun18 = true;
                        }
                        else if (even.StartTime == time19)
                        {

                            sun19 = true;
                        }
                        else if (even.StartTime == time20)
                        {

                            sun20 = true;
                        }
                        else if (even.StartTime == time21)
                        {

                            sun21 = true;
                        }
                        else if (even.StartTime == time22)
                        {

                            sun22 = true;
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
        public bool Mon8
        {
            get
            {
                return mon8;
            }
       
        }
        public bool Mon9
        {
            get
            {
                return mon9;
            }

        }
        public bool Mon10
        {
            get
            {
                return mon10;
            }

        }
        public bool Mon11
        {
            get
            {
                return mon11;
            }

        }
        public bool Mon12
        {
            get
            {
                return mon12;
            }

        }
        public bool Mon13
        {
            get
            {
                return mon13;
            }

        }
        public bool Mon14
        {
            get
            {
                return mon14;
            }

        }
        public bool Mon15
        {
            get
            {
                return mon15;
            }

        }
        public bool Mon16
        {
            get
            {
                return mon16;
            }

        }
        public bool Mon17
        {
            get
            {
                return mon17;
            }

        }
        public bool Mon18
        {
            get
            {
                return mon18;
            }

        }
        public bool Tue8
        {
            get
            {
                return tue8;
            }

        }
        public bool Tue9
        {
            get
            {
                return tue9;
            }

        }
        public bool Tue10
        {
            get
            {
                return tue10;
            }

        }
        public bool Tue11
        {
            get
            {
                return tue11;
            }

        }
        public bool Tue12
        {
            get
            {
                return tue12;
            }

        }
        public bool Tue13
        {
            get
            {
                return tue13;
            }

        }
        public bool Tue14
        {
            get
            {
                return tue14;
            }

        }
        public bool Tue15
        {
            get
            {
                return tue15;
            }

        }
        public bool Tue16
        {
            get
            {
                return tue16;
            }

        }
        public bool Tue17
        {
            get
            {
                return tue17;
            }

        }
        public bool Tue18
        {
            get
            {
                return tue18;
            }

        }
        public bool Wed8
        {
            get
            {
                return wed8;
            }

        }
        public bool Wed9
        {
            get
            {
                return wed9;
            }

        }
        public bool Wed10
        {
            get
            {
                return wed10;
            }

        }
        public bool Wed11
        {
            get
            {
                return wed11;
            }

        }
        public bool Wed12
        {
            get
            {
                return wed12;
            }

        }
        public bool Wed13
        {
            get
            {
                return wed13;
            }

        }
        public bool Wed14
        {
            get
            {
                return wed14;
            }

        }
        public bool Wed15
        {
            get
            {
                return wed15;
            }

        }
        public bool Wed16
        {
            get
            {
                return wed16;
            }

        }
        public bool Wed17
        {
            get
            {
                return wed17;
            }

        }
        public bool Wed18
        {
            get
            {
                return wed18;
            }

        }
        public bool Thur8
        {
            get
            {
                return thur8;
            }

        }
        public bool Thur9
        {
            get
            {
                return thur9;
            }

        }
        public bool Thur10
        {
            get
            {
                return thur10;
            }

        }
        public bool Thur11
        {
            get
            {
                return thur11;
            }

        }
        public bool Thur12
        {
            get
            {
                return thur12;
            }

        }
        public bool Thur13
        {
            get
            {
                return thur13;
            }

        }
        public bool Thur14
        {
            get
            {
                return thur14;
            }

        }
        public bool Thur15
        {
            get
            {
                return thur15;
            }

        }
        public bool Thur16
        {
            get
            {
                return thur16;
            }

        }
        public bool Thur17
        {
            get
            {
                return thur17;
            }

        }
        public bool Thur18
        {
            get
            {
                return thur18;
            }

        }
        public bool Fri8
        {
            get
            {
                return fri8;
            }

        }
        public bool Fri9
        {
            get
            {
                return fri9;
            }

        }
        public bool Fri10
        {
            get
            {
                return fri10;
            }

        }
        public bool Fri11
        {
            get
            {
                return fri11;
            }

        }
        public bool Fri12
        {
            get
            {
                return fri12;
            }

        }
        public bool Fri13
        {
            get
            {
                return fri13;
            }

        }
        public bool Fri14
        {
            get
            {
                return fri14;
            }

        }
        public bool Fri15
        {
            get
            {
                return fri15;
            }

        }
        public bool Fri16
        {
            get
            {
                return fri16;
            }

        }
        public bool Fri17
        {
            get
            {
                return fri17;
            }

        }
        public bool Fri18
        {
            get
            {
                return fri18;
            }

        }
        public bool Sat8
        {
            get
            {
                return sat8;
            }

        }
        public bool Sat9
        {
            get
            {
                return sat9;
            }

        }
        public bool Sat10
        {
            get
            {
                return sat10;
            }

        }
        public bool Sat11
        {
            get
            {
                return sat11;
            }

        }
        public bool Sat12
        {
            get
            {
                return sat12;
            }

        }
        public bool Sat13
        {
            get
            {
                return sat13;
            }

        }
        public bool Sat14
        {
            get
            {
                return sat14;
            }

        }
        public bool Sat15
        {
            get
            {
                return sat15;
            }

        }
        public bool Sat16
        {
            get
            {
                return sat16;
            }

        }
        public bool Sat17
        {
            get
            {
                return sat17;
            }

        }
        public bool Sat18
        {
            get
            {
                return sat18;
            }

        }
        public bool Sun8
        {
            get
            {
                return sun8;
            }

        }
        public bool Sun9
        {
            get
            {
                return sun9;
            }

        }
        public bool Sun10
        {
            get
            {
                return sun10;
            }

        }
        public bool Sun11
        {
            get
            {
                return sun11;
            }

        }
        public bool Sun12
        {
            get
            {
                return sun12;
            }

        }
        public bool Sun13
        {
            get
            {
                return sun13;
            }

        }
        public bool Sun14
        {
            get
            {
                return sun14;
            }

        }
        public bool Sun15
        {
            get
            {
                return sun15;
            }

        }
        public bool Sun16
        {
            get
            {
                return sun16;
            }

        }
        public bool Sun17
        {
            get
            {
                return sun17;
            }

        }
        public bool Sun18
        {
            get
            {
                return sun18;
            }

        }
    }
}

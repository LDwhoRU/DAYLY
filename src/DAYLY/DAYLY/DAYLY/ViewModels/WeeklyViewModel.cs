using DAYLY.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DAYLY.ViewModels
{
    class WeeklyViewModel : BaseViewModel
    {
        bool[] mon = new bool[15];
        bool[] tue = new bool[15];
        bool[] wed = new bool[15];
        bool[] thur = new bool[15];
        bool[] fri = new bool[15];
        bool[] sat = new bool[15];
        bool[] sun = new bool[15];
        string[] week = new string[7];
        
        string nmon8, nmon9, nmon10, nmon11, nmon12, nmon13, nmon14, nmon15, nmon16, nmon17, nmon18, nmon19, nmon20, nmon21, nmon22;
        string today;
        double tmon8;
         string monday, tuesday, wednesday, thursday,friday,saturday,sunday;
        TimeSpan[] TimerArray = new TimeSpan[15];
        TimeSpan time8 = new TimeSpan(8, 0, 0);
        TimeSpan time1 = TimeSpan.FromHours(1);
        
        public ObservableCollection<Event> Events { get; }
     
        public WeeklyViewModel()
        {
            TimerArray[0] = time8;
            Title = "Weekly";
            DateTime dt = DateTime.Today;
            Events = new ObservableCollection<Event>();
            Today = dt.DayOfWeek.ToString() + " " + dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
            Task.Run(async () => await ExecuteLoadItemsCommand());
             GetWeek();
           //  MonTime();
          //  TueTime();
           // WedTime();
           // ThurTime();
           // FriTime();
            //SatTime();
            WeekTime();
          //  Console.WriteLine(mon12);
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
               var Sun = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Sunday);
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
            bool[][] bweek = new bool[][] {sun,mon,tue,wed,thur,fri,sat };
            IsBusy = true;
            week[0] = sunday;
            week[1] = monday;
            week[2] = tuesday;
                week[3] = wednesday;
            week[4] = thursday;
            week[5] = friday;
            week[6] = saturday;
            //   Console.WriteLine(time8);
            
            for (int i = 1; i < TimerArray.Length; i++)
            {
                TimerArray[i] = TimerArray[i - 1].Add(time1);
                Console.WriteLine(TimerArray[i - 1]);
            }
          
            try
            {
                int dayy = 0;
                foreach (var day in week) { 
                for (int i = 0; i < sun.Length; i++)
                {
                    bweek[dayy][i] = false;
                }
                foreach (var even in Events)
                {

                    if ((int)even.Date.DayOfWeek == dayy && even.Date.Day.ToString() == day)
                    {
                        Console.WriteLine("I made it");
                        for (int i = 0; i < TimerArray.Length; i++)
                        {
                                
                                if (even.StartTime == TimerArray[i])
                            {
                                bweek[dayy][i] = true;
                                TimeSpan duration = even.EndTime.Subtract(even.StartTime);
                                int hours = duration.Hours;

                                    int z = 1;
                                    for (int j = i; z <= hours; j++)
                                    {
                                        bweek[dayy][j] = true;
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
                return mon[0];
            }
       
        }
        public bool Mon9
        {
            get
            {
                return mon[1];
            }

        }
        public bool Mon10
        {
            get
            {
                return mon[2];
            }

        }
        public bool Mon11
        {
            get
            {
                return mon[3];
            }

        }
        public bool Mon12
        {
            get
            {
                return mon[4];
            }

        }
        public bool Mon13
        {
            get
            {
                return mon[5];
            }

        }
        public bool Mon14
        {
            get
            {
                return mon[6];
            }

        }
        public bool Mon15
        {
            get
            {
                return mon[7];
            }

        }
        public bool Mon16
        {
            get
            {
                return mon[8];
            }

        }
        public bool Mon17
        {
            get
            {
                return mon[9];
            }

        }
        public bool Mon18
        {
            get
            {
                return mon[10];
            }

        }
        public bool Tue8
        {
            get
            {
                return tue[0];
            }

        }
        public bool Tue9
        {
            get
            {
                return tue[1];
            }

        }
        public bool Tue10
        {
            get
            {
                return tue[2];
            }

        }
        public bool Tue11
        {
            get
            {
                return tue[3];
            }

        }
        public bool Tue12
        {
            get
            {
                return tue[4];
            }

        }
        public bool Tue13
        {
            get
            {
                return tue[5];
            }

        }
        public bool Tue14
        {
            get
            {
                return tue[6];
            }

        }
        public bool Tue15
        {
            get
            {
                return tue[7];
            }

        }
        public bool Tue16
        {
            get
            {
                return tue[8];
            }

        }
        public bool Tue17
        {
            get
            {
                return tue[9];
            }

        }
        public bool Tue18
        {
            get
            {
                return tue[10];
            }

        }
        public bool Wed8
        {
            get
            {
                return wed[0];
            }

        }
        public bool Wed9
        {
            get
            {
                return wed[1];
            }

        }
        public bool Wed10
        {
            get
            {
                return wed[2];
            }

        }
        public bool Wed11
        {
            get
            {
                return wed[3];
            }

        }
        public bool Wed12
        {
            get
            {
                return wed[4];
            }

        }
        public bool Wed13
        {
            get
            {
                return wed[5];
            }

        }
        public bool Wed14
        {
            get
            {
                return wed[6];
            }

        }
        public bool Wed15
        {
            get
            {
                return wed[7];
            }

        }
        public bool Wed16
        {
            get
            {
                return wed[8];
            }

        }
        public bool Wed17
        {
            get
            {
                return wed[9];
            }

        }
        public bool Wed18
        {
            get
            {
                return wed[10];
            }

        }
        public bool Thur8
        {
            get
            {
                return thur[0];
            }

        }
        public bool Thur9
        {
            get
            {
                return thur[1];
            }

        }
        public bool Thur10
        {
            get
            {
                return thur[2];
            }

        }
        public bool Thur11
        {
            get
            {
                return thur[3];
            }

        }
        public bool Thur12
        {
            get
            {
                return thur[4];
            }

        }
        public bool Thur13
        {
            get
            {
                return thur[5];
            }

        }
        public bool Thur14
        {
            get
            {
                return thur[6];
            }

        }
        public bool Thur15
        {
            get
            {
                return thur[7];
            }

        }
        public bool Thur16
        {
            get
            {
                return thur[8];
            }

        }
        public bool Thur17
        {
            get
            {
                return thur[9];
            }

        }
        public bool Thur18
        {
            get
            {
                return thur[10];
            }

        }
        public bool Fri8
        {
            get
            {
                return fri[0];
            }

        }
        public bool Fri9
        {
            get
            {
                return fri[1];
            }

        }
        public bool Fri10
        {
            get
            {
                return fri[2];
            }

        }
        public bool Fri11
        {
            get
            {
                return fri[3];
            }

        }
        public bool Fri12
        {
            get
            {
                return fri[4];
            }

        }
        public bool Fri13
        {
            get
            {
                return fri[5];
            }

        }
        public bool Fri14
        {
            get
            {
                return fri[6];
            }

        }
        public bool Fri15
        {
            get
            {
                return fri[7];
            }

        }
        public bool Fri16
        {
            get
            {
                return fri[8];
            }

        }
        public bool Fri17
        {
            get
            {
                return fri[9];
            }

        }
        public bool Fri18
        {
            get
            {
                return fri[10];
            }

        }
        public bool Sat8
        {
            get
            {
                return sat[0];
            }

        }
        public bool Sat9
        {
            get
            {
                return sat[1];
            }

        }
        public bool Sat10
        {
            get
            {
                return sat[2];
            }

        }
        public bool Sat11
        {
            get
            {
                return sat[3];
            }

        }
        public bool Sat12
        {
            get
            {
                return sat[4];
            }

        }
        public bool Sat13
        {
            get
            {
                return sat[5];
            }

        }
        public bool Sat14
        {
            get
            {
                return sat[6];
            }

        }
        public bool Sat15
        {
            get
            {
                return sat[7];
            }

        }
        public bool Sat16
        {
            get
            {
                return sat[8];
            }

        }
        public bool Sat17
        {
            get
            {
                return sat[9];
            }

        }
        public bool Sat18
        {
            get
            {
                return sat[10];
            }

        }
        public bool Sun8
        {
            get
            {
                return sun[0];
            }

        }
        public bool Sun9
        {
            get
            {
                return sun[1];
            }

        }
        public bool Sun10
        {
            get
            {
                return sun[2];
            }

        }
        public bool Sun11
        {
            get
            {
                return sun[3];
            }

        }
        public bool Sun12
        {
            get
            {
                return sun[4];
            }

        }
        public bool Sun13
        {
            get
            {
                return sun[5];
            }

        }
        public bool Sun14
        {
            get
            {
                return sun[6];
            }

        }
        public bool Sun15
        {
            get
            {
                return sun[7];
            }

        }
        public bool Sun16
        {
            get
            {
                return sun[8];
            }

        }
        public bool Sun17
        {
            get
            {
                return sun[9];
            }

        }
        public bool Sun18
        {
            get
            {
                return sun[10];
            }

        }
        public double Tmon8
        {
            get
            {
                return tmon8;
            }
        }
    }
}

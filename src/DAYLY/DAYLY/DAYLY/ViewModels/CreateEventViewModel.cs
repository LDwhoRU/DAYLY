using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using DAYLY.Models;
using SQLite;
using System.Linq;
using DAYLY.Views;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using DAYLY.ViewModels;
using DAYLY;
using System.Globalization;
using System.Diagnostics;

namespace DAYLY.ViewModels
{
    public class CreateEventViewModel : INotifyPropertyChanged
    {
        private TimeSpan _StartTime;
        private string _StartTimeText;
        private TimeSpan _EndTime;
        private string _EndTimeText;
        private DateTime _EventDate;
        private string _EventDateText;
        public Command SaveEvent { get; }
        public Command LoadType { get; }
        public Command SelectType { get; }
        public Command SelectRepeat { get; }
        public Command LoadRepeat { get; }
        public Command SelectAlert { get; }
        public Command LoadAlert { get; }
        public Command SaveNote { get; }
        public Command LoadNote { get; }
        private List<Event> _EventListView;
        private string _EventName;
        private bool _Online;
        private bool _AllDay;
        private string _EventType;
        private string _Repeat;
        private string _Alert;
        public SQLiteConnection conn;
        private INavigation _NavigationStack;

        private string TimeConvert(TimeSpan inputTime)
        {
            string temp;
            if (inputTime.Hours >= 12)
            {
                TimeSpan twelveHours = new TimeSpan(12, 0, 0);
                temp = inputTime.Subtract(twelveHours).ToString(@"hh\:mm") + "PM";
            }
            else
            {
                temp = inputTime.ToString(@"hh\:mm") + "AM";
            }
            return temp;
        }
        public string Alert
        {
            get
            {
                return _Alert;
            }
            set
            {
                _Alert = value;
                Console.WriteLine(_Alert);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alert)));
            }
        }
        public string Repeat
        {
            get
            {
                return _Repeat;
            }
            set
            {
                _Repeat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Repeat)));
            }
        }
        public string EventType
        {
            get
            {
                return _EventType;
            }
            set
            {
                _EventType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventType)));
            }
        }
        public bool Online
        {
            get
            {
                return _Online;
            }
            set
            {
                if (value == true)
                {
                    _Online = value;
                }
                else
                {
                    _Online = false;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Online)));
            }
        }

        public bool AllDay
        {
            get
            {
                return _AllDay;
            }
            set
            {
                if (value == true)
                {
                    _AllDay = value;
                }
                else
                {
                    _AllDay = false;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllDay)));
            }
        }

        public string EventName
        {
            get
            {
                return _EventName;
            }
            set
            {
                _EventName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventName)));
            }
        }

        public TimeSpan StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
                StartTimeText = value.ToString();

                if (_StartTime > _EndTime)
                {
                    EndTime = _StartTime + TimeSpan.FromHours(2);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartTime)));
            }
        }
        public string StartTimeText
        {
            get
            {
                return _StartTimeText;
            }
            set
            {
                _StartTimeText = TimeConvert(_StartTime);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartTimeText)));
            }
        }

        public TimeSpan EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                _EndTime = value;
                EndTimeText = value.ToString();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndTime)));
            }
        }

        public string EndTimeText
        {
            get
            {
                return _EndTimeText;
            }
            set
            {
                _EndTimeText = TimeConvert(_EndTime);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndTimeText)));
            }
        }

        public List<Event> EventListView
        {
            get
            {
                return _EventListView;
            }
            set
            {
                _EventListView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventListView)));
            }
        }

        public DateTime EventDate
        {
            get
            {
                return _EventDate;
            }
            set
            {
                _EventDate = value;
                EventDateText = value.ToString();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventDate)));
            }
        }

        public string EventDateText
        {
            get
            {
                return _EventDateText;
            }
            set
            {
                _EventDateText = EventDate.Day.ToString() + "/" + EventDate.Month.ToString() + "/" + EventDate.Year.ToString();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventDateText)));
            }
        }

        private void WriteEvent()
        {
            int isSuccess;
            // Add Test Note
            Note newNote = new Note
            {
                Description = "Testing",
                URL = "www.url.com"
            };
            isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(newNote);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inserting Note Failed");
                throw ex;
            }

            // Add Programme
            Programme newProgramme = new Programme
            {
                Name = "Cal",
                HexColour = "FFFFFF"
            };
            isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(newProgramme);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inserting Programme Failed");
                throw ex;
            }
            Console.WriteLine(_Alert);
            // Add Event
            Event newEvent = new Event
            {
                Name = EventName,
                Type = EventType,
                Date = EventDate,
                StartTime = StartTime,
                EndTime = EndTime,
                AllDay = AllDay,
                IsOnline = Online,
                RepeatInterval = Repeat,
                AlertInterval = Alert,
                NoteId = newNote.Id,
                ProgrammeId = newProgramme.Id,
            };
            isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(newEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inserting Event Failed");
                throw ex;
            }
        }

        public CreateEventViewModel()
        {
            SaveEvent = new Command(() => {
                WriteEvent();
                EventListView = (from x in conn.Table<Event>() select x).ToList();
            });

            SelectType = new Command(async (typeValue) => {
                EventType = (string)typeValue;
                await _NavigationStack.PopToRootAsync();
            });

            LoadType = new Command(async () => {
                await _NavigationStack.PushAsync(new EventType(this));
            });

            SelectRepeat = new Command(async (repeatValue) => {
                Repeat = (string)repeatValue;
                await _NavigationStack.PopToRootAsync();
            });

            LoadRepeat = new Command(async () => {
                await _NavigationStack.PushAsync(new Repeat(this));
            });

            SelectAlert = new Command(async (alertValue) => {
                Alert = (string)alertValue;
                await _NavigationStack.PopToRootAsync();
            });

            LoadAlert = new Command(async () => {
                await _NavigationStack.PushAsync(new Alert(this));
            });

            //LoadNote = new Command(async () => {
            //    await _NavigationStack.PushAsync(new Notes(this));
            //});
        }

        public void Initalise(INavigation navigation)
        {
            _NavigationStack = navigation;

            EventDate = DateTime.Now;
            StartTime = DateTime.Now.TimeOfDay;
            EndTime = StartTime + TimeSpan.FromHours(2);
            EventType = "Lecture";
            Repeat = "None";
            Alert = "15 Minutes";

            conn = DependencyService.Get<Isqlite>().GetConnection();
            try
            {
                conn.DropTable<Event>();
                conn.DropTable<Note>();
                conn.DropTable<Programme>();
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.CreateTable<Note>();
            conn.CreateTable<Programme>();
            conn.CreateTable<Event>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

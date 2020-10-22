using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using DAYLY.Models;
using SQLite;
using System.Linq;

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
        private List<Event> _EventListView;
        private string _EventName;
        private bool _Online;
        private bool _AllDay;
        public SQLiteConnection conn;

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

        public bool Online
        {
            get
            {
                return _Online;
            }
            set
            {
                _Online = value;
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
                _AllDay = value;
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

            // Add Event
            Event newEvent = new Event
            {
                Name = EventName,
                Type = "Event",
                Date = EventDate,
                StartTime = StartTime,
                EndTime = EndTime,
                AllDay = AllDay,
                IsOnline = Online,
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

        }

        public void Initalise()
        {
            EventDate = DateTime.Now;
            StartTime = DateTime.Now.TimeOfDay;
            EndTime = StartTime + TimeSpan.FromHours(2);

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

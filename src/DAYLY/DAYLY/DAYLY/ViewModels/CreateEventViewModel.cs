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
        public Command LoadLocation { get; }
        public Command LoadCustomLocation { get; }
        public Command SaveCustomLocation { get; }
        public Command SelectLocation { get; }
        public Command LoadNewCalendar { get; }
        public Command SaveNewCalendar { get; }
        public Command SelectCalendar { get; }
        public Command LoadReminder { get; }
        private string _LocationAlias;
        private string _LocationAddress;
        private string _LocationSuburb;
        private string _LocationState;
        private string _LocationPostcode;
        private List<Event> _EventListView;
        private List<Location> _LocationListView;
        private List<ProgrammeViewModel> _CalendarListView;
        private int _LocationListViewHeight;
        private int _CalendarListViewWidth;
        private string _EventName;
        private bool _Online;
        private bool _AllDay;
        private string _EventType;
        private string _Repeat;
        private string _Alert;
        private string _NoteURL;
        private string _NoteDescription;
        private int _CurrentNoteID;
        private int _CurrentLocationID;
        private int _CurrentCalendarID;
        private string _CurrentLocationAlias;
        public SQLiteConnection conn;
        private INavigation _NavigationStack;
        private bool _PopupCalendar;
        private string _NewCalendarName;
        private string _NewCalendarColour;
        public string NewCalendarColour
        {
            get
            {
                return _NewCalendarColour;
            }
            set
            {
                _NewCalendarColour = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewCalendarColour)));
            }
        }
        public string NewCalendarName
        {
            get
            {
                return _NewCalendarName;
            }
            set
            {
                _NewCalendarName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewCalendarName)));
            }
        }
        public bool PopupCalendarVisible
        {
            get
            {
                return _PopupCalendar;
            }
            set
            {
                _PopupCalendar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupCalendarVisible)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupCalendarHidden)));
            }
        }
        public bool PopupCalendarHidden
        {
            get
            {
                return !_PopupCalendar;
            }
            set
            {
                _PopupCalendar = !value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupCalendarHidden)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupCalendarVisible)));
            }
        }
        public string CurrentLocationAlias
        {
            get
            {
                return _CurrentLocationAlias;
            }
            set
            {
                _CurrentLocationAlias = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentLocationAlias)));
            }
        }
        public int CurrentCalendarID
        {
            get
            {
                return _CurrentCalendarID;
            }
            set
            {
                _CurrentCalendarID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentCalendarID)));
            }
        }
        public int CurrentLocationID
        {
            get
            {
                return _CurrentLocationID;
            }
            set
            {
                _CurrentLocationID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentLocationID)));
            }
        }
        public int CalendarListViewWidth
        {
            get
            {
                return _CalendarListViewWidth;
            }
            set
            {
                _CalendarListViewWidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarListViewWidth)));
            }
        }
        public int LocationListViewHeight
        {
            get
            {
                return _LocationListViewHeight;
            }
            set
            {
                _LocationListViewHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationListViewHeight)));
            }
        }
        
        public string LocationAlias
        {
            get
            {
                return _LocationAlias;
            }
            set
            {
                _LocationAlias = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationAlias)));
            }
        }
        public string LocationAddress
        {
            get
            {
                return _LocationAddress;
            }
            set
            {
                _LocationAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationAddress)));
            }
        }
        public string LocationSuburb
        {
            get
            {
                return _LocationSuburb;
            }
            set
            {
                _LocationSuburb = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationSuburb)));
            }
        }
        public string LocationState
        {
            get
            {
                return _LocationState;
            }
            set
            {
                _LocationState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationState)));
            }
        }
        public string LocationPostcode
        {
            get
            {
                return _LocationPostcode;
            }
            set
            {
                _LocationPostcode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationPostcode)));
            }
        }

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
        public int CurrentNoteID
        {
            get
            {
                return _CurrentNoteID;
            }
            set
            {
                _CurrentNoteID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentNoteID)));
            }
        }
        public string NoteDescription
        {
            get
            {
                return _NoteDescription;
            }
            set
            {
                _NoteDescription = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteDescription)));
            }
        }
        public string NoteURL
        {
            get
            {
                return _NoteURL;
            }
            set
            {
                _NoteURL = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteURL)));
            }
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
        public List<ProgrammeViewModel> CalendarListView
        {
            get
            {
                return _CalendarListView;
            }
            set
            {
                _CalendarListView = new List<ProgrammeViewModel>();
                List<Programme> tempListView = (from x in conn.Table<Programme>() select x).ToList();
                string tempBorderColour;
                foreach (Programme programme in tempListView)
                {
                    if (programme.Id == CurrentCalendarID)
                    {
                        tempBorderColour = "#0033cc";
                    }
                    else
                    {
                        tempBorderColour = "#ffffff";
                    }
                    ProgrammeViewModel programmeViewModel = new ProgrammeViewModel(programme.Id, programme.Name, programme.HexColour, tempBorderColour);
                    _CalendarListView.Add(programmeViewModel);
                }
                CalendarListViewWidth = _CalendarListView.Count * 150;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarListView)));
            }
        }
        public List<Location> LocationListView
        {
            get
            {
                return _LocationListView;
            }
            set
            {
                _LocationListView = value;
                LocationListViewHeight = value.Count * 64;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationListView)));
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
            // Add Event
            int isSuccess;
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
                NoteId = CurrentNoteID,
                ProgrammeId = CurrentCalendarID,
                LocationId = CurrentLocationID
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
            LoadReminder = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//AddReminder");
            });

            SaveEvent = new Command(() => {
                WriteEvent();
                EventListView = (from x in conn.Table<Event>() select x).ToList();
            });

            SelectType = new Command(async (typeValue) => {
                EventType = (string)typeValue;
                await _NavigationStack.PopAsync();
            });

            LoadType = new Command(async () => {
                await _NavigationStack.PushAsync(new EventType(this));
            });

            SelectRepeat = new Command(async (repeatValue) => {
                Repeat = (string)repeatValue;
                await _NavigationStack.PopAsync();
            });

            LoadRepeat = new Command(async () => {
                await _NavigationStack.PushAsync(new Repeat(this));
            });

            SelectAlert = new Command(async (alertValue) => {
                Alert = (string)alertValue;
                await _NavigationStack.PopAsync();
            });

            LoadAlert = new Command(async () => {
                await _NavigationStack.PushAsync(new Alert(this));
            });

            SaveNote = new Command(async () => {
                int isSuccess;
                // Add Custom Note
                Note newNote = new Note
                {
                    Description = NoteDescription,
                    URL = NoteURL
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
                CurrentNoteID = newNote.Id;
                await _NavigationStack.PopAsync();
            });

            LoadNote = new Command(async () =>
            {
                await _NavigationStack.PushAsync(new Notes(this));
            });

            LoadLocation = new Command(async () =>
            {
                await _NavigationStack.PushAsync(new LocationSelection(this));
            });

            SelectLocation = new Command(async (locationValue) => {
                CurrentLocationID = (int)locationValue;
                foreach (Location location in LocationListView)
                {
                    if (location.Id == CurrentLocationID)
                    {
                        CurrentLocationAlias = location.Alias;
                    }
                }
                await _NavigationStack.PopAsync();
            });

            SaveCustomLocation = new Command(async () => {
                int isSuccess;
                // Add Custom Note
                Location newLocation = new Location
                {
                    Alias = LocationAlias,
                    StreetAddress = LocationAddress,
                    Suburb = LocationSuburb,
                    State = LocationState,
                    Postcode = int.Parse(LocationPostcode)
                };
                isSuccess = 0;
                try
                {
                    isSuccess = conn.Insert(newLocation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Inserting Location Failed");
                    throw ex;
                }

                LocationAlias = "";
                LocationAddress = "";
                LocationSuburb = "";
                LocationState = "";
                LocationPostcode = "";

                LocationListView = (from x in conn.Table<Location>() select x).ToList();
                await _NavigationStack.PopAsync();
            });

            LoadCustomLocation = new Command(async () =>
            {
                await _NavigationStack.PushAsync(new LocationCustom(this));
            });

            LoadNewCalendar = new Command(() => {
                PopupCalendarVisible = true;
            });

            SaveNewCalendar = new Command(() => {
                int isSuccess;
                // Add Programme
                string hexCode;
                switch (NewCalendarColour)
                {
                    case "Green":
                        hexCode = "#99ff33";
                        break;
                    case "Blue":
                        hexCode = "#0099ff";
                        break;
                    case "Red":
                        hexCode = "#ff5050";
                        break;
                    case "Orange":
                        hexCode = "#ff9966";
                        break;
                    case "Yellow":
                        hexCode = "#ffff99";
                        break;
                    case "Purple":
                        hexCode = "#993399";
                        break;
                    default:
                        hexCode = "#ffffff";
                        break;
                }
                Programme newProgramme = new Programme
                {
                    Name = NewCalendarName,
                    HexColour = hexCode
                };
                isSuccess = 0;
                try
                {
                    isSuccess = conn.Insert(newProgramme);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                NewCalendarName = "";
                NewCalendarColour = "";
                CurrentCalendarID = 0;

                // Save results to query
                CalendarListView = new List<ProgrammeViewModel>();

                PopupCalendarVisible = false;
            });

            SelectCalendar = new Command((calendarValue) => {
                CurrentCalendarID = 0;
                CurrentCalendarID = (int)calendarValue;
                CalendarListView = new List<ProgrammeViewModel>();
            });
        }

        public void Initalise(INavigation navigation)
        {
            _NavigationStack = navigation;
            conn = DependencyService.Get<Isqlite>().GetConnection();
            try
            {
                conn.DropTable<Event>();
                conn.DropTable<Note>();
                conn.DropTable<Location>();
                conn.DropTable<Programme>();
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.CreateTable<Note>();
            conn.CreateTable<Programme>();
            conn.CreateTable<Location>();
            conn.CreateTable<Event>();

            EventDate = DateTime.Now;
            StartTime = DateTime.Now.TimeOfDay;
            EndTime = StartTime + TimeSpan.FromHours(2);
            EventType = "Lecture";
            Repeat = "None";
            Alert = "15 Minutes";
            CurrentLocationAlias = "None";
            PopupCalendarVisible = false;
            CalendarListView = new List<ProgrammeViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

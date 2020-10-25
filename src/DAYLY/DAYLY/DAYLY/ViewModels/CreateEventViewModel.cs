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
    public class CreateEventViewModel : CreateAffairViewModel, INotifyPropertyChanged
    {
        private TimeSpan _StartTime;
        private string _StartTimeText;
        private TimeSpan _EndTime;
        private string _EndTimeText;
        
        public Command SaveEvent { get; }
        
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
        
        
        private int _LocationListViewHeight;
        
        
        private bool _Online;
        private bool _AllDay;
        
        private int _CurrentLocationID;
        
        private string _CurrentLocationAlias;
        
        
        
        private Color _LocationLabelColour;
        private Color _LocationPreviewColour;
        private Color _TimeLabelColour;
        private Color _TimePreviewColour;

        public override string EventDateText
        {
            get
            {
                return _EventDateText;
            }
            set
            {
                if (EndTime < StartTime)
                {
                    DateTime tempEventDate = EventDate.AddDays(1);
                    _EventDateText = EventDate.Day.ToString() + "/" + EventDate.Month.ToString() + " - " + tempEventDate.Day.ToString() + "/" + tempEventDate.Month.ToString();
                }
                else
                {
                    _EventDateText = EventDate.Day.ToString() + "/" + EventDate.Month.ToString() + "/" + EventDate.Year.ToString();
                }
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventDateText)));
            }
        }
        
        
        
        public Color TimeLabelColour
        {
            get
            {
                return _TimeLabelColour;
            }
            set
            {
                _TimeLabelColour = value;
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeLabelColour)));
            }
        }
        public Color TimePreviewColour
        {
            get
            {
                return _TimePreviewColour;
            }
            set
            {
                _TimePreviewColour = value;
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimePreviewColour)));
            }
        }
        public Color LocationLabelColour
        {
            get
            {
                return _LocationLabelColour;
            }
            set
            {
                _LocationLabelColour = value;
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationLabelColour)));
            }
        }
        public Color LocationPreviewColour
        {
            get
            {
                return _LocationPreviewColour;
            }
            set
            {
                _LocationPreviewColour = value;
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationPreviewColour)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentLocationAlias)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentLocationID)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationListViewHeight)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationAlias)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationAddress)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationSuburb)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationState)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationPostcode)));
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
                    LocationLabelColour = Color.FromHex("#c8cad0");
                    LocationPreviewColour = Color.FromHex("bfcfd9");
                }
                else
                {
                    LocationLabelColour = Color.FromHex("#1B1C20");
                    LocationPreviewColour = Color.FromHex("#334856");
                    _Online = false;
                }
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Online)));
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
                    TimeLabelColour = Color.FromHex("#c8cad0");
                    TimePreviewColour = Color.FromHex("bfcfd9");
                }
                else
                {
                    TimeLabelColour = Color.FromHex("#1B1C20");
                    TimePreviewColour = Color.FromHex("#334856");
                    _AllDay = false;
                }
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllDay)));
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
                EventDateText = EventDate.ToString();
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartTime)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartTimeText)));
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
                EventDateText = EventDate.ToString();
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndTime)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndTimeText)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationListView)));
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
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventListView)));
            }
        }

        

        private void WriteEvent()
        {
            if (string.IsNullOrEmpty(EventName))
            {
                ErrorAlert("Event Name field must have value", CurrentPage);
            }
            else if (CurrentLocationID == 0 && Online == false)
            {
                ErrorAlert("New Event must have Location", CurrentPage);
            }
            else if (CurrentCalendarID == 0)
            {
                ErrorAlert("New Event must have Calendar", CurrentPage);
            }
            else
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
        }

        

        public CreateEventViewModel()
        {
            AffairType = "Event";
            referenceEventViewModel = this;

            LoadReminder = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//AddReminder");
            });

            SaveEvent = new Command(() => {
                WriteEvent();
                EventListView = (from x in conn.Table<Event>() select x).ToList();

                // Uncomment to view SQLite Query
                foreach (Event iterEvent in EventListView)
                {
                    Console.WriteLine(iterEvent.Name + iterEvent.Type + iterEvent.Date.ToString() + iterEvent.StartTime.ToString() + iterEvent.EndTime.ToString() + iterEvent.AllDay.ToString()
                        + iterEvent.IsOnline.ToString() + iterEvent.RepeatInterval + iterEvent.AlertInterval + iterEvent.NoteId.ToString() + iterEvent.ProgrammeId.ToString() + iterEvent.LocationId.ToString());
                }
            });

            

            LoadLocation = new Command(async () =>
            {
                if (Online == false)
                {
                    await CurrentNavigation.PushAsync(new LocationSelection(this));
                }
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
                await CurrentNavigation.PopAsync();
            });

            SaveCustomLocation = new Command(async () => {
                List<Page> currentPages = (List<Page>)CurrentNavigation.NavigationStack;
                bool validLocation = true;
                int PostcodeTest = 0;
                try
                {
                    if (LocationPostcode != null)
                    {
                        PostcodeTest = int.Parse(LocationPostcode);
                    }
                    else
                    {
                        ErrorAlert("Postcode must be numeric value", currentPages[currentPages.Count - 1]);
                        validLocation = false;
                    }
                }
                catch (FormatException ex)
                {
                    if (validLocation)
                    {
                        ErrorAlert("Postcode must be numeric value", currentPages[currentPages.Count - 1]);
                        validLocation = false;
                    }
                    throw ex;
                }

                if ((PostcodeTest > 9999 || PostcodeTest < 1000) && validLocation)
                {
                    ErrorAlert("Postcode must be 4 digit numeric value", currentPages[currentPages.Count - 1]);
                    validLocation = false;
                }

                if (LocationAlias == "" || LocationAlias == null)
                {
                    ErrorAlert("Location Alias cannot be null", currentPages[currentPages.Count - 1]);
                }
                else if (LocationAddress == "" || LocationAddress == null)
                {
                    ErrorAlert("Location Address cannot be null", currentPages[currentPages.Count - 1]);
                }
                else if (LocationSuburb == "" || LocationSuburb == null)
                {
                    ErrorAlert("Location Suburb cannot be null", currentPages[currentPages.Count - 1]);
                }
                else if (LocationState == "" || LocationState == null)
                {
                    ErrorAlert("Location State cannot be null", currentPages[currentPages.Count - 1]);
                }
                else if (LocationAlias != "" && LocationAddress != "" && LocationSuburb != "" && LocationState != "" && validLocation)
                {
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
                    await CurrentNavigation.PopAsync();
                }
            });

            LoadCustomLocation = new Command(async () =>
            {
                await CurrentNavigation.PushAsync(new LocationCustom(this));
            });

            LoadNewCalendar = new Command(() => {
                PopupCalendarVisible = true;
            });

            SaveNewCalendar = new Command(() => {
                if (string.IsNullOrEmpty(NewCalendarName))
                {
                    ErrorAlert("New Calendar must have Name", CurrentPage);
                }
                else if (string.IsNullOrEmpty(NewCalendarColour))
                {
                    ErrorAlert("New Calendar must have Colour", CurrentPage);
                }
                else
                {
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
                }
            });

            SelectCalendar = new Command((calendarValue) => {
                CurrentCalendarID = 0;
                CurrentCalendarID = (int)calendarValue;
                CalendarListView = new List<ProgrammeViewModel>();
            });
        }

        public void Initalise(INavigation navigation, Page page)
        {
            CurrentNavigation = navigation;
            CurrentPage = page;

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

            
            StartTime = DateTime.Now.TimeOfDay;
            TimeSpan tempEndTime = StartTime + TimeSpan.FromHours(2);
            if (tempEndTime.Days > 0)
            {
                tempEndTime = tempEndTime.Subtract(new TimeSpan(1, 0, 0, 0));
            }
            EndTime = tempEndTime;

            CurrentLocationAlias = "None";

            LocationLabelColour = Color.FromHex("#1B1C20");
            LocationPreviewColour = Color.FromHex("#334856");

            TimeLabelColour = Color.FromHex("#1B1C20");
            TimePreviewColour = Color.FromHex("#334856");

            
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}

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
    public class CreateAffairViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected string _AffairType;

        public Command LoadType { get; }
        public Command SelectType { get; }
        public Command SelectRepeat { get; }
        public Command LoadRepeat { get; }
        public Command SelectAlert { get; }
        public Command LoadAlert { get; }
        public Command SaveNote { get; }
        public Command LoadNote { get; }

        protected string _EventName;
        protected DateTime _EventDate;
        protected string _EventDateText;
        protected string _EventType;

        protected string _Repeat;
        protected string _Alert;

        protected string _NoteURL;
        protected string _NoteDescription;
        protected int _CurrentNoteID;
        protected string _NotePreviewLabel;

        protected INavigation _CurrentNavigation;
        protected Page _CurrentPage;
        public SQLiteConnection conn;
        public CreateEventViewModel referenceEventViewModel;

        protected PropertyChangedEventHandler BasePropertyChanged
        {
            get
            {
                return PropertyChanged;
            }
            set
            {
                PropertyChanged = value;
            }
        }
        public string AffairType
        {
            get
            {
                return _AffairType;
            }
            set
            {
                _AffairType = value;
            }
        }
        public INavigation CurrentNavigation
        {
            get
            {
                return _CurrentNavigation;
            }
            set
            {
                _CurrentNavigation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentNavigation)));
            }
        }
        public Page CurrentPage
        {
            get
            {
                return _CurrentPage;
            }
            set
            {
                _CurrentPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
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
        public DateTime EventDate
        {
            get
            {
                return _EventDate;
            }
            set
            {
                if (DateTime.Today > value)
                {
                    ErrorAlert("Input Date Value must be after Current Date", CurrentPage);
                    _EventDate = DateTime.Today;
                }
                else
                {
                    _EventDate = value;
                }
                EventDateText = _EventDate.ToString();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventDate)));
            }
        }
        public virtual string EventDateText
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
        public int CurrentNoteID
        {
            get
            {
                return _CurrentNoteID;
            }
            set
            {
                _CurrentNoteID = value;
                NotePreviewLabel = "Custom";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentNoteID)));
            }
        }
        public string NotePreviewLabel
        {
            get
            {
                return _NotePreviewLabel;
            }
            set
            {
                if (CurrentNoteID == 0)
                {
                    _NotePreviewLabel = "Empty";
                }
                else
                {
                    _NotePreviewLabel = "Custom";
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NotePreviewLabel)));
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

        protected async void ErrorAlert(string errorField, Page errorPage)
        {
            if (errorPage != null)
            {
                await errorPage.DisplayAlert("Error", errorField, "OK");
            }
            else
            {
                errorPage = new Page();
            }
        }

        public CreateAffairViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            // Preview text show up
            Repeat = "None";
            Alert = "15 Minutes";
            NotePreviewLabel = "Empty";

            SelectType = new Command(async (typeValue) => {
                EventType = (string)typeValue;
                await CurrentNavigation.PopAsync();
            });

            LoadType = new Command(async () => {
                await CurrentNavigation.PushAsync(new EventType(referenceEventViewModel));
            });

            SelectRepeat = new Command(async (repeatValue) => {
                Repeat = (string)repeatValue;
                await CurrentNavigation.PopAsync();
            });

            LoadRepeat = new Command(async () => {
                await CurrentNavigation.PushAsync(new Repeat(referenceEventViewModel));
            });

            SelectAlert = new Command(async (alertValue) => {
                Alert = (string)alertValue;
                await CurrentNavigation.PopAsync();
            });

            LoadAlert = new Command(async () => {
                await CurrentNavigation.PushAsync(new Alert(referenceEventViewModel));
            });

            SaveNote = new Command(async () => {
                List<Page> currentPages = (List<Page>)CurrentNavigation.NavigationStack;

                if (string.IsNullOrEmpty(NoteDescription) && string.IsNullOrEmpty(NoteURL))
                {
                    ErrorAlert("At least one field is required", currentPages[currentPages.Count - 1]);
                }
                else
                {
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
                    await CurrentNavigation.PopAsync();
                }
            });

            LoadNote = new Command(async () =>
            {
                await CurrentNavigation.PushAsync(new Notes(referenceEventViewModel));
            });
        }

        
    }
}

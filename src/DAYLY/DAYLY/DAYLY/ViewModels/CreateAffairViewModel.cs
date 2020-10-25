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
        public Command LoadNewProgramme { get; }
        public Command SaveNewProgramme { get; }
        public Command SelectProgramme { get; }

        protected string _AffairName;
        protected DateTime _AffairDate;
        protected string _AffairDateText;
        protected string _AffairSubType;

        protected string _Repeat;
        protected string _Alert;

        protected string _NoteURL;
        protected string _NoteDescription;
        protected int _CurrentNoteID;
        protected string _NotePreviewLabel;

        protected int _CurrentProgrammeID;
        protected bool _PopupProgramme;
        protected string _NewProgrammeName;
        protected string _NewProgrammeColour;
        protected int _ProgrammeListViewWidth;
        protected List<ProgrammeViewModel> _ProgrammeListView;
        protected List<string> _ColourPickerItems;

        protected INavigation _CurrentNavigation;
        protected Page _CurrentPage;
        public SQLiteConnection conn;
        public CreateEventViewModel referenceEventViewModel;
        public CreateReminderViewModel referenceReminderViewModel;

        public List<string> ColourPickerItems
        {
            get
            {
                return _ColourPickerItems;
            }
            set
            {
                _ColourPickerItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColourPickerItems)));
            }
        }
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
        public string NewProgrammeColour
        {
            get
            {
                return _NewProgrammeColour;
            }
            set
            {
                _NewProgrammeColour = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewProgrammeColour)));
            }
        }
        public string NewProgrammeName
        {
            get
            {
                return _NewProgrammeName;
            }
            set
            {
                _NewProgrammeName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewProgrammeName)));
            }
        }
        public bool PopupProgrammeVisible
        {
            get
            {
                return _PopupProgramme;
            }
            set
            {
                _PopupProgramme = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupProgrammeVisible)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupProgrammeHidden)));
            }
        }
        public bool PopupProgrammeHidden
        {
            get
            {
                return !_PopupProgramme;
            }
            set
            {
                _PopupProgramme = !value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupProgrammeHidden)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupProgrammeVisible)));
            }
        }
        public int CurrentProgrammeID
        {
            get
            {
                return _CurrentProgrammeID;
            }
            set
            {
                _CurrentProgrammeID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentProgrammeID)));
            }
        }
        public int ProgrammeListViewWidth
        {
            get
            {
                return _ProgrammeListViewWidth;
            }
            set
            {
                _ProgrammeListViewWidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgrammeListViewWidth)));
            }
        }
        public List<ProgrammeViewModel> ProgrammeListView
        {
            get
            {
                return _ProgrammeListView;
            }
            set
            {
                _ProgrammeListView = new List<ProgrammeViewModel>();
                string tempBorderColour;

                if (AffairType == "Event")
                {
                    List<Models.Calendar> tempListView = (from x in conn.Table<Models.Calendar>() select x).ToList();

                    foreach (Models.Calendar calendar in tempListView)
                    {
                        if (calendar.Id == CurrentProgrammeID)
                        {
                            tempBorderColour = "#0033cc";
                        }
                        else
                        {
                            tempBorderColour = "#ffffff";
                        }
                        ProgrammeViewModel programmeViewModel = new ProgrammeViewModel(calendar.Id, calendar.Name, calendar.HexColour, tempBorderColour);
                        _ProgrammeListView.Add(programmeViewModel);
                    }
                }
                else
                {
                    List<Models.Subject> tempListView = (from x in conn.Table<Models.Subject>() select x).ToList();

                    foreach (Models.Subject subject in tempListView)
                    {
                        if (subject.Id == CurrentProgrammeID)
                        {
                            tempBorderColour = "#0033cc";
                        }
                        else
                        {
                            tempBorderColour = "#ffffff";
                        }
                        ProgrammeViewModel programmeViewModel = new ProgrammeViewModel(subject.Id, subject.Name, subject.HexColour, tempBorderColour);
                        _ProgrammeListView.Add(programmeViewModel);
                    }
                }
                
                
                ProgrammeListViewWidth = _ProgrammeListView.Count * 150;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgrammeListView)));
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
        public string AffairSubType
        {
            get
            {
                return _AffairSubType;
            }
            set
            {
                _AffairSubType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AffairSubType)));
            }
        }
        public string AffairName
        {
            get
            {
                return _AffairName;
            }
            set
            {
                _AffairName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AffairName)));
            }
        }
        public DateTime AffairDate
        {
            get
            {
                return _AffairDate;
            }
            set
            {
                if (DateTime.Today > value)
                {
                    ErrorAlert("Input Date Value must be after Current Date", CurrentPage);
                    _AffairDate = DateTime.Today;
                }
                else
                {
                    _AffairDate = value;
                }
                AffairDateText = _AffairDate.ToString();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AffairDate)));
            }
        }
        public virtual string AffairDateText
        {
            get
            {
                return _AffairDateText;
            }
            set
            {
                _AffairDateText = AffairDate.Day.ToString() + "/" + AffairDate.Month.ToString() + "/" + AffairDate.Year.ToString();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AffairDateText)));
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
        protected async void SuccessAlert(string successField, Page successPage)
        {
            if (successPage != null)
            {
                await successPage.DisplayAlert("Success", successField, "OK");
            }
            else
            {
                successPage = new Page();
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
        protected void ResetAffair()
        {
            Repeat = "None";
            Alert = "15 Minutes";
            NotePreviewLabel = "Empty";

            AffairName = "";
            NoteURL = "";
            NoteDescription = "";

            PopupProgrammeVisible = false;

            CurrentNoteID = 0;
            CurrentProgrammeID = 0;

            AffairDate = DateTime.Today;

            ProgrammeListView = new List<ProgrammeViewModel>();
            ColourPickerItems = new List<string>
            {
                "Green",
                "Blue",
                "Red",
                "Orange",
                "Yellow",
                "Purple"
            };
        }
        public CreateAffairViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();

            SelectType = new Command(async (typeValue) => {
                AffairSubType = (string)typeValue;
                await CurrentNavigation.PopAsync();
            });

            LoadType = new Command(async () => {
                if (AffairType == "Event")
                {
                    await CurrentNavigation.PushAsync(new EventType(referenceEventViewModel));
                }
                else
                {
                    await CurrentNavigation.PushAsync(new ReminderType(referenceReminderViewModel));
                }
            });

            SelectRepeat = new Command(async (repeatValue) => {
                Repeat = (string)repeatValue;
                await CurrentNavigation.PopAsync();
            });

            LoadRepeat = new Command(async () => {
                if (AffairType == "Event")
                {
                    await CurrentNavigation.PushAsync(new Repeat(referenceEventViewModel));
                }
                else
                {
                    await CurrentNavigation.PushAsync(new Repeat(referenceReminderViewModel));
                }
            });

            SelectAlert = new Command(async (alertValue) => {
                Alert = (string)alertValue;
                await CurrentNavigation.PopAsync();
            });

            LoadAlert = new Command(async () => {
                if (AffairType == "Event")
                {
                    await CurrentNavigation.PushAsync(new Alert(referenceEventViewModel));
                }
                else
                {
                    await CurrentNavigation.PushAsync(new Alert(referenceReminderViewModel));
                }
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
                        throw ex;
                    }
                    CurrentNoteID = newNote.Id;
                    await CurrentNavigation.PopAsync();
                }
            });

            LoadNote = new Command(async () =>
            {
                if (AffairType == "Event")
                {
                    await CurrentNavigation.PushAsync(new Notes(referenceEventViewModel));
                }
                else
                {
                    await CurrentNavigation.PushAsync(new Notes(referenceReminderViewModel));
                }
            });

            LoadNewProgramme = new Command(() => {
                PopupProgrammeVisible = true;
            });

            SaveNewProgramme = new Command(() => {

                bool validProgramme = true;

                if (string.IsNullOrEmpty(NewProgrammeName))
                {
                    ErrorAlert("New Programme must have Name", CurrentPage);
                    validProgramme = false;
                }
                else if (string.IsNullOrEmpty(NewProgrammeColour))
                {
                    ErrorAlert("New Programme must have Colour", CurrentPage);
                    validProgramme = false;
                }

                if (validProgramme)
                {
                    int isSuccess;
                    // Add Programme
                    string hexCode;
                    switch (NewProgrammeColour)
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
                    if (AffairType == "Event")
                    {
                        Models.Calendar newCalendar = new Models.Calendar
                        {
                            Name = NewProgrammeName,
                            HexColour = hexCode
                        };
                        isSuccess = 0;
                        try
                        {
                            isSuccess = conn.Insert(newCalendar);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        Models.Subject newSubject = new Models.Subject
                        {
                            Name = NewProgrammeName,
                            HexColour = hexCode
                        };
                        isSuccess = 0;
                        try
                        {
                            isSuccess = conn.Insert(newSubject);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    
                    NewProgrammeName = "";
                    NewProgrammeColour = "";
                    CurrentProgrammeID = 0;

                    // Save results to query
                    ProgrammeListView = new List<ProgrammeViewModel>();
                    PopupProgrammeVisible = false;
                }
            });

            SelectProgramme = new Command((programmeValue) => {
                CurrentProgrammeID = 0;
                CurrentProgrammeID = (int)programmeValue;
                ProgrammeListView = new List<ProgrammeViewModel>();
            });
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DAYLY.Models;
using DAYLY.ViewModels;
using DAYLY;
using SQLite;
using System.Globalization;

namespace DAYLY.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvent : ContentPage

    {
        public SQLiteConnection conn;
        public TestEvent testmodel;
        public Event eventmodel;
        public Note notemodel;
        public Programme programmemodel;
        public AddEvent()
        {
           
            InitializeComponent();
            DateTime currentTime = DateTime.Now;
            StartTimePicker.Time = currentTime.TimeOfDay;
            EndTimePicker.Time = currentTime.AddHours(2).TimeOfDay;
            EventDatePicker.Date = currentTime;

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
            BindingContext = new NewEventViewModel();
        }
        async void OnReminderClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddReminder());
        }
        private void AddEventBtn_Clicked(object sender, EventArgs e)
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
                throw ex;
            }

            // Add Event
            Event newEvent = new Event
            {
                Name = Name.Text,
                Type = "Event",
                Date = EventDatePicker.Date,
                StartTime = StartTimePicker.Time,
                EndTime = EndTimePicker.Time,
                AllDay = AllDaySwitch.IsToggled,
                IsOnline = OnlineSwitch.IsToggled,
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
                throw ex;
            }
            var details = (from x in conn.Table<Note>() select x).ToList();
            myListView.ItemsSource = details;
        }

        private void StartTimeBtn_Tapped(object sender, EventArgs e)
        {
            StartTimePicker.Focus();
        }

        private void StartTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TimeSpan startTime = StartTimePicker.Time;
            String timeSuffix = "AM";
            if (startTime.Hours > 12)
            {
                TimeSpan twelveHour = new TimeSpan(12, 0, 0);
                startTime = startTime.Subtract(twelveHour);
                timeSuffix = "PM";
            }
            StartTimeLabel.Text = startTime.ToString().Substring(0, 5) + timeSuffix;
        }

        private void EndTimeBtn_Tapped(object sender, EventArgs e)
        {
            EndTimePicker.Focus();
        }

        private void EndTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TimeSpan endTime = EndTimePicker.Time;
            String timeSuffix = "AM";
            if (endTime.Hours > 12)
            {
                TimeSpan twelveHour = new TimeSpan(12, 0, 0);
                endTime = endTime.Subtract(twelveHour);
                timeSuffix = "PM";
            }
            EndTimeLabel.Text = endTime.ToString().Substring(0, 5) + timeSuffix;
        }

        private void EventDatePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EventDateLabel.Text = EventDatePicker.Date.Day.ToString() + "/" + EventDatePicker.Date.Month.ToString() + "/" + EventDatePicker.Date.Year.ToString();
        }

        private void EventDateBtn_Tapped(object sender, EventArgs e)
        {
            EventDatePicker.Focus();
        }
    }
}
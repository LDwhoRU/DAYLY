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
        public AddEvent()
        {
            InitializeComponent();

            StartTimePicker.Time = DateTime.Now.TimeOfDay;
            EndTimePicker.Time = DateTime.Now.TimeOfDay.Add(new TimeSpan(2, 0, 0));
            EventDatePicker.Date = DateTime.Now;

            conn = DependencyService.Get<Isqlite>().GetConnection();
            try
            {
                conn.DropTable<TestEvent>();
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.CreateTable<TestEvent>();
            BindingContext = new NewEventViewModel();
        }

        private void AddEventBtn_Clicked(object sender, EventArgs e)
        {
            TestEvent test = new TestEvent();
            test.FirstEntry = FirstEntry.Text;
            int isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var details = (from x in conn.Table<TestEvent>() select x).ToList();
            //myListView.ItemsSource = details;
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
            //EventDateLabel.Text = EventDateLabel.Text.Substring(0, EventDateLabel.Text.Length - 12);
        }

        private void EventDateBtn_Tapped(object sender, EventArgs e)
        {
            EventDatePicker.Focus();
        }
    }
}
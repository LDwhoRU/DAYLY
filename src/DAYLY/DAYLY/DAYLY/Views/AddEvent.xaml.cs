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
        public NewEventViewModel eventOperations = new NewEventViewModel();
        public AddEvent()
        {
            InitializeComponent();

            // Set default values for pickers
            DateTime currentTime = DateTime.Now;
            StartTimePicker.Time = currentTime.TimeOfDay;
            EndTimePicker.Time = currentTime.AddHours(2).TimeOfDay;
            EventDatePicker.Date = currentTime;
        }
        async void OnReminderClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddReminder());
        }
        private void AddEventBtn_Clicked(object sender, EventArgs e)
        {
            eventOperations.SaveEvent(Name.Text, EventDatePicker.Date, StartTimePicker.Time, EndTimePicker.Time, OnlineSwitch.IsToggled, AllDaySwitch.IsToggled);

            // For debugging
            SQLiteConnection conn = DependencyService.Get<Isqlite>().GetConnection();
            var details = (from x in conn.Table<Note>() select x).ToList();
            myListView.ItemsSource = details;
        }

        private void StartTimeBtn_Tapped(object sender, EventArgs e)
        {
            StartTimePicker.Focus();
        }

        private void StartTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StartTimeLabel.Text = eventOperations.TimeConvert(StartTimePicker.Time);
        }

        private void EndTimeBtn_Tapped(object sender, EventArgs e)
        {
            EndTimePicker.Focus();
        }

        private void EndTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EndTimeLabel.Text = eventOperations.TimeConvert(EndTimePicker.Time);
        }

        private void EventDatePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EventDateLabel.Text = eventOperations.AUDateConvert(EventDatePicker.Date);
        }

        private void EventDateBtn_Tapped(object sender, EventArgs e)
        {
            EventDatePicker.Focus();
        }
    }
}
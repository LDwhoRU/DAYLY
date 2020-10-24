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
using System.Diagnostics;

namespace DAYLY.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvent : ContentPage

    {
        public NewEventViewModel eventOperations = new NewEventViewModel();
        public CreateEventViewModel createEventViewModel = new CreateEventViewModel();
        public AddEvent()
        {
            InitializeComponent();

            // MVVM Implementation
            createEventViewModel.Initalise(Navigation, this);
            BindingContext = createEventViewModel;

            colourPicker.Items.Add("Green");
            colourPicker.Items.Add("Blue");
            colourPicker.Items.Add("Red");
            colourPicker.Items.Add("Orange");
            colourPicker.Items.Add("Yellow");
            colourPicker.Items.Add("Purple");
        }

        // Focus element of pickers set in Views - Cannot be set in viewmodel without passing entire object
        private void StartTimeBtn_Tapped(object sender, EventArgs e)
        {
            if (createEventViewModel.AllDay != true)
            {
                StartTimePicker.Focus();
            }
        }

        private void EndTimeBtn_Tapped(object sender, EventArgs e)
        {
            if (createEventViewModel.AllDay != true)
            {
                EndTimePicker.Focus();
            }
        }

        private void EventDateBtn_Tapped(object sender, EventArgs e)
        {
            EventDatePicker.Focus();
        }
    }
}
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
        public CreateEventViewModel createEventViewModel = new CreateEventViewModel();
        public AddEvent()
        {
            InitializeComponent();

            // MVVM Implementation
            createEventViewModel.Initalise(Navigation, this);
            BindingContext = createEventViewModel;
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
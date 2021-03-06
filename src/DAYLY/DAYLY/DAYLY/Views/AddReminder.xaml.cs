﻿using System;
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
    public partial class AddReminder : ContentPage
    {
        public CreateReminderViewModel createReminderViewModel;
        public AddReminder()
        {
            InitializeComponent();

            // MVVM Implementation
            createReminderViewModel = new CreateReminderViewModel(Navigation, this);
            BindingContext = createReminderViewModel;
        }

        private void AffairDateBtn_Tapped(object sender, EventArgs e)
        {
            AffairDatePicker.Focus();
        }
    }
}
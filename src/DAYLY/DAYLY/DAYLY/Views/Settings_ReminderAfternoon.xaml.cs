using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_ReminderAfternoon : ContentPage
    {
        public Settings_ReminderAfternoon()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsViewModel;
        }
    }
}

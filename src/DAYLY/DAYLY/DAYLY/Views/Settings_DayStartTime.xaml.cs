using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_DayStartTime : ContentPage
    {
        public Settings_DayStartTime()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsViewModel;
        }
    }
}

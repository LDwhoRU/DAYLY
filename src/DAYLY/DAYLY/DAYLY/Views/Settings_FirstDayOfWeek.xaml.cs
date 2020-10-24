using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_FirstDayOfWeek : ContentPage
    {
        public Settings_FirstDayOfWeek()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsViewModel;
        }
    }
}

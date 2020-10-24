using System;
using System.Collections.Generic;
using DAYLY.Views;
using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_AppTheme : ContentPage
    {       
        public Settings_AppTheme()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsViewModel;
        }
    }
}

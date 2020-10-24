using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_DefaultEventAlert : ContentPage
    {
        public Settings_DefaultEventAlert()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsViewModel;
        }
    }
}

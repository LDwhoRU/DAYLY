using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_DefaultView : ContentPage
    {
        public Settings_DefaultView()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsViewModel;
        }
    }
}

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Profile_LoggedOut : ContentPage
    {
        public Profile_LoggedOut()
        {
            InitializeComponent();
            BindingContext = Settings_Main.settingsViewModel;
        }
    }
}

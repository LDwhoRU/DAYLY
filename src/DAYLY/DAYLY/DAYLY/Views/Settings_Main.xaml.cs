using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using DAYLY.Views;

namespace DAYLY.Views
{
    public partial class Settings_Main : ContentPage
    {
        public Settings_Main()
        {
            InitializeComponent();
        }

        async void OnGeneralSettingClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Settings_General");
        }

        async void OnRemindersSettingClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Settings_Reminders");
        }
    }

    
}

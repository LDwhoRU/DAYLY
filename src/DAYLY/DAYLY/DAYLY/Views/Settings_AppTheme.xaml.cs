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
            BindingContext = Settings_General.settingsDefault;
        }

        private void OnFollowSystemModeClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 0);;
            Settings_General.settingsDefault.AppThemeStr = "Follow system";
            Settings_General.settingsDefault.AppThemePos = "0";
        }

        private void OnLightModeClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 3);
            Settings_General.settingsDefault.AppThemeStr = "Light";
            Settings_General.settingsDefault.AppThemePos = "3";
        }

        private void OnDarkModeClicked(object sender, EventArgs e)
        {
            Grid.SetRow(TickImage, 6);
            Settings_General.settingsDefault.AppThemeStr = "Dark";
            Settings_General.settingsDefault.AppThemePos = "6";
        }
    }
}

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Settings_EditProfile : ContentPage
    {
        public Settings_EditProfile()
        {
            InitializeComponent();
            BindingContext = Profile.profileViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}

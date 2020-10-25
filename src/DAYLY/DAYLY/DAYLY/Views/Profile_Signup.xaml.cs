using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Profile_Signup : ContentPage
    {
        public Profile_Signup()
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

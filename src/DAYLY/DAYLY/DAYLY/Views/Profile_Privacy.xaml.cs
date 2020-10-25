using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Profile_Privacy : ContentPage
    {
        public Profile_Privacy()
        {
            InitializeComponent();
            BindingContext = Profile.profileViewModel;
        }
    }
}

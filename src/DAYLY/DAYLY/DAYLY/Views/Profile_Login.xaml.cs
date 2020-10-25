using System;
using System.Collections.Generic;
using DAYLY.Views;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Profile_Login : ContentPage
    {
        public Profile_Login()
        {
            InitializeComponent();
            BindingContext = Profile.profileViewModel;
        }
    }
}

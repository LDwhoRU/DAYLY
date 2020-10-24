using System;
using System.Collections.Generic;
using DAYLY.ViewModels;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Profile : ContentPage
    {
        public static ProfileViewModel profileViewModel = new ProfileViewModel();

        public Profile()
        {
            InitializeComponent();
            profileViewModel.Initialise(Navigation);
            BindingContext = profileViewModel;
        }
    }
}

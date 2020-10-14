using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Location : ContentPage
    {
        public Location()
        {
            InitializeComponent();
        }

        async void OnAddNewAddressClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationCustom());
        }
    }
}

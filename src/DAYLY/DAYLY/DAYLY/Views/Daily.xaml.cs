using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DAYLY.Views
{
    public partial class Daily : ContentPage
    {
        public Daily()
        {
            InitializeComponent();
        }
        async void OnDailyTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Daily());
        }
        async void OnMonthlyTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Monthly());
        }
        async void OnWeeklyTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Weekly());
        }
    }
}

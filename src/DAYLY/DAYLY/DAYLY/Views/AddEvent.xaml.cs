﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DAYLY.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvent : ContentPage

    {
        public AddEvent()
        {
           
            InitializeComponent();
            
        }
        async void OnButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddReminder());
        }
    }
}
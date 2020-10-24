using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DAYLY.Models;
using DAYLY.ViewModels;
using DAYLY;
using SQLite;
using System.Globalization;
using System.Diagnostics;

namespace DAYLY.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReminder : ContentPage
    {
        public CreateReminderViewModel createReminderViewModel = new CreateReminderViewModel();
        public AddReminder()
        {
            InitializeComponent();

            // MVVM Implementation
            createReminderViewModel.Initalise(Navigation);
            BindingContext = createReminderViewModel;
        }
        async void OnEventClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEvent());
        }
    }
}
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
    public partial class Repeat : ContentPage
    {
        public Repeat(CreateEventViewModel eventModel)
        {
            InitializeComponent();
            BindingContext = eventModel;
        }
        public Repeat(CreateReminderViewModel reminderModel)
        {
            InitializeComponent();
            BindingContext = reminderModel;
        }
    }
}
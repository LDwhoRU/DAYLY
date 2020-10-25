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
    public partial class EventType : ContentPage
    {
        public EventType(CreateEventViewModel eventModel)
        {
            InitializeComponent();
            BindingContext = eventModel;
        }
    }
}
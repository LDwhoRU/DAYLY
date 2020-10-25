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
    public partial class LocationCustom : ContentPage
    {
        public LocationCustom(CreateEventViewModel eventModel)
        {
            InitializeComponent();
            BindingContext = eventModel;
        }
    }
}

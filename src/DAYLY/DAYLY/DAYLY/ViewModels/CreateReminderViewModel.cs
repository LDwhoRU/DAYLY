using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using DAYLY.Models;
using SQLite;
using System.Linq;
using DAYLY.Views;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using DAYLY.ViewModels;
using DAYLY;
using System.Globalization;
using System.Diagnostics;

namespace DAYLY.ViewModels
{
    public class CreateReminderViewModel : CreateAffairViewModel
    {
        private INavigation _NavigationStack;
        public Command LoadEvent { get; }

        public CreateReminderViewModel()
        {
            LoadEvent = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//AddEvent");
            });
        }

        public void Initalise(INavigation navigation)
        {
            _NavigationStack = navigation;
        }
    }
}

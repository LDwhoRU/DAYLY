using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DAYLY.Models;
using DAYLY.ViewModels;

namespace DAYLY.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderType : ContentPage
    {
        public ReminderType(CreateReminderViewModel reminderModel)
        {
            InitializeComponent();
            BindingContext = reminderModel;
        }
    }
}
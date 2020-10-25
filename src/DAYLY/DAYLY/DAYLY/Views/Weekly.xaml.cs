using DAYLY.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DAYLY.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Weekly : ContentPage
    {
        public Weekly()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
           // base.OnAppearing();
          //  var vm = this.BindingContext as WeeklyViewModel;
       //     vm.intialise();
//
             //   vm.GetWeek();
          //  vm.WeekTime();
        }
    }
}
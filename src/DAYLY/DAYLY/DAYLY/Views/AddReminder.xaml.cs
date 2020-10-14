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
    public partial class AddReminder : ContentPage
    {
        public AddReminder()
        {
           
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        async void OnButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEvent());
        }
    }
}
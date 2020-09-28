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
    public partial class Monthly : ContentPage
    {
        public Monthly()
        {
            InitializeComponent();
        }
           async void OnGeneralSettingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings_General());
        }
    }
}
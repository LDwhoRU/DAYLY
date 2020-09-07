using System.ComponentModel;
using Xamarin.Forms;
using DAYLY.ViewModels;

namespace DAYLY.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
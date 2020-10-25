using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DAYLY.Services;
using SQLite;
using DAYLY.Models;

namespace DAYLY
{
    public partial class App : Application
    {
        MockUserProfiles mockUsersDatabase = new MockUserProfiles();

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

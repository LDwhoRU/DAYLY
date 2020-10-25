using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DAYLY.Services;
using DAYLY.Views;

namespace DAYLY
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            checkAppInstallState();
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

        protected void checkAppInstallState()
        {
            if (Application.Current.Properties.ContainsKey("FirstUse"))
            {
                MockUserProfiles mockUsersDatabase = new MockUserProfiles();
            }
            else
            {
                Application.Current.Properties["FirstUse"] = false;
            }
        }
    }
}

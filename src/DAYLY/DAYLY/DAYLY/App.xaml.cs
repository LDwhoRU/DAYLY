using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DAYLY.Services;
using DAYLY.Views;
using DAYLY.Models;
using SQLite;

namespace DAYLY
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SQLiteConnection conn = DependencyService.Get<Isqlite>().GetConnection();

            try
            {
                conn.DropTable<Event>();
                conn.DropTable<Reminder>();
                conn.DropTable<Note>();
                conn.DropTable<Models.Subject>();
                conn.DropTable<Location>();
                conn.DropTable<Models.Calendar>();
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.CreateTable<Event>();
            conn.CreateTable<Reminder>();
            conn.CreateTable<Note>();
            conn.CreateTable<Models.Subject>();
            conn.CreateTable<Location>();
            conn.CreateTable<Models.Calendar>();

            DependencyService.Register<MockEventData>();
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

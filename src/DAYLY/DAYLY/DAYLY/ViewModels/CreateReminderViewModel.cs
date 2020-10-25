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
        private List<Reminder> _ReminderListView;
        public Command LoadEvent { get; }
        public Command SaveReminder { get; }
        public List<Reminder> ReminderListView
        {
            get
            {
                return _ReminderListView;
            }
            set
            {
                _ReminderListView = value;
                BasePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReminderListView)));
            }
        }

        private void WriteReminder()
        {
            if (string.IsNullOrEmpty(AffairName))
            {
                ErrorAlert("Reminder Name field must have value", CurrentPage);
            }
            else if (CurrentProgrammeID == 0)
            {
                ErrorAlert("New Reminder must have Calendar", CurrentPage);
            }
            else
            {
                // Add Event
                int isSuccess;
                Reminder newReminder = new Reminder
                {
                    Name = AffairName,
                    Type = AffairSubType,
                    Date = AffairDate,
                    RepeatInterval = Repeat,
                    AlertInterval = Alert,
                    NoteId = CurrentNoteID,
                    SubjectId = CurrentProgrammeID,
                };
                try
                {
                    isSuccess = conn.Insert(newReminder);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public CreateReminderViewModel()
        {
            AffairType = "Reminder";
            AffairSubType = "Assignment";
            referenceReminderViewModel = this;

            SaveReminder = new Command(() => {
                WriteReminder();
                ReminderListView = (from x in conn.Table<Reminder>() select x).ToList();

                // Uncomment to view SQLite Query
                Console.WriteLine("Saved Reminders");
                foreach (Reminder iterReminder in ReminderListView)
                {
                    Console.WriteLine(iterReminder.Name);
                    Console.WriteLine(iterReminder.Type + iterReminder.Date.ToString() + iterReminder.RepeatInterval + iterReminder.AlertInterval + iterReminder.NoteId.ToString() + iterReminder.SubjectId.ToString());
                }
            });

            LoadEvent = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//AddEvent");
            });
        }

        public void Initalise(INavigation navigation, Page page)
        {
            CurrentNavigation = navigation;
            CurrentPage = page;
        }
    }
}

using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DAYLY.Views;

namespace DAYLY.ViewModels
{
    public class Settings_FirstDayOfWeekViewModel : INotifyPropertyChanged
    {
        public Settings_FirstDayOfWeekViewModel()
        {
            ChangeFirstDayOfWeekCommand = new Command<string>(changeFirstDayOfWeek);
        }

        public ICommand ChangeFirstDayOfWeekCommand { get; }

        void changeFirstDayOfWeek(string newDay)
        {
            string[] dayStr = newDay.Split(',');
            Settings_General.settingsDefault.FirstDayOfWeekStr = dayStr[0];
            Settings_General.settingsDefault.FirstDayOfWeekPos = dayStr[1];
            OnPropertyChanged(nameof(FirstDayOfWeekPos));
        }

        public string FirstDayOfWeekPos => $"{Settings_General.settingsDefault.FirstDayOfWeekPos}";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

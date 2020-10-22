using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DAYLY.Views;
using Xamarin.Forms;

namespace DAYLY.ViewModels
{
    public class Settings_DefaultEventDurationViewModel : INotifyPropertyChanged
    {
        public Settings_DefaultEventDurationViewModel()
        {
            ChangeDefaultEventDurationCommand = new Command<string>(changeDefaultEvenDuration);
        }

        public ICommand ChangeDefaultEventDurationCommand { get; }

        void changeDefaultEvenDuration(string newDuration)
        {
            string[] posStr = newDuration.Split(',');
            Settings_General.settingsDefault.DefaultEventDuration = Default.stringToInt(posStr[0]);
            Settings_General.settingsDefault.DefaultEventDurationPos = posStr[1];
            Settings_General.settingsDefault.DefaultEventDurationStr = posStr[0] + " minutes";
            OnPropertyChanged(nameof(DefaultEventDurationPos));
        }

        public string DefaultEventDurationPos => $"{Settings_General.settingsDefault.DefaultEventDurationPos}";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

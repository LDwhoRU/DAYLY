using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DAYLY.Views;
using DAYLY.Models;

namespace DAYLY.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private INavigation NavStack;
        public string _FullName;
        public string _Email;
        public string _NumTasks;
        public string _NumTasksCompleted;
        public string _DaysSinceAccountCreated;
        public string _Organisation;
        public string _Course;
        string[] oldUserData;
        public ICommand EditProfileCommand { get; }
        public ICommand ConfirmNewProfileDataCommand { get; }
        public ICommand CancelEditProfileCommand { get; }

        public string FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                _FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string NumTasks
        {
            get
            {
                return _NumTasks;
            }
            set
            {
                _NumTasks = value;
                OnPropertyChanged(nameof(NumTasks));
            }
        }

        public string NumTasksCompleted
        {
            get
            {
                return _NumTasksCompleted;
            }
            set
            {
                _NumTasksCompleted = value;
                OnPropertyChanged(nameof(NumTasksCompleted));
            }
        }

        public string DaysSinceAccountCreated
        {
            get
            {
                return _DaysSinceAccountCreated;
            }
            set
            {
                _DaysSinceAccountCreated = value;
                OnPropertyChanged(nameof(DaysSinceAccountCreated));
            }
        }

        public string Organisation
        {
            get
            {
                return _Organisation;
            }
            set
            {
                _Organisation = value;
                OnPropertyChanged(nameof(Organisation));
            }
        }

        public string Course
        {
            get
            {
                return _Course;
            }
            set
            {
                _Course = value;
                OnPropertyChanged(nameof(Course));
            }
        }

        public ProfileViewModel()
        {
            EditProfileCommand = new Command(editProfile);
            ConfirmNewProfileDataCommand = new Command(async () => await NavStack.PopModalAsync());
            CancelEditProfileCommand = new Command(cancelEditProfile);
        }

        async void editProfile()
        {
            oldUserData = new string[]{ FullName, Email, Organisation, Course };
            await NavStack.PushModalAsync(new Settings_EditProfile());
        }

        async void cancelEditProfile()
        {
            FullName = oldUserData[0];
            Email = oldUserData[1];
            Organisation = oldUserData[2];
            Course = oldUserData[3];
            await NavStack.PopModalAsync();
        }
            
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Initialise(INavigation navigation)
        {
            NavStack = navigation;

            UserProfile user = new UserProfile
            {
                FullName = "John Smith",
                Email = "johnsmith@email.com",
                TasksRemaining = 24,
                TasksCompleted = 15,
                DaysSinceAccountCreated = 214,
                Organisation = "Queensland University of Technology",
                Course = "Information Technology"
            };

            FullName = user.FullName;
            Email = user.Email;
            NumTasks = user.TasksRemaining.ToString();
            NumTasksCompleted = user.TasksCompleted.ToString();
            DaysSinceAccountCreated = user.DaysSinceAccountCreated.ToString();
            Organisation = user.Organisation;
            Course = user.Course;
        }

        private bool isDataSame(string[] firstArray, string[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}

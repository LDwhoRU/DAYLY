using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DAYLY.Views;
using DAYLY.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string _ProfilePicPath;
        public string _OrganisationHeader;
        public string _CourseHeader;
        public string _LoggedInVisible;
        public string _LoggedOutVisible;
        public string _LoginEmail;
        public string _LoginPassword;
        public string _MessageVisible;
        public string _MessageText;
        public string _MessageTextColour;
        public string _MessageBorderColour;
        string[] oldUserData;
        public ICommand EditProfileCommand { get; }
        public ICommand ConfirmNewProfileDataCommand { get; }
        public ICommand CancelEditProfileCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand LoginCommandMain { get; }
        public ICommand SignupCommand { get; }

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

        public string ProfilePicPath
        {
            get
            {
                return _ProfilePicPath;
            }
            set
            {
                _ProfilePicPath = value;
                OnPropertyChanged(nameof(ProfilePicPath));
            }
        }

        public string OrganisationHeader
        {
            get
            {
                return _OrganisationHeader;
            }
            set
            {
                _OrganisationHeader = value;
                OnPropertyChanged(nameof(OrganisationHeader));
            }
        }

        public string CourseHeader
        {
            get
            {
                return _CourseHeader;
            }
            set
            {
                _CourseHeader = value;
                OnPropertyChanged(nameof(CourseHeader));
            }
        }

        public string LoggedInVisible
        {
            get
            {
                return _LoggedInVisible;
            }
            set
            {
                _LoggedInVisible = value;
                OnPropertyChanged(nameof(LoggedInVisible));
            }
        }

        public string LoggedOutVisible
        {
            get
            {
                return _LoggedOutVisible;
            }
            set
            {
                _LoggedOutVisible = value;
                OnPropertyChanged(nameof(LoggedOutVisible));
            }
        }

        public string LoginEmail
        {
            get
            {
                return _LoginEmail;
            }
            set
            {
                _LoginEmail = value;
                OnPropertyChanged(nameof(LoginEmail));
            }
        }

        public string LoginPassword
        {
            get
            {
                return _LoginPassword;
            }
            set
            {
                _LoginPassword = value;
                OnPropertyChanged(nameof(LoginPassword));
            }
        }

        public string MessageVisible
        {
            get
            {
                return _MessageVisible;
            }
            set
            {
                _MessageVisible = value;
                OnPropertyChanged(nameof(MessageVisible));
            }
        }

        public string MessageText
        {
            get
            {
                return _MessageText;
            }
            set
            {
                _MessageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }

        public string MessageTextColour
        {
            get
            {
                return _MessageTextColour;
            }
            set
            {
                _MessageTextColour = value;
                OnPropertyChanged(nameof(MessageTextColour));
            }
        }

        public string MessageBorderColour
        {
            get
            {
                return _MessageBorderColour;
            }
            set
            {
                _MessageBorderColour = value;
                OnPropertyChanged(nameof(MessageBorderColour));
            }
        }

        public ProfileViewModel()
        {
            EditProfileCommand = new Command(editProfile);
            ConfirmNewProfileDataCommand = new Command(confirmNewProfileData);
            CancelEditProfileCommand = new Command(cancelEditProfile);
            LoginCommand = new Command(async () => await NavStack.PushModalAsync(new Profile_Login()));
            LoginCommandMain = new Command(login);
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

        async void confirmNewProfileData()
        {
            SQLiteConnection conn = DependencyService.Get<Isqlite>().GetConnection();

            string[] newUserData = new string[] { FullName, Email, Organisation, Course };

            if (!isDataSame(oldUserData, newUserData))
            {
                if (newUserData[1] != oldUserData[1]) // if new email is different
                {
                    List<UserProfile> existingUser = conn.Query<UserProfile>("SELECT * FROM UserProfile WHERE Email=?", newUserData[1]);

                    if (existingUser.Count() == 0) // if new email is not in the database
                    {
                        conn.Query<UserProfile>("UPDATE UserProfile SET FullName=?, Email=?, Organisation=?, Course=? WHERE Email=?",
                                            FullName, Email, Organisation, Course, Email);
                        showMessage("True", "Successfully updated your profile!", "#228B22", "#228B22");
                        await Task.Delay(1000);
                        await NavStack.PopModalAsync();
                        MessageVisible = "False";
                    }
                    else // if new email already in database
                    {
                        showMessage("True", "This email belongs to another user.", "#FF0000", "#FF0000");
                    }
                }
                else // if email is the same but other fields are different
                {
                    conn.Query<UserProfile>("UPDATE UserProfile SET FullName=?, Organisation=?, Course=? WHERE Email=?",
                                            FullName, Organisation, Course, Email);
                    showMessage("True" ,"Successfully updated your profile!", "#228B22", "#228B22");
                    await Task.Delay(1000);
                    await NavStack.PopModalAsync();
                    MessageVisible = "False";
                }
            }
            else
            {
                await NavStack.PopModalAsync();
            }

            conn.Close();   
        }

        async void login()
        {
            SQLiteConnection conn = DependencyService.Get<Isqlite>().GetConnection();

            List<UserProfile> existingUser = conn.Query<UserProfile>("SELECT * FROM UserProfile WHERE Email=?", LoginEmail);

            if (existingUser.Count() == 1)
            {
                if (existingUser[0].Password == LoginPassword)
                {
                    FullName = existingUser[0].FullName;
                    Email = existingUser[0].Email;
                    NumTasks = existingUser[0].TasksRemaining.ToString();
                    NumTasksCompleted = existingUser[0].TasksCompleted.ToString();
                    DaysSinceAccountCreated = existingUser[0].DaysSinceAccountCreated.ToString();
                    Organisation = existingUser[0].Organisation;
                    Course = existingUser[0].Course;
                    ProfilePicPath = "profile_pic.png";
                    LoggedInVisible = "True";
                    LoggedOutVisible = "False";
                    showMessage("True", "Success!", "#228B22", "#228B22");
                    Settings_Main.settingsViewModel.ProfilePicPath = "profile_pic.png";
                    Settings_Main.settingsViewModel.LogInOutBtnText = "LOG OUT";
                    await Task.Delay(1000);
                    await NavStack.PopModalAsync();
                    MessageVisible = "False";
                }
                else
                {
                    showMessage("True", "The password you entered is incorrect.", "#FF0000", "#FF0000");
                }
            }
            else
            {
                showMessage("True", "The email you entered is incorrect.", "#FF0000", "#FF0000");
            }

            conn.Close();
        }
            
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Initialise(INavigation navigation)
        {
            NavStack = navigation;

            LoggedInVisible = "False";
            LoggedOutVisible = "True";
            MessageVisible = "False";
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

        private void showMessage(string visible, string text, string textColour, string borderColour)
        {
            MessageVisible = "True";
            MessageText = text;
            MessageTextColour = textColour;
            MessageBorderColour = borderColour;
        }
    }
}

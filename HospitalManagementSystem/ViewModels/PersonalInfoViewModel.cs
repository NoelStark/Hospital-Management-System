using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.ViewModels
{
    public class PersonalInfoViewModel : INotifyPropertyChanged
    {
        private static string _firstname = "First Name", _lastname = "Last Name", _ssn = "YYYYMMDD-XXXX", _email = "example@gmail.com", _confirmemail = "example@gmail.com", _phone = "Phone Number";
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; OnPropertyChanged(); }
        }

        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        public string ConfirmEmail
        {
            get { return _confirmemail; }
            set { _confirmemail = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

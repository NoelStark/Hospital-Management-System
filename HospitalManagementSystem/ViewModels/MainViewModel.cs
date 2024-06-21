using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using HospitalManagementSystem.Commands;

namespace HospitalManagementSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string currentViewKey;

        #region Binding Attributes
        private string _firstname = "First Name", _lastname = "Last Name", _ssn = "YYYYMMDD-XXXX", _email = "example@gmail.com", _confirmemail = "example@gmail.com", _phone = "Phone Number";
        private string _country = "Country", _street = "Street", _postalcode = "12345", _city = "City", _state = "State";
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string ConfirmEmail
        {
            get { return _confirmemail; }
            set { _confirmemail = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string PostalCode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        #endregion

        public string CurrentViewKey
        {
            get => currentViewKey;
            set
            {
                currentViewKey = value;
                OnPropertyChanged();
            }
        }

        public ICommand OnClickCommand { get; set; }

        public MainViewModel()
        {
            OnClickCommand = new RelayCommand(SwitchView);
            CurrentViewKey = "PersonalInformation";
        }

        
        private void SwitchView(object x)
        {
            CurrentViewKey = CurrentViewKey == "PersonalInformation" ? "Address" : "PersonalInformation";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
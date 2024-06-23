using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using EntityLayer;
using HospitalManagementSystem.Commands;

namespace HospitalManagementSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string currentViewKey;
        private bool dummyData = false;

        #region Binding Attributes
        private static string _firstname = "First Name", _lastname = "Last Name", _ssn = "YYYYMMDD-XXXX", _email = "example@gmail.com", _confirmemail = "example@gmail.com", _phone = "Phone Number";
        private string _country = "Country", _street = "Street", _postalcode = "12345", _city = "City", _state = "State";
        private List<CountryData>? _countries;
        private List<string> _cities;

        public List<string> Countries { get; set; }

        private Dictionary<string, string> _customerProperties = new Dictionary<string, string>
        {
            {"FirstName", "" },
            {"LastName", "" },
            {"SSN", "" },
            {"Email", "" },
            {"Phone_Number", "" },
            {"Country", "" },
            {"PostalCode", "" },
            {"Street", "" },
            {"City", "" },
            {"State", "" }
        };
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

        public List<string> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand OnClickCommand { get; set; }
        public ICommand OnDummyDataCommand { get; set; }
        #endregion
        public MainViewModel()
        {
            OnClickCommand = new RelayCommand(SwitchView);
            OnDummyDataCommand = new RelayCommand(DummyData);
            CurrentViewKey = "Address";
            LoadData();
        }

        private void LoadData()
        {
            //TODO Relative and not absolute way to find file
            var jsonFile = File.ReadAllText(@"C:\Users\noelstark\source\repos\Hospital-Management-System\HospitalManagementSystem\Files\europe_countries_cities.json");
            _countries = JsonSerializer.Deserialize<List<CountryData>>(jsonFile);
            if(_countries != null)
            {
                Countries = _countries.Select(x => x.Country).ToList();
            }
        }

        /// <summary>
        /// Fills the dicitonary with values and show the text view (address)
        /// on a button click
        /// </summary>
        /// <param name="x"></param>
        private void SwitchView(object x)
        {
            if(CurrentViewKey == "PersonalInformation")
            {
                _customerProperties["FirstName"] = _firstname;
                _customerProperties["LastName"] = _lastname;
                _customerProperties["SSN"] = _ssn;
                _customerProperties["Email"] = _email;
                _customerProperties["Phone_Number"] = _phone;
            }
            //TODO Should be an else if-statement and not if-statement
            if(CurrentViewKey == "Address" || dummyData)
            {
                _customerProperties["Country"] = _country;
                _customerProperties["State"] = _state;
                _customerProperties["PostalCode"] = _postalcode;
                _customerProperties["Street"] = _street;
                _customerProperties["City"] = _city;
            }
            CreateCustomer();

            CurrentViewKey = CurrentViewKey == "PersonalInformation" ? "Address" : "PersonalInformation";
        }
        /// <summary>
        /// A Method that just fills in some values
        /// into the fields with a button click for test purposes
        /// </summary>
        /// <param name="x"></param>
        private void DummyData(object x)
        {
            _firstname = "Jöns";
            _lastname = "Jönsson";
            _email = "jons@gmail.com";
            _ssn = "0101010101";
            _phone = "0721234567";
            _city = "Gothenburg";
            _state = "Partille";
            _postalcode = "12345";
            _street = "Sommargatan 2";
            _country = "Sweden";
            dummyData = true;
        }

        /// <summary>
        /// Creates a customer based on values
        /// in the dictionary
        /// </summary>
        /// <returns></returns>
        private Customer CreateCustomer()
        {
            Customer customer = new Customer();
            foreach(var property in _customerProperties)
            {
                PropertyInfo? propertyInfo = typeof(Customer).GetProperty(property.Key);
                //Outer for-loop checks if property exists and inner loop converts value to type 'long'
                if(propertyInfo != null)
                {
                    if(propertyInfo.PropertyType != typeof(string))
                    {
                        propertyInfo.SetValue(customer, Convert.ToInt64(property.Value));
                        continue;
                    }
                    propertyInfo.SetValue(customer, property.Value);
                }
            }
            return customer;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using BusinessLayer;
using EntityLayer;
using HospitalManagementSystem.Commands;

namespace HospitalManagementSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string currentViewKey;
        private bool dummyData = false;
        public AddressViewModel AddressInfo { get; private set; }
        public PrivacyPolicyViewModel PrivacyPolicy { get; private set; }
        public PersonalInfoViewModel PersonalInfo { get; private set; }

        #region Binding Attributes
        private List<string> _templates = new List<string>()
        {
            "PersonalInformation", "Address", "PrivacyPolicyTemplate", "MainMenu"
        };

        //Needed or not?
        public List<string> Countries { get; set; }

        private Dictionary<string, string> _customerProperties = new Dictionary<string, string>();
       

       

        public string CurrentViewKey
        {
            get => currentViewKey;
            set
            {
                currentViewKey = value;
                OnPropertyChanged();
            }
        }
        
      

       

        #endregion

        #region Commands
        public ICommand OnClickCommand { get; set; }
        public ICommand OnDummyDataCommand { get; set; }

        
        #endregion
        public MainViewModel()
        {
            AddressInfo = new AddressViewModel();
            PrivacyPolicy = new PrivacyPolicyViewModel();
            PersonalInfo = new PersonalInfoViewModel();
            OnClickCommand = new RelayCommand(SwitchView);
            OnDummyDataCommand = new RelayCommand(DummyData);
            CurrentViewKey = "MainMenu";
            //_dataService = new DataService();
            //_countries = new DataService().LoadCountries(@"C:\Users\noelk\source\repos\HospitalManagementSystem\HospitalManagementSystem\Files\europe_countries_cities.json");
            //_filterService = new FilterService(_countries);
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
                    _customerProperties["FirstName"] = PersonalInfo.FirstName;
                    _customerProperties["LastName"] = PersonalInfo.LastName;
                    _customerProperties["SSN"] = PersonalInfo.SSN;
                    _customerProperties["Email"] = PersonalInfo.Email;
                    _customerProperties["Phone_Number"] = PersonalInfo.Phone;
                    CurrentViewKey = _templates[1];
                }
                //TODO Should be an else if-statement and not if-statement
                else if(CurrentViewKey == "Address")
                {
                    _customerProperties["Country"] = AddressInfo.SelectedCountry;
                    _customerProperties["State"] = AddressInfo.State;
                    _customerProperties["PostalCode"] = AddressInfo.PostalCode;
                    _customerProperties["Street"] = AddressInfo.Street;
                    _customerProperties["City"] = AddressInfo.SelectedCity;
                    CurrentViewKey = _templates[2];
                }
                else if (CurrentViewKey == "PrivacyPolicyTemplate")
                {
                    if (!PrivacyPolicy.PrivacyPolicyChecked)
                    {
                        MessageBox.Show("Please Accept the Privacy Policy");
                    }
                    else
                        CustomerController.CreateCustomer(_customerProperties, PrivacyPolicy.ShareInfoChecked);
                }
        }
        
        /// <summary>
        /// A Method that just fills in some values
        /// into the fields with a button click for test purposes
        /// </summary>
        /// <param name="x"></param>
        private void DummyData(object x)
        {
            PersonalInfo.FirstName = "Jöns";
            PersonalInfo.LastName = "Jönsson";
            PersonalInfo.Email = "jons@gmail.com";
            PersonalInfo.SSN = "0101010101";
            PersonalInfo.Phone = "0721234567";
            AddressInfo.SelectedCountry = "Sweden";
            AddressInfo.SelectedCity = "Gothenburg";
            AddressInfo.State = "Partille";
            AddressInfo.PostalCode = "12345";
            AddressInfo.Street = "Sommargatan 2";
            dummyData = true;
        }

        /// <summary>
        /// Creates a customer based on values
        /// in the dictionary
        /// </summary>
        /// <returns></returns>
        

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.ViewModels
{
    public class AddressViewModel : INotifyPropertyChanged
    {
        private string _country = "Country", _street = "Street", _postalcode = "12345", _city = "City", _state = "State";
        private static List<CountryData>? _countries;
        private List<string> _cities;
        private string _selectedCountry, _countrySearch, _selectedCity, _citySearch;
        private FilterService _filterService;
        private DataService _dataService;

        //public string Country
        //{
        //    get { return _country; }
        //    set { _country = value; OnPropertyChanged(); }
        //}
        //public string City
        //{
        //    get { return _city; }
        //    set { _city = value; OnPropertyChanged(); }
        //}

        public string Street
        {
            get { return _street; }
            set { _street = value; OnPropertyChanged(); }
        }
        public string PostalCode
        {
            get { return _postalcode; }
            set { _postalcode = value; OnPropertyChanged(); }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> FilteredCountries
        {
            get => _filterService.FilteredCountries;
            set
            {
                _filterService.FilteredCountries = value;
                OnPropertyChanged(nameof(FilteredCountries));
            }
        }

        public ObservableCollection<string> FilteredCities
        {
            get { return _filterService.FilteredCities; }
            set
            {
                _filterService.FilteredCities = value;
                OnPropertyChanged(nameof(FilteredCities));
            }
        }

        public string CountrySearch
        {
            get { return _countrySearch; }
            set
            {
                _countrySearch = value;
                FilteredCountries = _filterService.FilterCountries(_countrySearch);
            }
        }

        public string CitySearch
        {
            get { return _citySearch; }
            set
            {
                _citySearch = value;
                FilteredCities = _filterService.FilterCities(_selectedCountry, _citySearch);
            }
        }

        public string SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                CountryData? country = _countries.FirstOrDefault(c => c.Country == _selectedCountry);
                if (country != null)
                {
                    var cities = country.Cities.ToList();
                    FilteredCities = new ObservableCollection<string>(cities);
                }
            }
        }

        public string SelectedCity
        {
            get { return _selectedCity; }
            set { _selectedCity = value; OnPropertyChanged(); }
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static AddressViewModel()
        {
            _countries = new DataService().LoadCountries(@"C:\Users\noelk\source\repos\HospitalManagementSystem\HospitalManagementSystem\Files\europe_countries_cities.json");

        }
        public AddressViewModel()
        {
            _dataService = new DataService();
            _filterService = new FilterService(_countries);
        }

    }
}

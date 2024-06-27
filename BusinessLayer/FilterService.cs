using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FilterService
    {
        private readonly List<CountryData> _countries;
        public ObservableCollection<string> FilteredCountries { get; set; }
        public ObservableCollection<string> FilteredCities { get;  set; }

        public FilterService(List<CountryData> Countries)
        {
            _countries = Countries;
            FilteredCountries = new ObservableCollection<string>(_countries.Select(x=>x.Country).ToList());
            FilteredCities = new ObservableCollection<string>();
        }

        public ObservableCollection<string> FilterCountries(string search)
        {
             var filtered = _countries.Where(x => x.Country.StartsWith(search, StringComparison.InvariantCultureIgnoreCase)).
             Select(x => x.Country).ToList();
             FilteredCountries = new ObservableCollection<string>(filtered);
            return FilteredCountries;
        }

        public ObservableCollection<string> FilterCities(string selectedCountry, string search)
        {
            CountryData country = _countries.FirstOrDefault(c => c.Country == selectedCountry);
            var cities = country.Cities.Where(x => x.StartsWith(search.ToString(), StringComparison.InvariantCultureIgnoreCase));
            FilteredCities = new ObservableCollection<string>(cities);
            return FilteredCities;
            
        }
    }
}

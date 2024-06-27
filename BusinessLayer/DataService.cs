using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DataService
    {
        public List<CountryData> LoadCountries(string path)
        {
            //TODO Relative and not absolute way to find file
            var jsonFile = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<CountryData>>(jsonFile) ?? new List<CountryData>();
            //_filterService = new FilterService(_countries);
            //_filterService.FilteredCountries = new ObservableCollection<string>(_countries.Select(x => x.Country).ToList());
        }
    }
}

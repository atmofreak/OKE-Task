using OKEtaskData.Interfaces;
using OKEtaskData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKEtaskDataRepository
{
    public class DataRepository
    {
        private IDataManager _dataManager { get; set; }
        public DataRepository(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<Country> GetCountries()
        {
            return _dataManager.GetCountries();
        }
        public CountryWithDetails GetCountryById(int id)
        {
            return _dataManager.GetCountryById(id);
        }
        public string AddCountry(CountryWithDetails country)
        {
            return _dataManager.AddCountry(country);
        }
    }
}

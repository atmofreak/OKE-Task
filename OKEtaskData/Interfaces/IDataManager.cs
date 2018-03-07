using OKEtaskData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKEtaskData.Interfaces
{
    public interface IDataManager
    {
        List<Country> GetCountries();
        CountryWithDetails GetCountryById(int id);
        string AddCountry(CountryWithDetails country);
    }
}

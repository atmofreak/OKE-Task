using OKEtaskData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKEtask.Models
{
    public class Countries
    {
        public List<Country> CountriesList { get; set; }
        public int SelectedCountry { get; set; }
        public CountryWithDetails CountryToAdd { get; set; }
    }
}
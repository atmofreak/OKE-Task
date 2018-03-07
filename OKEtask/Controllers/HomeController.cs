using OKEtask.Models;
using OKEtaskData.Interfaces;
using OKEtaskDataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OKEtask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataRepository dataRepository = new DataRepository(new XMLparser.XMLparser());
            Countries countries = new Countries
            {
                CountriesList = dataRepository.GetCountries()
            };
            return View(countries);
        }

        public ActionResult CountryDetails(Countries countries)
        {
            DataRepository dataRepository = new DataRepository(new XMLparser.XMLparser());
            var selectedCountry = countries.SelectedCountry;
            if (selectedCountry != 0)
            {
                var countryDetails = new CountriesDetails();
                countryDetails.CountryDetails = dataRepository.GetCountryById(selectedCountry);
                return View(countryDetails);
            }
            countries = new Countries
            {
                CountriesList = dataRepository.GetCountries()
            };
            return View("Index",countries);
        }

        public ActionResult AddCountry(Countries countries)
        {
            DataRepository dataRepository = new DataRepository(new XMLparser.XMLparser());
            if (ModelState.IsValid)
            {
                ViewBag.Message = dataRepository.AddCountry(countries.CountryToAdd);
                countries.CountriesList = dataRepository.GetCountries();
                return View("Index", countries);
            }
            else
            {
                countries.CountriesList = dataRepository.GetCountries();
                return View("Index", countries);
            }
        }
    }
}
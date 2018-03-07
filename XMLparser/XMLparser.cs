using OKEtaskData.Interfaces;
using OKEtaskData.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLparser
{
    public class XMLparser : IDataManager
    {
        private string _fileLocalization { get; set; }

        public XMLparser()
        {
            _fileLocalization = ConfigurationManager.AppSettings["XMLtoParsePath"] ?? Directory.GetCurrentDirectory() + @"\Countries.xml";
        }

        public XMLparser(string fileLocalization)
        {
            _fileLocalization = fileLocalization;
        }

        public string AddCountry(CountryWithDetails country)
        {
            try
            {
                if(country.Id <= 0)
                {
                    return "Id cannot be lower than 1";
                }
                XDocument xmlDoc;
                if (!File.Exists(_fileLocalization))
                {
                    xmlDoc = new XDocument(new XElement("countries"));
                    Directory.CreateDirectory(Path.GetDirectoryName(_fileLocalization));
                }
                else
                {
                    xmlDoc = XDocument.Load(_fileLocalization);
                }
                if(xmlDoc.Root.Elements("country").Any(x => int.Parse(x.Element("id").Value) == country.Id))
                {
                    return "Country with this id currently exists";
                }
                XElement root = new XElement("country");
                root.Add(new XElement("id", country.Id));
                root.Add(new XElement("name", country.Name));
                root.Add(new XElement("capital", country.Capital));
                root.Add(new XElement("areacode", country.AreaCode));
                xmlDoc.Element("countries").Add(root);
                xmlDoc.Save(_fileLocalization);
                return "Country Added";
            }
            catch (Exception ex)
            {
                //Log Exception
                return "Unable to Add country";
            }
        }

        public List<Country> GetCountries()
        {
            try
            {
                var xmlDoc = XDocument.Load(_fileLocalization);
                var elements = xmlDoc.Root.Elements("country");
                return elements.Select(x => new Country() { Id = int.Parse(x.Element("id").Value), Name = x.Element("name").Value }).ToList();
            }
            catch (Exception ex)
            {
                //Log Exception
                return new List<Country>();
            }
        }

        public CountryWithDetails GetCountryById(int id)
        {
            try
            {
                var xmlDoc = XDocument.Load(_fileLocalization);
                var elements = xmlDoc.Root.Elements("country");
                return elements.Select(x => new CountryWithDetails() { Id = int.Parse(x.Element("id").Value), Name = x.Element("name").Value, AreaCode = int.Parse(x.Element("areacode").Value), Capital = x.Element("capital").Value }).Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //Log Exception
                return null;
            }
        }
    }
}

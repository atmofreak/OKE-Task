using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKEtaskData.Model
{
    public class CountryWithDetails : Country
    {
        [Required(ErrorMessage = "Please provide capital of country")]
        public string Capital { get; set; }
        [Required(ErrorMessage = "Please provide country area code")]
        public int AreaCode { get; set; }
    }
}

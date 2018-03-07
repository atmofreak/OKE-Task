using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKEtaskData.Model
{
    public class Country
    {
        [Required(ErrorMessage = "Please provide country id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide country name")]
        public string Name { get; set; }
    }
}

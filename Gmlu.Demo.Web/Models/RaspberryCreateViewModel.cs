using System;
using System.ComponentModel.DataAnnotations;

namespace Gmlu.Demo.Web.Models
{
    public class RaspberryCreateViewModel
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public string Name { get; set; }

        [RegularExpression(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b", ErrorMessage = "Invalid IP-Address!")]
        [Required]
        public string IPadress { get; set; }
    }
}

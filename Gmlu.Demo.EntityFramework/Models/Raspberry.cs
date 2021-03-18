using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gmlu.Demo.EntityFramework.Models
{
    public class Raspberry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RaspberryId { get; set; }

        [Required]
        [StringLength(15)]
        public String IPadress { get; set; }

        [Required]
        [StringLength(130)]
        public String Name { get; set; }

        [Required]
        [StringLength(130)]
        public String location { get; set; }

    }
}

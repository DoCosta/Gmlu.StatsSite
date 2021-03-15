using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gmlu.Demo.EntityFramework.Models
{
    public class MeasurePoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid MeasurePointId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Temp { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Humidity { get; set; }

        [StringLength(128)]
        [Required]
        public string Device { get; set; }
    }
}

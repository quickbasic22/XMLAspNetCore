using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLAspNetCore.Models
{
    public class Advertisement
    {
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(200)]
        public string AdTitle { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int Duration { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Condition { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(typeof(Decimal), "1.00", "1000000.0")]
        public decimal Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

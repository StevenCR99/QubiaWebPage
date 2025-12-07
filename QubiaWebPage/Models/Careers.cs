using System.ComponentModel.DataAnnotations;

namespace QubiaWebPage.Models
{
    public class Careers
    {
        public int ID { get; set; }

        [Required]
        [MinLength(5)]
        public string NombreCompleto { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$")] //incluyendo ceros
        public string Cedula { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{9,12}$")]
        public string Telefono { get; set; }

        [Required]
        public string Estudios { get; set; }

        [Required]  
        public  string ComoConocio { get; set; }

        [Required]
        public bool ActualmenteTrabaja { get; set; }

        [Required]
        [Range (450000,6000000)]
        public decimal ExpectativaSalarial { get; set; }

        [Required]
        public string CV {  get; set; }


    }
}

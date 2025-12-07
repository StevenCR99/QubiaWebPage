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
        [RegularExpression(@"^\d{9,12}$")]
        public string Cedula { get; set; }
    }
}

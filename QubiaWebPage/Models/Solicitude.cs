using System;
using System.ComponentModel.DataAnnotations;

namespace QubiaWebPage.Models
{
    public partial class Solicitude
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre debe tener mínimo 3 letras")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria")]
        [RegularExpression(@"^\d{7,}$", ErrorMessage = "La cédula debe tener mínimo 7 números")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo debe tener formato válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener 8 números")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe indicar sus estudios")]
        [MinLength(3, ErrorMessage = "Debe tener mínimo 3 letras")]
        public string Estudios { get; set; }

        [Required(ErrorMessage = "Debe indicar cómo conoció la empresa")]
        [MinLength(3, ErrorMessage = "Debe tener mínimo 3 letras")]
        public string ConocioEmpresa { get; set; }

        public bool ActualmenteTrabaja { get; set; }

        [Required(ErrorMessage = "Debe indicar su expectativa salarial")]
        [Range(1, double.MaxValue, ErrorMessage = "Ingrese un monto válido en colones")]
        public decimal ExpectativaSalarial { get; set; }

        // 🔹 NO se valida aquí porque se llena en el controller
        public string? CVRuta { get; set; }

        public DateTime FechaSolicitud { get; set; }
    }
}

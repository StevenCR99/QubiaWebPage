using System;
using System.Collections.Generic;

namespace QubiaWebPage.Models;

public partial class Solicitude
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Estudios { get; set; }

    public string? ConocioEmpresa { get; set; }

    public bool ActualmenteTrabaja { get; set; }

    public decimal? ExpectativaSalarial { get; set; }

    public string? Cvruta { get; set; }

    public DateTime? FechaSolicitud { get; set; }
}

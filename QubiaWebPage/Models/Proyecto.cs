using System;
using System.Collections.Generic;

namespace QubiaWebPage.Models;

public partial class Proyecto
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? ImagenUrl { get; set; }
}

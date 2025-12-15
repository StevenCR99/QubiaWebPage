using System;
using System.Collections.Generic;

namespace QubiaWebPage.Models;

public partial class EmpresaInfo
{
    public int Id { get; set; }

    public string Seccion { get; set; } = null!;

    public string Contenido { get; set; } = null!;
}

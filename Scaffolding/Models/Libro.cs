using System;
using System.Collections.Generic;

namespace Scaffolding.Models;

public partial class Libro
{
    public long Id { get; set; }

    public string Autor { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public int Edicion { get; set; }

    public string Isbn { get; set; } = null!;
}

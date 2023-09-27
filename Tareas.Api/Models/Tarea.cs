using System;
using System.Collections.Generic;

namespace Tareas.Api.Models;

public partial class Tarea
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Completado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }
}

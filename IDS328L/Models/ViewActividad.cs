using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IDS328L.Models;

[Keyless]
public partial class ViewActividad
{
    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaEjecutado { get; set; }

    public int Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCreado { get; set; }
}

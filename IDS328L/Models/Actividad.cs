using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IDS328L.Models;

[Table("Actividad")]
public partial class Actividad
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaEjecutado { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCreado { get; set; }

    public bool? Estadi { get; set; }

    [InverseProperty("IdActividadNavigation")]
    public virtual ICollection<PersonaActividad> PersonaActividads { get; } = new List<PersonaActividad>();
}

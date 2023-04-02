using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IDS328L.Models;

[Table("Persona")]
public partial class Persona
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Apellido { get; set; }

    [StringLength(50)]
    public string? Cedula { get; set; }

    [StringLength(50)]
    public string? Telefono { get; set; }

    [StringLength(50)]
    public string? Direccion { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaDeCreacion { get; set; }

    public bool? Estado { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<PersonaActividad> PersonaActividads { get; } = new List<PersonaActividad>();
}

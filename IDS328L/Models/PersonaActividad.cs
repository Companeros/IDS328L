using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IDS328L.Models;

[Table("Persona_Actividad")]
public partial class PersonaActividad
{
    [Key]
    public int Id { get; set; }

    public int? IdPersona { get; set; }

    public int? IdActividad { get; set; }

    public bool? Estado { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCrecion { get; set; }

    [ForeignKey("IdActividad")]
    [InverseProperty("PersonaActividads")]
    public virtual Actividad? IdActividadNavigation { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("PersonaActividads")]
    public virtual Persona? IdPersonaNavigation { get; set; }
}

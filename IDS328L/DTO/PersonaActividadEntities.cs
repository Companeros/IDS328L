using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IDS328L.DTO
{
    public class PersonaActividadEntities
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
        public virtual ActividadEntities? IdActividadNavigation { get; set; }

        [ForeignKey("IdPersona")]
        [InverseProperty("PersonaActividads")]
        public virtual PersonaEntities? IdPersonaNavigation { get; set; }
    }
}

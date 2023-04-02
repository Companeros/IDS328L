using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IDS328L.DTO
{
    public class ActividadEntities
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaEjecutado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCreado { get; set; }

        public bool? Estado { get; set; }
    }
}

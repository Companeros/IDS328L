using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IDS328L.DTO
{
    public class PersonaEntities
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
    }
}

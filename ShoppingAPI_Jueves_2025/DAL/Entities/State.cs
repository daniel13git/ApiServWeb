using ShoppingAPI_Jueves_2025.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DAL.Entities
{
    public class State: AuditBase
    {
        [Display(Name = "Estados o departamentos")] // identificar el nombre
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres. ")] // longitud maxima
        [Required(ErrorMessage = "El campo {0} es oblogatorio.")] // campo obligatorio
        public string Name{ get; set; }

        // Relacion de dos tablas con Entity Framework Core
        [Display(Name = "Pais")]
        public Country? Country { get; set; }

        [Display(Name = "Id del pais")]
        public Guid CountryId { get; set; } // FK 

        // Luego de las anteriores lineas de codigo, ir a Country y crear la relacion alla tambien
    }
}

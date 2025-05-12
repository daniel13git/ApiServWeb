using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2025.DAL.Entities
{
    public class Country:AuditBase
    {
        [Display(Name = "Pais")] // identificar el nombre
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres. ")] // longitud maxima
        [Required(ErrorMessage = "El campo {0} es oblogatorio.")] // campo obligatorio
        public string Name{ get; set; }

    }
}

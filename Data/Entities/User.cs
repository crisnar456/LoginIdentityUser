
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LoginIdentityUser.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        public string Apellidos { get; set; }

        [Display(Name = "Nombre completo")]
        public string nombreCompleto => $"{Nombres} {Apellidos}";

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginIdentityUser.Models
{
    public class AddUserDto
    {
        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El {0} campo no puede contener mas {1} caracteres.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        public string Username { get; set; }
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede contener mas {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede contener mas {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Apellidos { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}

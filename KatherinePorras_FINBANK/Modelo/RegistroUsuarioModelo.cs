using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KatherinePorras_FINBANK.Modelo
{
    public class RegistroUsuarioModelo
    {
        [Required]
        [DisplayName("Ingrese su Cédula")]
        [StringLength(255, ErrorMessage = "Cedula Incorrecta", MinimumLength = 10)]
        public string CEDULA { get; set; }
        [Required]
        [DisplayName("Ingrese su Nombre")]
        public string NOMBRE { get; set; }
        [Required]
        [DisplayName("Ingrese su Apellido")]
        public string APELLIDO { get; set; }
    
        [Required]
        [DisplayName("Ingrese su mail")]
        [DataType(DataType.EmailAddress)]
        public string USUARIO { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener al menos 7 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public String PassUsuario { get; set; }

        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener al menos 7 caracteres", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Compare("PassUsuario")]
        [DisplayName("Repita la Contraseña")]
        public String PassUsuarionew { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fechaNacimiento  { get; set; }
    }
}
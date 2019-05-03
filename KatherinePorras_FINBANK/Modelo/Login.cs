using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KatherinePorras_FINBANK.Modelo
{
    /// <summary>
    ///    Modelo para ingreso al sistema 
    /// </summary>
    public class Login
    {
        [Required]
        [DisplayName("Ingrese su mail")]
        public string mail { get; set; }
        [Required]
        [DisplayName("Ingrese su password")]
        public string contraseña { get; set; }
        public string estado { get; set; }
    }
}

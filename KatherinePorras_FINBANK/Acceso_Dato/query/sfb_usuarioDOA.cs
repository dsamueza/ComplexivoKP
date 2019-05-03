using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KatherinePorras_FINBANK.Acceso_Dato.@base;
using KatherinePorras_FINBANK.Modelo;
using KatherinePorras_FINBANK.Infraestructra;

namespace KatherinePorras_FINBANK.Acceso_Dato.transacciones
{
    public class sfb_usuarioDOA: IBaseDAO
    {

        public Login UsuarioValido(string usuario, string contraseña)
        {


            var _usuario = ctx.SFB_USUARIO.Where(x => x.SFB_USU_USUARIO == usuario && x.SFB_USU_PASSWORD == contraseña);
            if (usuario.Count() > 0)
            {
                return _usuario.ToList().Select(x => new Login { contraseña = x.SFB_USU_PASSWORD, mail = x.SFB_USU_USUARIO,estado=x.SFB_USU_ESTADO }).FirstOrDefault();

            }
            else
            {
                return null;
            }


        }
           
               
       
    }
}
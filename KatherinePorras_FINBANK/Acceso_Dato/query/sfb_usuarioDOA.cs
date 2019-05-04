using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KatherinePorras_FINBANK.Acceso_Dato.@base;
using KatherinePorras_FINBANK.Modelo;
using KatherinePorras_FINBANK.Infraestructra;
using System.Data.Entity.Validation;

namespace KatherinePorras_FINBANK.Acceso_Dato.transacciones
{
    public class sfb_usuarioDOA: IBaseDAO
    {

        public Login UsuarioValido(string usuario, string contraseña)
        {


            var _usuario = ctx.SFB_USUARIO.Where(x => x.SFB_USU_USUARIO == usuario && x.SFB_USU_PASSWORD == contraseña);
            if (usuario.Count() > 0)
            {
                return _usuario.ToList().Select(x => new Login { contraseña = x.SFB_USU_PASSWORD, mail = x.SFB_USU_USUARIO,estado=x.SFB_USU_ESTADO,Idusario=x.SFB_USU_ID }).FirstOrDefault();

            }
            else
            {
                return null;
            }


        }

        public int InsertarUsuario(RegistroUsuarioModelo _modeloRegistraUsuario)
        {
            try
            {
                var _selectExisteUsuario = ctx.SFB_USUARIO.Where(x => x.SFB_USU_CEDULA.Equals(_modeloRegistraUsuario.CEDULA));
                if (_selectExisteUsuario.Count() == 0) {
                SFB_USUARIO _tb_sfb_usuario = new SFB_USUARIO();
                _tb_sfb_usuario.SFB_USU_CEDULA = _modeloRegistraUsuario.CEDULA;
                _tb_sfb_usuario.SFB_USU_NOMBRE = _modeloRegistraUsuario.NOMBRE;
                _tb_sfb_usuario.SFB_USU_APELLIDO = _modeloRegistraUsuario.APELLIDO;
                _tb_sfb_usuario.SFB_USU_EDAD = _modeloRegistraUsuario.fechaNacimiento;
                _tb_sfb_usuario.SFB_USU_PASSWORD = _modeloRegistraUsuario.PassUsuario;
                _tb_sfb_usuario.SFB_USU_USUARIO = _modeloRegistraUsuario.USUARIO;
                _tb_sfb_usuario.SFB_USU_ESTADO =VariableConstante.usuarioCreado ;
                ctx.SFB_USUARIO.Add(_tb_sfb_usuario);
                ctx.SaveChanges();
                    return 1;
                }
                return 2;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
           
                return 0;
            }
           
            

           


        }

        public int ActulizarUsuario(int id)
        {


            var _usuario = ctx.SFB_USUARIO.Where(x => x.SFB_USU_ID.Equals(id));
            if (_usuario.Count() > 0)
            {
                var _datoActualizar= _usuario.FirstOrDefault() ;
                _datoActualizar.SFB_USU_ESTADO = "A";
                ctx.Entry(_datoActualizar).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return 1;
            }
            else
            {
                return 2;
            }


        }

    }
}
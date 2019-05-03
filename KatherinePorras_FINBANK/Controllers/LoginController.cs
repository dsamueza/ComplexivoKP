using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using KatherinePorras_FINBANK.Modelo;
using KatherinePorras_FINBANK.Infraestructra;
using KatherinePorras_FINBANK.Negocio;
namespace KatherinePorras_FINBANK.Controllers
{
    public class LoginController : Controller
    {

        #region variables de clase

        private Encriptacion _encriptacion = new Encriptacion();
        private UsuarioBSS _usuarioBSS= new UsuarioBSS();
        #endregion
        /// <summary>
        /// Esta vista presenta el login principa
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.mensajeLogin = "";
            return View();
        }
        /// <summary>
        /// Vista para validr autentificación
        /// </summary>
        /// <param name="ModeloLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Login ModeloLogin )
        {
           
            if (ModelState.IsValid) {
                var _valorcontraseñaEncríptado=_encriptacion.Encriptar(ModeloLogin.contraseña);
                var _result=_usuarioBSS.ValidarUsuario(ModeloLogin.mail,_valorcontraseñaEncríptado);
                switch (_result)
                {
                    case 1:
                        Session[CSession.Clogeado]="Correcto";
                        return RedirectToAction("Index", "Cotizacion");
                       case 2:
                        ViewBag.mensajeLogin = "Usuario o contraseña Incorrecto ";
                        break;
                    case 3:
                        ViewBag.mensajeLogin = "El usuario no se encuentra activo. Favor la confirmación enviada a su mail.";
                        break;
                    default:
                        break;
                
                }
                return View(ModeloLogin);
                ///codigo
            }
            ViewBag.mensajeLogin = "Revise que todos los campos se encuentre correctos";
            return View(ModeloLogin);
        }

        public ActionResult RegistroUsuario()
        {
            return View();
        }
        public ActionResult RegistroUsuarioV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistroUsuario(RegistroUsuarioModelo ModeloRegistroUsuario)


        {

            var _model = ModeloRegistroUsuario;
            return View();
        }
    }
}

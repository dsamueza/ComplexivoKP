using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KatherinePorras_FINBANK.Infraestructra;
using KatherinePorras_FINBANK.Negocio;
using KatherinePorras_FINBANK.Modelo;
using Newtonsoft.Json;

namespace KatherinePorras_FINBANK.Controllers
{
    public class CotizacionController : Controller
    {
        private CotizacionBss _cotizacionBss = new CotizacionBss();
        // GET: Cotizacion
        public ActionResult Index()
        {

           var idusuario  = Session[CSession.Clogeado].ToString();
                
            ViewData[CSession.CIdusuario]= idusuario;
            InicializarCatalogos();
 
            return View();
        }
        /// <summary>
        /// Controlador JSON para generar el modelo de VUE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get(string id ) {

            if (id != null) {

                int usuarioId = int.Parse(id);
              var _modelovue=  _cotizacionBss._GestionCotizacion(usuarioId);
              var jsonModelo=  JsonConvert.SerializeObject(_modelovue);
                return Json(_modelovue, JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }
        void InicializarCatalogos() {
            ViewBag.sucursal = _cotizacionBss._TraerSucursal()
                    .Select(katherine => new SelectListItem
                    {
                        Value = katherine.Value,
                        Text = katherine.Text
                    }).OrderBy(x => x.Value).ToList();

            ViewBag.interes = _cotizacionBss._TraerInteres()
                    .Select(katherine => new SelectListItem
                    {
                        Value = katherine.Value,
                        Text = katherine.Text
                    }).ToList();

            ViewBag.amortizacion = _cotizacionBss._TraerAmortizacion()
                   .Select(katherine => new SelectListItem
                   {
                       Value = katherine.Value,
                       Text = katherine.Text

                   }).ToList();
        }
        public JsonResult Calcular(string _modeloSolicitudCliente)
        {

            if (_modeloSolicitudCliente != null)
            {
                var _modelovue =  JsonConvert.DeserializeObject<ModeloCotizacion>(_modeloSolicitudCliente);
              
                //int usuarioId = int.Parse(id);
                var _modelovueData = _cotizacionBss._RealizarCalculoAmortizacion(_modelovue);
                return Json(_modelovueData, JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }
    }
}

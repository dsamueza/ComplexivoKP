using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KatherinePorras_FINBANK.Infraestructra;
namespace KatherinePorras_FINBANK.Controllers
{
    public class CotizacionController : Controller
    {
        // GET: Cotizacion
        public ActionResult Index()
        {
           var idusuario  = Session[CSession.Clogeado].ToString();


            return View();
        }

        // GET: Cotizacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cotizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cotizacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cotizacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cotizacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cotizacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cotizacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

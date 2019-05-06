using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class SeccionesController : Controller
    {
        seccionBL _seccionesBL;

        public SeccionesController()
        {
            _seccionesBL = new seccionBL();
        }

        // GET: Secciones
        public ActionResult Index()
        {

            var ListadeSecciones = _seccionesBL.ObtenerSecciones();

            return View(ListadeSecciones);

        }

        public ActionResult Crear()
        {
            var nuevaSeccion = new seccion();

            return View(nuevaSeccion);
        }

        [HttpPost]
        public ActionResult Crear(seccion seccion)
        {
            if (ModelState.IsValid)
            {
                if (seccion.Descripcion != seccion.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe haber espacios al inicio o al final");
                    return View(seccion);
                }
                _seccionesBL.GuardarSeccion(seccion);

                return RedirectToAction("Index");
            }

            return View(seccion);

        }


        public ActionResult Editar(int id)
        {
            var seccion = _seccionesBL.ObtenerSecciones(id);


            return View(seccion);
        }

        [HttpPost]
        public ActionResult Editar(seccion seccion)
        {
            _seccionesBL.GuardarSeccion(seccion);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var seccion = _seccionesBL.ObtenerSecciones(id);

            return View(seccion);
        }

        public ActionResult Eliminar(int id)
        {
            var seccion = _seccionesBL.ObtenerSecciones(id);

            return View(seccion);
        }

        [HttpPost]
        public ActionResult Eliminar(seccion seccion)
        {
            _seccionesBL.EliminarSeccion(seccion.Id);

            return RedirectToAction("Index");
        }
    }
}
using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class GradosController : Controller
    {
        GradosBL _gradosBL;

        public GradosController()
        {
            _gradosBL = new GradosBL();
        }

        // GET: Grados
        public ActionResult Index()
        {
            var listadeGrados = _gradosBL.ObtenerGrados();

            return View(listadeGrados);
        }

        public ActionResult Crear()
        {
            var nuevoGrado = new Grado();

            return View(nuevoGrado);
        }

        [HttpPost]
        public ActionResult Crear(Grado grado)
        {
            if (ModelState.IsValid)
            {
                if(grado.Descripcion != grado.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe de haber espacios al inicio o al final");
                    return View(grado);
                }
                _gradosBL.GuardarGrado(grado);

                return RedirectToAction("Index");
            }

            return View(grado);
        }

        public ActionResult Editar(int id)
        {
            var grado = _gradosBL.ObtenerGrado(id);


            return View(grado);
        }

        [HttpPost]
        public ActionResult Editar(Grado grado)
        {
            _gradosBL.GuardarGrado(grado);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var grado = _gradosBL.ObtenerGrado(id);

            return View(grado);
        }

        public ActionResult Eliminar(int id)
        {
            var grado = _gradosBL.ObtenerGrado(id);

            return View(grado);
        }

        [HttpPost]
        public ActionResult Eliminar(Grado grado)
        {
            _gradosBL.EliminarGrado(grado.Id);
            return RedirectToAction("Index");
        }
    }
}
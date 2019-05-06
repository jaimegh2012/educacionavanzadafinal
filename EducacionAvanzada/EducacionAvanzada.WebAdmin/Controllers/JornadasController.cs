using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class JornadasController : Controller
    {
        JornadasBL _jornadasBL;

        public JornadasController()
        {
            _jornadasBL = new JornadasBL();
        }

        // GET: Jornadas
        public ActionResult Index()
        {
            var ListadeJornadas = _jornadasBL.ObtenerJornadas();

            return View(ListadeJornadas);
        }

        public ActionResult Crear()
        {
            var nuevaJornada = new Jornada();

            return View(nuevaJornada);
        }

        [HttpPost]
        public ActionResult Crear(Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                if (jornada.Descripcion != jornada.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe haber espacios al inicio o al final");
                    return View(jornada);
                }
                _jornadasBL.GuardarJornada(jornada);

                return RedirectToAction("Index");
            }

            return View(jornada);
            
        }

        public ActionResult Editar(int id)
        {
            var jornada = _jornadasBL.ObtenerJornada(id);


            return View(jornada);
        }

        [HttpPost]
        public ActionResult Editar(Jornada jornada)
        {
            _jornadasBL.GuardarJornada(jornada);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var jornada = _jornadasBL.ObtenerJornada(id);

            return View(jornada);
        }

        public ActionResult Eliminar(int id)
        {
            var jornada = _jornadasBL.ObtenerJornada(id);

            return View(jornada);
        }

        [HttpPost]
        public ActionResult Eliminar(Jornada jornada)
        {
            _jornadasBL.EliminarJornada(jornada.Id);

            return RedirectToAction("Index");
        }
    }
}
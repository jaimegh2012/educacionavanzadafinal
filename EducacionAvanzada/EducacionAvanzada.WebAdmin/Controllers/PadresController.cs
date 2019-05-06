using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EducacionAvanzada.BL.SeguridadBL;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class PadresController : Controller
    {
        PadresBL _padresBL;

        public PadresController()
        {
            _padresBL = new PadresBL();
        }
        // GET: Padres
        public ActionResult Index()
        {
            var listadePadres = _padresBL.ObtenerPadres();

            return View(listadePadres);
        }

        public ActionResult Crear()
        {
            var nuevoPadre = new Padre();

            return View(nuevoPadre);
        }

        [HttpPost]
        public ActionResult Crear(Padre padre)
        {
            if (ModelState.IsValid)
            {
                if (padre.Nombre != padre.Nombre.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe de haber espacios al inicio o al final");
                    return View(padre);
                }
                padre.Contrasena = Encriptar.CodificarContrasena(padre.Contrasena);
                _padresBL.GuardarPadre(padre);

                return RedirectToAction("Index");
            }

            return View(padre);
        }

        public ActionResult Editar(int id)
        {
            var padre = _padresBL.ObtenerPadre(id);


            return View(padre);
        }

        [HttpPost]
        public ActionResult Editar(Padre padre)
        {
            _padresBL.GuardarPadre(padre);

            return RedirectToAction("Index");
        }

        
    }
}
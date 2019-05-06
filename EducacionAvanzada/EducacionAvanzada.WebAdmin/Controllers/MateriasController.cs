using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class MateriasController : Controller
    {
        materiaBL _materiasBL;

        public MateriasController()
        {
            _materiasBL = new materiaBL();
        }

        // GET: Materias
        public ActionResult Index()
        {
            var ListadeMaterias = _materiasBL.Obtenermaterias();

            return View(ListadeMaterias);
            
        }

        public ActionResult Crear()
        {
            var nuevaMateria = new Materia();

            return View(nuevaMateria);
        }

        [HttpPost]
        public ActionResult Crear(Materia materia)
        {
            if (ModelState.IsValid)
            {
                if (materia.Descripcion != materia.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe haber espacios al inicio o al final");
                    return View(materia);
                }
                _materiasBL.GuardarMateria(materia);

                return RedirectToAction("Index");
            }

            return View(materia);

        }


        public ActionResult Editar(int id)
        {
            var materia = _materiasBL.ObtenerMaterias(id);


            return View(materia);
        }

        [HttpPost]
        public ActionResult Editar(Materia materia)
        {
            _materiasBL.GuardarMateria(materia);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var materia = _materiasBL.ObtenerMaterias(id);

            return View(materia);
        }

        public ActionResult Eliminar(int id)
        {
            var materia = _materiasBL.ObtenerMaterias(id);

            return View(materia);
        }

        [HttpPost]
        public ActionResult Eliminar(Materia materia)
        {
           _materiasBL.EliminarMateria(materia.Id);

            return RedirectToAction("Index");
        }
    }
}
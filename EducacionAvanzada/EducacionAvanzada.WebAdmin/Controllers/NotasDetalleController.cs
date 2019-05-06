using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class NotasDetalleController : Controller

    {
        NotasBL _notaBL;
        AlumnosBL _alumnosBL;
        materiaBL _MateriaBL;
        

        public NotasDetalleController()
        {
            _notaBL = new NotasBL();
            _alumnosBL = new AlumnosBL();
            _MateriaBL = new materiaBL();
        }
        // GET: NotasDetalle
        public ActionResult Index(int id)
        {
            var Notas = _notaBL.ObtenerNota(id);
            Notas.ListadeNotasDetalle = _notaBL.ObtenerNotasDetalle(id);
            return View(Notas);
        }

        public ActionResult Crear(int id)   
        {
            var nuevaNotasDetalle = new NotasDetalle();
            nuevaNotasDetalle.NotaId = id;

            var alumnos = _alumnosBL.ObtenerAlumnosactivo();
            ViewBag.AlumnoId = new SelectList(alumnos, "Id", "Nombre");

            var materias = _MateriaBL.Obtenermaterias();
            ViewBag.MateriaId = new SelectList(materias, "Id", "Descripcion");

            return View(nuevaNotasDetalle);
        }

        [HttpPost]
        public ActionResult Crear(NotasDetalle notasDetalle)
        {
            if(ModelState.IsValid)
            {
                if(notasDetalle.AlumnoId == 0)
                {
                    ModelState.AddModelError("AlumnoId", "Seleccione un Alumno");
                    return View(notasDetalle);
                }

                _notaBL.GuardarNotasDetalle(notasDetalle);
                return RedirectToAction("Index", new { id = notasDetalle.NotaId });
            }
            var alumnos = _alumnosBL.ObtenerAlumnosactivo();
            ViewBag.AlumnoId = new SelectList(alumnos, "Id", "Nombre");

            return View(notasDetalle);
        }

        public ActionResult Editar(int Id)
        {
            var notaDetalle = _notaBL.ObtenerNotasDetalleporId(Id);
            var alumnos = _alumnosBL.ObtenerAlumnos();
            var materias = _MateriaBL.Obtenermaterias();


            ViewBag.AlumnoId = new SelectList(alumnos, "Id", "Nombre", notaDetalle.AlumnoId);
            ViewBag.MateriaId = new SelectList(materias, "Id", "Descripcion", notaDetalle.MateriaId);
          


            return View(notaDetalle);
        }

        [HttpPost]
        public ActionResult Editar(NotasDetalle notaDetalle)
        {
            var alumnos = _alumnosBL.ObtenerAlumnosactivo();
            var materias = _MateriaBL.Obtenermaterias();

            if (ModelState.IsValid)
            {


                if (notaDetalle.AlumnoId == 0 || notaDetalle.MateriaId == 0)
                {
                    if (notaDetalle.AlumnoId == 0)
                    {
                        ModelState.AddModelError("Alumno", "Seleccione un Alumno");
                    }

                    if (notaDetalle.MateriaId == 0)
                    {
                        ModelState.AddModelError("Materia", "Seleccione una Materia");
                    }

                    ViewBag.AlumnoId = new SelectList(alumnos, "Id", "Nombre");
                    ViewBag.MateriaId = new SelectList(materias, "Id", "Descripcion");

                    return View(notaDetalle);
                }

                _notaBL.GuardarNotasDetalle(notaDetalle, true);

                return RedirectToAction("Index",new { id = notaDetalle.NotaId });
            }

            ViewBag.AlumnoId = new SelectList(alumnos, "Id", "Nombre");
            ViewBag.MateriaId = new SelectList(materias, "Id", "Descripcion");
            return View(notaDetalle);
        }



        public ActionResult Eliminar(int id)
        {
            var notaDetalle = _notaBL.ObtenerNotasDetalleporId(id);

            return View(notaDetalle);
        }
        [HttpPost]
        public ActionResult Eliminar(NotasDetalle notaDetalle)
        {
            _notaBL.EliminarNotaDetalle(notaDetalle.Id);
            return RedirectToAction("Index", new { id = notaDetalle.NotaId });
        }
    }
    
}
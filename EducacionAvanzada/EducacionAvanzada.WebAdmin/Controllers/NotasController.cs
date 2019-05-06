using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class NotasController : Controller
    {
        NotasBL _notasBL;
        AlumnosBL _alumnosBL;
        GradosBL _gradosBL;
        JornadasBL _jornadasBL;
        seccionBL _seccionesBL;

        public NotasController()
        {
            _notasBL = new NotasBL();
            _alumnosBL = new AlumnosBL();
            _gradosBL = new GradosBL();
            _jornadasBL = new JornadasBL();
            _seccionesBL = new seccionBL();
        }
        // GET: Notas
        public ActionResult Index()
        {
            var listadeNotas = _notasBL.ObtenerNotas();

            return View(listadeNotas);
        }


        public ActionResult Crear()
        {
            var nuevaNota = new Notas();
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();
            


            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");


            return View(nuevaNota);
        }

        [HttpPost]
        public ActionResult Crear(Notas nota)
        {

            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();


            if (ModelState.IsValid)
            {
                if (nota.GradoId == 0 || nota.JornadaId == 0 || nota.SeccionId == 0)
                {
                    if (nota.GradoId == 0)
                    {
                        ModelState.AddModelError("Grado", "Seleccione un grado");
                    }

                    if (nota.JornadaId == 0)
                    {
                        ModelState.AddModelError("Jornada", "Seleccione una Jornada");
                    }

                    if (nota.SeccionId == 0)
                    {
                        ModelState.AddModelError("seccion", "Seleccione una Sección");
                    }

                    ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
                    ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
                    ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");

                    return View(nota);
                }

                //Validacion del año
                var anioActual = Convert.ToInt32((DateTime.Now).Year);
                if (nota.Anio != anioActual)
                {
                    ModelState.AddModelError("Anio", "Ingrese el año correcto");

                    ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
                    ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
                    ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");

                    return View(nota);
                }

                _notasBL.GuardarNota(nota);

                return RedirectToAction("Index");
            }

           // var alumnos = _alumnosBL.ObtenerAlumnosactivo();

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");

            return View(nota);
        }

        public ActionResult Editar(int id)
        {
            var nota = _notasBL.ObtenerNota(id);
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();
            var alumnos = _alumnosBL.ObtenerAlumnosactivo();

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion", nota.GradoId);
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion", nota.JornadaId);
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion", nota.SeccionId);

            return View(nota);
        }

        [HttpPost]
        public ActionResult Editar(Notas nota)
        {
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();
           

            if (ModelState.IsValid)
            {
                

                if (nota.GradoId == 0 || nota.JornadaId == 0)
                {
                    if (nota.GradoId == 0)
                    {
                        ModelState.AddModelError("Grado", "Seleccione un grado");
                    }

                    if (nota.JornadaId == 0)
                    {
                        ModelState.AddModelError("Jornada", "Seleccione una Jornada");
                    }

                    ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
                    ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
                    ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");

                    return View(nota);
                }

                _notasBL.GuardarNota(nota);

                return RedirectToAction("Index");
            }

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");
            return View(nota);
        }

        public ActionResult Detalle(int id)
        {
            var nota = _notasBL.ObtenerNota(id);

            return View(nota);
        }

    }
}
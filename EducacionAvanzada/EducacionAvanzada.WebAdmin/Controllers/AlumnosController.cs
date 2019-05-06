using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    [Authorize]
    public class AlumnosController : Controller
    {
        AlumnosBL _alumnosBL;
        GradosBL _gradosBL;
        JornadasBL _jornadasBL;
        seccionBL _seccionesBL;
        PadresBL _padresBL;

        public AlumnosController()
        {
            _alumnosBL = new AlumnosBL();
            _gradosBL = new GradosBL();
            _jornadasBL = new JornadasBL();
            _seccionesBL = new seccionBL();
            _padresBL = new PadresBL();
        }

        // GET: Alumnos
        public ActionResult Index()
        {
            var listadeAlumnos = _alumnosBL.ObtenerAlumnos();

            return View(listadeAlumnos);
        }

        public ActionResult Crear()
        {
            var nuevoAlumno = new Alumno();
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();
            var padres = _padresBL.ObtenerPadres();

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");
            ViewBag.PadreId = new SelectList(padres, "Id", "Nombre");

            return View(nuevoAlumno);
        }

        [HttpPost]
        public ActionResult Crear(Alumno alumno, HttpPostedFileBase imagen)
        {
            string Url = alumno.UrlImagen;

            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();



            if (ModelState.IsValid)
            {
                if (alumno.Nombre != alumno.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio o al final");
                    bolsaDeVista();
                    return View(alumno);
                }

                if (alumno.GradoId == 0 || alumno.JornadaId == 0 || alumno.SeccionId == 0)
                {
                    if (alumno.GradoId == 0)
                    {
                        ModelState.AddModelError("Grado", "Seleccione un grado");
                    }

                    if (alumno.JornadaId == 0)
                    {
                        ModelState.AddModelError("Jornada", "Seleccione una Jornada");
                    }

                    if (alumno.SeccionId == 0)
                    {
                        ModelState.AddModelError("seccion", "Seleccione una Sección");
                    }

                   // bolsaDeVista();
                    ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
                    ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
                    ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");


                    return View(alumno);
                }

                if (imagen != null)
                {
                    alumno.UrlImagen = GuardarImagen(imagen);
                }

                _alumnosBL.GuardarAlumno(alumno);

                return RedirectToAction("Index");
            }

            if (alumno.UrlImagen == null)
            {
                alumno.UrlImagen = Url;
            }

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");

            //bolsaDeVista();
            return View(alumno);
        }

        public void bolsaDeVista()
        {
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion");

        }

        public ActionResult Editar(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();
            var secciones = _seccionesBL.ObtenerSecciones();


            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion", alumno.GradoId);
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion", alumno.JornadaId);
            ViewBag.SeccionId = new SelectList(secciones, "Id", "Descripcion", alumno.SeccionId);


            return View(alumno);
        }

        [HttpPost]
        public ActionResult Editar(Alumno alumno, HttpPostedFileBase imagen)
        {
            string Url = alumno.UrlImagen;

            if (ModelState.IsValid)
            {
                if (alumno.Nombre != alumno.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio o al final");
                    bolsaDeVista();
                    return View(alumno);
                }

                if (alumno.GradoId == 0 || alumno.JornadaId == 0)
                {
                    if (alumno.GradoId == 0)
                    {
                        ModelState.AddModelError("Grado", "Seleccione un grado");
                    }

                    if (alumno.JornadaId == 0)
                    {
                        ModelState.AddModelError("Jornada", "Seleccione una Jornada");
                    }

                    bolsaDeVista();

                    return View(alumno);
                }

                if (imagen != null)
                {
                    alumno.UrlImagen = GuardarImagen(imagen);
                }

                _alumnosBL.GuardarAlumno(alumno);

                return RedirectToAction("Index");
            }

            if (alumno.UrlImagen == null)
            {
                alumno.UrlImagen = Url;
            }
            bolsaDeVista();
            return View(alumno);
        }

        public ActionResult Detalle(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);

            return View(alumno);
        }

        public ActionResult Eliminar(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Eliminar(Alumno alumno)
        {
            _alumnosBL.EliminarAlumno(alumno.Id);
            return RedirectToAction("Index");
        }

        public string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}
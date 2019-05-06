using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.Web.Controllers
{
    [Authorize]
    public class AlumnosController : Controller
    {
        AlumnosBL _alumnosBL;
        public AlumnosController()
        {
            _alumnosBL = new AlumnosBL();
        }
        // GET: Alumnos
        /*public ActionResult Index()
        {
            var alumnosBL = new AlumnosBL();
            var listaAlumno = alumnosBL.ObtenerAlumnos();

            return View(listaAlumno);
        }*/

        public ActionResult Index(int id)
        {
            var listadeAlumnos = _alumnosBL.ObtenerAlumnosPorPadre(id);
            ViewBag.Padre = id;
            ViewBag.adminWebsiteUrl =
                ConfigurationManager.AppSettings["adminWebsiteUrl"];

            //Notas.ListadeNotas = _notaBL.ObtenerNotasporAlumno(id);
            return View(listadeAlumnos);
        }
    }
}
using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.Web.Controllers
{
    [Authorize]
    public class NotasController : Controller
    {
        NotasBL _notaBL;
        AlumnosBL _alumnosBL;

        public NotasController()
        {
            _notaBL = new NotasBL();
            _alumnosBL = new AlumnosBL();
        }
        // GET: Notas

        public ActionResult Index(int id)
        {
            var Notas = _alumnosBL.ObtenerAlumno(id);
            Notas.ListadeNotas = _notaBL.ObtenerNotasporAlumno(id);
            ViewBag.Padre = Notas.PadreId;
            return View(Notas);
        }

        /*var nuevoAlumno = new Alumno();
        nuevoAlumno.Id = id;

        return View(nuevoAlumno); */




        /*[HttpPost]
        public ActionResult Index(Alumno alumno)
        {
            var notas = _notaBL.ObtenerNotasporAlumno(alumno);

            if (notas.Count > 0)
            {
                ViewBag.Alumnos = notas;
                
            }
            return View();
        }*/
    }
}
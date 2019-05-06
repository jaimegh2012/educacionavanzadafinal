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
    public class HomeController : Controller
    {
        AlumnosBL _alumnosBL;
        public HomeController()
        {
            _alumnosBL = new AlumnosBL();
        }
        // GET: Home
        

       
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
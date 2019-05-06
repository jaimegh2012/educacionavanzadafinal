
using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EducacionAvanzada.Web.Controllers
{
    public class LoginController : Controller
    {
        SeguridadBL _seguridadBL;
        AlumnosBL _alumnosBL;
        PadresBL _padresBL;
        public LoginController()
        {
            _seguridadBL = new SeguridadBL();
            _alumnosBL = new AlumnosBL();
            _padresBL = new PadresBL();
        }

        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            var nombreUsuario = data["username"];
            var contrasena = data["password"];

            var usuarioValido = _seguridadBL
                .AutorizarPadre(nombreUsuario, contrasena);

            
            var padreExistente = _padresBL.ObtenerPadre(nombreUsuario);

            if (usuarioValido)
            {
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);
                
                return RedirectToAction("Index", "Alumnos", new { id = padreExistente.Id });
                
            }

            ModelState.AddModelError("", "Usuario o contraseña invalido");

            return View();
        }
    }
}
using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    public class loginController : Controller
    {
        SeguridadBL _seguridad;
        public loginController ()
        {
            _seguridad = new SeguridadBL();
            
        }
        // GET: login
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

            var UsuarioValido = _seguridad.Autorizar(nombreUsuario, contrasena);

            if (UsuarioValido )
            {
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);
                return RedirectToAction("index", "Home");

            }
            ModelState.AddModelError("", "usuario o contraseña invalida");

            return View();
        }
    }
}
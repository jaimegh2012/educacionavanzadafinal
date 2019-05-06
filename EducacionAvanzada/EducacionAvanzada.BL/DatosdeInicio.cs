using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{

    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = "admin";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");

            contexto.Usuario.Add(nuevoUsuario);

            base.Seed(contexto);

            var nuevoUsuario1 = new Usuario();
            nuevoUsuario1.Nombre = "astrid";
            nuevoUsuario1.Contrasena = Encriptar.CodificarContrasena("2097");

            contexto.Usuario.Add(nuevoUsuario1);

            base.Seed(contexto);

            var nuevoUsuario2 = new Usuario();
            nuevoUsuario2.Nombre = "jaime";
            nuevoUsuario2.Contrasena = Encriptar.CodificarContrasena("567");

            contexto.Usuario.Add(nuevoUsuario2);
            base.Seed(contexto);

            var nuevoUsuario3 = new Usuario();
            nuevoUsuario3.Nombre = "carolina";
            nuevoUsuario3.Contrasena = Encriptar.CodificarContrasena("2019");

            contexto.Usuario.Add(nuevoUsuario3);

            base.Seed(contexto);

            var nuevoUsuario4 = new Usuario();
            nuevoUsuario4.Nombre = "anner";
            nuevoUsuario4.Contrasena = Encriptar.CodificarContrasena("2018");

            contexto.Usuario.Add(nuevoUsuario4);


            base.Seed(contexto);
        }
    }
}
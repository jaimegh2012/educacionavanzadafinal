using System.Collections.Generic;
using System.Linq;

namespace EducacionAvanzada.BL
{
    public class PadresBL
    {
        Contexto _contexto;

        public List<Padre> ListadePadres { get; set; }

        public PadresBL()
        {
            _contexto = new Contexto();
            ListadePadres = new List<Padre>();
        }

        public List<Padre> ObtenerPadres()
        {
            ListadePadres = _contexto.Padres.ToList();
            return ListadePadres;
        }

        public void GuardarPadre(Padre padre)
        {
            if (padre.Id == 0)
            {
                _contexto.Padres.Add(padre);
            }
            else
            {
                var padreExistente = _contexto.Padres.Find(padre.Id);
                padreExistente.Nombre = padre.Nombre;
                padreExistente.NombreUsuario = padre.NombreUsuario;
                padreExistente.Contrasena = Encriptar.CodificarContrasena(padre.Contrasena);
            }

            _contexto.SaveChanges();
        }

        public Padre ObtenerPadre(int id)
        {
            var padre = _contexto.Padres.Find(id);

            return padre;
        }

        //obtener padre por usuario
        public Padre ObtenerPadre(string usuario)
        {
            var padre = _contexto.Padres.FirstOrDefault(r => r.NombreUsuario == usuario);

            return padre;
        }

        public void EliminarPadre(int id)
        {
            var padre = _contexto.Padres.Find(id);

            _contexto.Padres.Remove(padre);
            _contexto.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class seccionBL
    {

        Contexto _contexto;
        public List<seccion> Listadesecciones { get; set; }

        public seccionBL()
        {
            _contexto = new Contexto();
            Listadesecciones = new List<seccion>();
        }

        public List<seccion> ObtenerSecciones()
        {
            Listadesecciones = _contexto.Seccion.ToList();

            return Listadesecciones;

        }

        public seccion ObtenerSecciones(int id)
        {
            var seccion = _contexto.Seccion.Find(id);

            return seccion;
        }

        public void GuardarSeccion(seccion seccion)
        {
            if (seccion.Id == 0)
            {
                _contexto.Seccion.Add(seccion);
            }
            else
            {
                var seccionExistente = _contexto.Seccion.Find(seccion.Id);
                seccionExistente.Descripcion = seccion.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public seccion ObtenerSeccion(int id)
        {
            var seccion = _contexto.Seccion.Find(id);

            return seccion;
        }

        public void EliminarSeccion(int id)
        {
            var seccion = _contexto.Seccion.Find(id);

            _contexto.Seccion.Remove(seccion);
            _contexto.SaveChanges();
        }
    }
}

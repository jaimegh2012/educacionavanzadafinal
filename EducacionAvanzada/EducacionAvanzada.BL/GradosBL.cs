using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class GradosBL
    {
        Contexto _contexto;

        public List<Grado> ListadeGrados { get; set; }

        public GradosBL()
        {
            _contexto = new Contexto();
            ListadeGrados = new List<Grado>();
        }

        public List<Grado> ObtenerGrados()
        {
            ListadeGrados = _contexto.Grados.ToList();
            return ListadeGrados;
        }

        public void GuardarGrado(Grado grado)
        {
            if (grado.Id == 0)
            {
                _contexto.Grados.Add(grado);
            }
            else
            {
                var gradoExistente = _contexto.Grados.Find(grado.Id);
                gradoExistente.Descripcion = grado.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Grado ObtenerGrado(int id)
        {
            var grado = _contexto.Grados.Find(id);

            return grado;
        }

        public void EliminarGrado(int id)
        {
            var grado = _contexto.Grados.Find(id);

            _contexto.Grados.Remove(grado);
            _contexto.SaveChanges();
        }
    }
}

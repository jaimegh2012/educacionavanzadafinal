using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class JornadasBL
    {
        Contexto _contexto;

        public List<Jornada> ListadeJornadas { get; set; }

        public JornadasBL()
        {
            _contexto = new Contexto();
            ListadeJornadas = new List<Jornada>();
        }

        public List<Jornada> ObtenerJornadas()
        {
            ListadeJornadas = _contexto.Jornadas.ToList();
            return ListadeJornadas;
        }

        public void GuardarJornada(Jornada jornada)
        {
            if (jornada.Id == 0)
            {
                _contexto.Jornadas.Add(jornada);
            }
            else
            {
                var jornadaExistente = _contexto.Jornadas.Find(jornada.Id);
                jornadaExistente.Descripcion = jornada.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Jornada ObtenerJornada(int id)
        {
            var jornada = _contexto.Jornadas.Find(id);

            return jornada;
        }

        public void EliminarJornada(int id)
        {
            var jornada = _contexto.Jornadas.Find(id);

            _contexto.Jornadas.Remove(jornada);
            _contexto.SaveChanges();
        }

    }
}

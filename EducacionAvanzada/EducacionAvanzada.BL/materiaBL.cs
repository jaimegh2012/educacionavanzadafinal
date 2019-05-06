using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class materiaBL
    {
        Contexto _contexto;
        public List<Materia> Listadematerias { get; set; }

        public materiaBL()
        {
            _contexto = new Contexto();
            Listadematerias = new List<Materia>();
        }
        public List<Materia> Obtenermaterias()
        {
            Listadematerias = _contexto.Materia.ToList();

            return Listadematerias;

        }


        public Materia ObtenerMaterias(int id)
        {
            var materia = _contexto.Materia.Find(id);

            return materia;
        }

        public void GuardarMateria(Materia materia)
        {
            if (materia.Id == 0)
            {
                _contexto.Materia.Add(materia);
            }
            else
            {
                var MateriaExistente = _contexto.Materia.Find(materia.Id);
                MateriaExistente.Descripcion = materia.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Materia ObtenerMateria(int id)
        {
            var materia = _contexto.Materia.Find(id);

            return materia;
        }

        public void EliminarMateria(int id)
        {
            var materia = _contexto.Materia.Find(id);

            _contexto.Materia.Remove(materia);
            _contexto.SaveChanges();
        }
    }
}



    


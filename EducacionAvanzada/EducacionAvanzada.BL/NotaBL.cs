using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class NotasBL
    {
        Contexto _contexto;
        public List<Notas> ListadeNotas { get; set; }

        public NotasBL()
        {
            _contexto = new Contexto();
            ListadeNotas = new List<Notas>();
         


        }
        public List<Notas> ObtenerNotas()
        {
            ListadeNotas = _contexto.Notas
                .Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .ToList();

            return ListadeNotas;
        }

        public List<NotasDetalle> ObtenerNotasDetalle(int notaId)
        {

            var listadeNotasDetalle = _contexto.NotasDetalle
                .Include("Alumno")
                .Include("Materia")
                .Where(n => n.NotaId == notaId).ToList();
            return listadeNotasDetalle;
        }

        public List<NotasDetalle> ObtenerNotasporAlumno(int alumnoId)
        {
            var listadeNotasporAlumno = _contexto.NotasDetalle
                .Include("Alumno")
                .Include("Materia")
                .Where(n => n.AlumnoId == alumnoId).ToList();
            return listadeNotasporAlumno;
        }
        /*public List<NotasDetalle> ObtenerNotasporAlumno(Alumno alumno)
        {
            var AlumnoExistente = _contexto.Alumnos
                .FirstOrDefault(r => r.Id == alumno.Id);
            AlumnoExistente.Id = alumno.Id;

            if (AlumnoExistente != null)
            {
                return _contexto.NotasDetalle.Include("Alumno").Include("materia")
                .Where(r => r.AlumnoId == AlumnoExistente.Id).ToList();
            }

            return new List<NotasDetalle>();
        }*/

        public NotasDetalle ObtenerNotasDetalleporId(int id)
        {
            var notadetalle = _contexto.NotasDetalle
                 .Include("Alumno").FirstOrDefault(p => p.Id == id);

            return notadetalle;
        }


        public void GuardarNota(Notas nota)
        {
            if (nota.Id == 0)
            {
                _contexto.Notas.Add(nota);
            }
            else
            {
                var notaExistente = _contexto.Notas.Find(nota.Id);
                notaExistente.GradoId = nota.GradoId;
                notaExistente.JornadaId = nota.JornadaId;
                notaExistente.SeccionId = nota.SeccionId;
                notaExistente.Anio = nota.Anio;
            }

            _contexto.SaveChanges();
        }

        public Notas ObtenerNota(int id)
        {
            var nota = _contexto.Notas
                .Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .FirstOrDefault(p => p.Id == id);

            return nota;
        }

        public void GuardarNotasDetalle(NotasDetalle notasDetalle, bool editar = false)
        {
            
            var alumno = _contexto.Notas.Find(notasDetalle.AlumnoId);
     
            notasDetalle.NotaFinal = ((notasDetalle.PrimerParcial + notasDetalle.SegundoParcial + notasDetalle.TercerParcial + notasDetalle.CuartoParcial) / 4);


            if (editar == false)
            {
                _contexto.NotasDetalle.Add(notasDetalle);

            }
            else
            {
                var notaDetalleExistente = _contexto.NotasDetalle.Find(notasDetalle.Id);

                notaDetalleExistente.AlumnoId = notasDetalle.AlumnoId;
                notaDetalleExistente.MateriaId = notasDetalle.MateriaId;
                notaDetalleExistente.PrimerParcial = notasDetalle.PrimerParcial;
                notaDetalleExistente.SegundoParcial = notasDetalle.SegundoParcial;
                notaDetalleExistente.TercerParcial = notasDetalle.TercerParcial;
                notaDetalleExistente.CuartoParcial = notasDetalle.CuartoParcial;
                notaDetalleExistente.NotaFinal = notasDetalle.NotaFinal;
            }

            var nota = _contexto.Notas.Find(notasDetalle.NotaId);
            nota.NotaFinal = nota.NotaFinal + notasDetalle.NotaFinal;
            _contexto.SaveChanges();
        }

        public void EliminarNotaDetalle(int id)
        {
            var notaDetalle = _contexto.NotasDetalle.Find(id);
            _contexto.NotasDetalle.Remove(notaDetalle);

            var nota = _contexto.Notas.Find(notaDetalle.NotaId);
            nota.NotaFinal = nota.NotaFinal - notaDetalle.NotaFinal;

            _contexto.SaveChanges();
        }

    }
}

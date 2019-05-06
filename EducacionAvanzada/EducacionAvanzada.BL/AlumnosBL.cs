using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class AlumnosBL
    {
        Contexto _contexto;

        public List<Alumno> ListadeAlumnos { get; set; }

        public AlumnosBL()
        {
            _contexto = new Contexto();
            ListadeAlumnos = new List<Alumno>();
        }

        public List<Alumno> ObtenerAlumnos()
        {
            ListadeAlumnos = _contexto.Alumnos
                .Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .OrderBy(a=>a.Nombre)
                .ToList();

            return ListadeAlumnos;
        }
        public List<Alumno> ObtenerAlumnosactivo()
        {
            ListadeAlumnos = _contexto.Alumnos
                .Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .Where(a => a.activo == true)
                .OrderBy(a => a.Nombre)
                .ToList();

            return ListadeAlumnos;
        }


        public void GuardarAlumno(Alumno alumno)
        {
            if (alumno.Id == 0)
            {
                _contexto.Alumnos.Add(alumno);
            }
            else
            {
                var alumnoExistente = _contexto.Alumnos.Find(alumno.Id);
                alumnoExistente.Nombre = alumno.Nombre;
                alumnoExistente.GradoId = alumno.GradoId;
                alumnoExistente.JornadaId = alumno.JornadaId;
                alumnoExistente.SeccionId = alumno.SeccionId;
                alumnoExistente.activo = alumno.activo;
                if (alumno.UrlImagen != null)
                {
                    alumnoExistente.UrlImagen = alumno.UrlImagen;

                }

            }

            _contexto.SaveChanges();
        }

        public Alumno ObtenerAlumno(int id)
        {
            //var alumno = _contexto.Alumnos.Find(id);

            var alumno = _contexto.Alumnos
                .Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .FirstOrDefault(p => p.Id == id);

            return alumno;
        }

        public void EliminarAlumno(int id)
        {
            var alumno = _contexto.Alumnos.Find(id);
            
            _contexto.Alumnos.Remove(alumno);
            _contexto.SaveChanges();
        }


        public List<Alumno> ObtenerAlumnosPorPadre(Padre padre)
        {

            var padreExistente = _contexto.Padres
                .FirstOrDefault(r => r.NombreUsuario == padre.NombreUsuario
                && r.Contrasena == padre.Contrasena);

            if (padreExistente != null)
            {
                return _contexto.Alumnos.Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .Where(r => r.PadreId == padreExistente.Id).ToList();
            }

            return new List<Alumno>();
        }

        public List<Alumno> ObtenerAlumnosPorPadre(int padreId)
        {
            var listadeAlum = _contexto.Alumnos
                .Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .Where(n => n.PadreId == padreId).ToList();
            return listadeAlum;
        }

        //probando coleccion
        public List<Alumno> ObtenerAlumnosPorPadre(string NombreUsuario, string Contrasena)
        {

            var padreExistente = _contexto.Padres
                .FirstOrDefault(r => r.NombreUsuario == NombreUsuario
                && r.Contrasena == Contrasena);

            if (padreExistente != null)
            {
                return _contexto.Alumnos.Include("Grado")
                .Include("Jornada")
                .Include("Seccion")
                .Where(r => r.PadreId == padreExistente.Id).ToList();
            }

            return new List<Alumno>();
        }
    }

    
}

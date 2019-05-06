using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class Notas
    {
        public int Id { get; set; }

        public int GradoId { get; set; }
        public Grado Grado { get; set; }

        public int JornadaId { get; set; }
        public Jornada Jornada { get; set; }

        public int PrimerParcial { get; set; }
        public int SegundoParcial { get; set; }
        public int TercerParcial { get; set; }
        public int CuartoParcial { get; set; }

        public int NotaFinal { get; set; }

        public int SeccionId { get; set; }
        [Display(Name = "Sección")]
        public seccion seccion { get; set; }

        [Required(ErrorMessage = "Ingrese el año")]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        public List<NotasDetalle> ListadeNotasDetalle { get; set; }

        public Notas()
        {
            ListadeNotasDetalle = new List<NotasDetalle>();
            GradoId = 0;
            JornadaId = 0;
            SeccionId = 0;
            Anio = Convert.ToInt32((DateTime.Now).Year);
        }
    }

    public class NotasDetalle
    {
        internal readonly object alumno;

        public int Id { get; set; }

        public int NotaId { get; set; }
        public Notas Notas { get; set; }

        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }

        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        public int PrimerParcial { get; set; }
        public int SegundoParcial { get; set; }
        public int TercerParcial { get; set; }
        public int CuartoParcial { get; set; }
        public int NotaFinal { get; set; }
    }
}

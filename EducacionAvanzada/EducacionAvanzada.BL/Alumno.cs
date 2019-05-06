using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class Alumno
    {
        public Alumno()
        {

            activo = true;
            ListadeNotas = new List<NotasDetalle>();
        }
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre")]
        [MinLength(3, ErrorMessage = "Ingrese mínimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Ingrese máximo 40 caracteres")]
        public string Nombre { get; set; }

        public int GradoId { get; set; }
        public Grado Grado { get; set; }
        public int JornadaId { get; set; }
        public Jornada Jornada { get; set; }
        public bool activo { get; set; }


        public int PrimerParcial { get; set; }
        public int SegundoParcial { get; set; }
        public int TercerParcial { get; set; }
        public int CuartoParcial { get; set; }
        public int NotaFinal { get; set; }

        public int SeccionId { get; set; }
        [Display(Name = "Sección")]
        public seccion seccion { get; set; }

        [Display (Name= "Imagen")]
        public string UrlImagen { get; set; }


        public int PadreId { get; set; }
        public Padre Padre { get; set; }

        public List<NotasDetalle> ListadeNotas { get; set; }







    }
}

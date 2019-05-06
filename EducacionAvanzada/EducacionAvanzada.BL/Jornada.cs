using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class Jornada
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese una Jornada")]
        public string Descripcion { get; set; }
    }
}

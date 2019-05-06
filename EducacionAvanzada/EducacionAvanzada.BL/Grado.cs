using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class Grado
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el grado")]
        public string Descripcion { get; set; }


    }
}

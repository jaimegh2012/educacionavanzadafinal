using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class seccion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la Descripción")]
        public string Descripcion { get; set; }
    }

}
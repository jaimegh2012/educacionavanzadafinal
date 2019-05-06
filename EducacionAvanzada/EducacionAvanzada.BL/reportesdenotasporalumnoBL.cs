using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{

    public class reportesdenotasporalumnoBL
    {
        Contexto _contexto;
        public List<Reportesdenotasporalumno> listadealumnosporgrado { get; set; }
        public reportesdenotasporalumnoBL()
        {
            _contexto = new Contexto();
            listadealumnosporgrado = new List<Reportesdenotasporalumno>();

        }

        public List<Reportesdenotasporalumno> obteneralumnosporgrado()
        {
            listadealumnosporgrado = _contexto.NotasDetalle
                    .Include("Alumno")
                    .Where(r => r.Alumno.activo)
                    .GroupBy(r => r.Alumno.Nombre)
                    .Select(r=>new Reportesdenotasporalumno() {
                        alumno = r.Key,
                        PrimerParcial = r.Sum(s => s.PrimerParcial),
                        SegundoParcial= r.Sum(s => s.SegundoParcial),
                      TercerParcial = r.Sum(s => s.TercerParcial),
                     CuartoParcial = r.Sum(s => s.CuartoParcial),
                        NotaFinal = r.Sum(p => p.NotaFinal)


                    }).ToList();
            return listadealumnosporgrado;
        }
    }
}

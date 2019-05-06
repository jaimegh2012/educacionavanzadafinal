using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducacionAvanzada.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var alumnosBL = new AlumnosBL();
            var listadeAlumnos = alumnosBL.ObtenerAlumnos();
            InitializeComponent();

            listadeAlumnosBindingSource.DataSource = listadeAlumnos;
        }

        private void listadeAlumnosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

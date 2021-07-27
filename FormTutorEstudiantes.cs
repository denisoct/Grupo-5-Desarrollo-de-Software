using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFix
{
    public partial class FormTutorEstudiantes : Form
    {

        public FormTutorEstudiantes(string Semestre, string CodigoTutor)
        {
            InitializeComponent();
            dsTutoriasTableAdapters.FichaTutoriasTableAdapter ta = new dsTutoriasTableAdapters.FichaTutoriasTableAdapter();
            dsTutorias.FichaTutoriasDataTable dt = ta.GetEstudiantesByCodDocente(Semestre, CodigoTutor);
            dataGridView1.DataSource = dt;
            labelMensaje.Text = "Lista de Docentes. Total registros: " + dt.Rows.Count.ToString();
        }
    }
}

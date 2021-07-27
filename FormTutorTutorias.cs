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
    public partial class FormTutorTutorias : Form
    {
        string CodigoTutor;

        public FormTutorTutorias(string CodigoTutor)
        {
            this.CodigoTutor = CodigoTutor;
            InitializeComponent();
            labelMensaje.Text = "";
        }

        private void buttonVerTutorias_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.FichaTutoriasTableAdapter ta = new dsTutoriasTableAdapters.FichaTutoriasTableAdapter();
            dsTutorias.FichaTutoriasDataTable dt = ta.BuscarSemestre(txtSemestre.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.Text = "Semestre no válido";
            }
            else
            {
                dsTutorias.FichaTutoriasDataTable dtt = ta.GetDataByDocente(CodigoTutor, txtSemestre.Text);
                dataGridView1.DataSource = dtt;
                labelMensaje.Text = "Fichas de Tutoria. Semestre: " + txtSemestre.Text + " Total registros: " + dt.Rows.Count.ToString();
            }
        }
    }
}

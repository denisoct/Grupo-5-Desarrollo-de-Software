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
    public partial class FormCoordBuscarFichaTutoria : Form
    {
        public FormCoordBuscarFichaTutoria()
        {
            InitializeComponent();
            labelMensaje.Text = "";
        }

        private void buttonBuscarFichaTutoria_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.TutorTableAdapter ta = new dsTutoriasTableAdapters.TutorTableAdapter();
            dsTutorias.TutorDataTable dt = ta.BuscarTutor(txtCodigoDocente.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.Text = "El código del tutor no existe";
            }
            else
            {
                dsTutoriasTableAdapters.FichaTutoriasTableAdapter tat = new dsTutoriasTableAdapters.FichaTutoriasTableAdapter();
                dsTutorias.FichaTutoriasDataTable dtt = tat.BuscarSemestre(txtSemestre.Text);
                if (dtt.Rows.Count == 0)
                {
                    labelMensaje.Text = "Semestre no válido";
                }
                else
                {
                    dtt = tat.GetDataByCodDocente(txtCodigoDocente.Text, txtSemestre.Text);
                    dataGridView1.DataSource = dtt;
                    labelMensaje.Text = "Fichas de Tutoria. Docente: " + txtCodigoDocente.Text + " Semestre: " + txtSemestre.Text + " Total registros: " + dt.Rows.Count.ToString(); ;
                }
            }
        }
    }
}

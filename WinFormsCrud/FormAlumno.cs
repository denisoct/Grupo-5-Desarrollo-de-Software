using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCrud
{
    public partial class FormAlumno : Form
    {
        public FormAlumno()
        {
            InitializeComponent();
        }

        // Buscar:
        private void button2_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.AlumnoTableAdapter ta = new dsTutoriasTableAdapters.AlumnoTableAdapter();
            dsTutorias.AlumnoDataTable dt = ta.GetDataByCodAlumno(txtCodigo.Text);
            if (dt.Rows.Count == 0)
            {
                lblInfo.Text = "El código no existe";
            }
            else
            {
                dsTutorias.AlumnoRow row = (dsTutorias.AlumnoRow)dt.Rows[0];
                txtNombres.Text = row.Nombres;
                txtApellidos.Text = row.Apellidos;
                comboBoxEP.Text = row.CodEP;
            }
        }

        // Agregar
        private void button1_Click_1(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.AlumnoTableAdapter ta = new dsTutoriasTableAdapters.AlumnoTableAdapter();
            dsTutorias.AlumnoDataTable dt = ta.GetDataByCodAlumno(txtCodigo.Text);
            if (dt.Rows.Count != 0)
            {
                lblInfo.Text = "El código ya existe.";
            }
            else
            {
                int indice = comboBoxEP.SelectedIndex;
                if (indice == -1)
                {
                    indice = 0;
                }
                string escuela_profesional = (string)comboBoxEP.Items[indice];
                ta.Insertar(txtCodigo.Text.Trim(), txtNombres.Text.Trim().ToUpper(), txtApellidos.Text.Trim().ToUpper(), escuela_profesional);
            }
        }

        // Modificar:
        private void button3_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.AlumnoTableAdapter ta = new dsTutoriasTableAdapters.AlumnoTableAdapter();
            dsTutorias.AlumnoDataTable dt = ta.GetDataByCodAlumno(txtCodigo.Text);
            int indice = comboBoxEP.SelectedIndex;
            if (indice == -1)
            {
                indice = 0;
            }
            string carrera_profesional = (string)comboBoxEP.Items[indice];
            ta.Modificar(txtNombres.Text.Trim().ToUpper(), txtApellidos.Text.Trim().ToUpper(), carrera_profesional, txtCodigo.Text.Trim());
        }


        // Eliminar:
        private void button4_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.AlumnoTableAdapter ta = new dsTutoriasTableAdapters.AlumnoTableAdapter();
            dsTutorias.AlumnoDataTable dt = ta.GetDataByCodAlumno(txtCodigo.Text);
            if (dt.Rows.Count == 0)
            {
                lblInfo.Text = "El código no existe.";
            }
            else
            {
                ta.Eliminar(txtCodigo.Text);
            }
        }

        // Salir:
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNuevo_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxGrados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

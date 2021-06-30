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
    public partial class FormEscuelaProfesional : Form
    {
        public FormEscuelaProfesional()
        {
            InitializeComponent();
        }

        // Buscar:
        private void button2_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter ta = new dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter();
            dsTutorias.EscuelaProfesionalDataTable dt = ta.GetDataByCodEP(txtCodigo.Text);
            if (dt.Rows.Count == 0)
            {
                lblInfo.Text = "El código no existe";
            }
            else
            {
                dsTutorias.EscuelaProfesionalRow row = (dsTutorias.EscuelaProfesionalRow)dt.Rows[0];
                txtNombre.Text = row.Nombre;
            }
        }

        // Agregar
        private void button1_Click_1(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter ta = new dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter();
            dsTutorias.EscuelaProfesionalDataTable dt = ta.GetDataByCodEP(txtCodigo.Text);
            if (dt.Rows.Count != 0)
            {
                lblInfo.Text = "El código ya existe.";
            }
            else
            {
                   ta.Insert(txtCodigo.Text.Trim().ToString(), txtNombre.Text.Trim().ToUpper().ToString());
            }
        }

        // Modificar:
        private void button3_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter ta = new dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter();
            dsTutorias.EscuelaProfesionalDataTable dt = ta.GetDataByCodEP(txtCodigo.Text);
            ta.Modificar(txtNombre.Text.Trim().ToUpper(), txtCodigo.Text.Trim());
        }


        // Eliminar:
        private void button4_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter ta = new dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter();
            dsTutorias.EscuelaProfesionalDataTable dt = ta.GetDataByCodEP(txtCodigo.Text);
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

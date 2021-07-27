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
    public partial class FormTutor : Form
    {
        string CodTutor;
        string Semestre = "2021-II";

        public FormTutor(string CodDocente)
        {
            InitializeComponent();
            CodTutor = CodDocente;
            FillPersonalData(CodDocente);
        }

        public void FillPersonalData(string CodDocente)
        {
            dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
            dsTutorias.DocenteDataTable dt = ta.GetDataByCodDocente(CodDocente);
            dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dt[0];
            labelCodigoDocente.Text = row.CodDocente;
            labelNombresDocente.Text = row.Nombres;
            labelEPDocente.Text = row.CodEP;
            labelTipoContratoDocente.Text = row.TipoContrato;
            if (row.TipoContrato == "NOMBRADO")
                labelCategoriaRegimenDocente.Text = row.Categoria + " - " + row.Regimen;
            else
                labelCategoriaRegimenDocente.Text = row.Tipo;
            labelEmailDocente.Text = row.Email;
            labelDireccionDocente.Text = row.Dirección;
            labelCelularDocente.Text = row.Celular;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Actualizar datos:
        private void buttonActualizarDatos_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorActualizarDatos());
        }

        // Ver tutorias:
        private void buttonVerTutorias_Click_1(object sender, EventArgs e)
        {
            openChildForm(new FormTutorTutorias(CodTutor));
        }

        // Crear ficha tutoria:
        private void buttonCrearFichaTutoria_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorCrearFicha(labelCodigoDocente.Text, labelNombresDocente.Text + labelApellidosDocente.Text));
        }

        // Lista Estudiantes:
        private void buttonListaEstudiantes_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorEstudiantes(Semestre, CodTutor));
        }

        // Buscar estudiante:
        private void buttonBuscarEstudiante_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTutorBuscarEstudiante());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            activeForm.Close();
            groupBoxDatosPersonales.BringToFront();
            groupBoxDatosPersonales.Show();
        }
    }
}

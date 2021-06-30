using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsCrud
{
    public partial class FormDocenteTutor : Form
    {
        public FormDocenteTutor()
        {
            InitializeComponent();

            dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter ta_ep = new dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter();
            dsTutorias.EscuelaProfesionalDataTable dt_ep = ta_ep.GetData();
            for (int i = 0; i < dt_ep.Count; i++)
            {
                dsTutorias.EscuelaProfesionalRow row_ep = (dsTutorias.EscuelaProfesionalRow)dt_ep.Rows[i];
                comboBoxEP.Items.Add(row_ep.Nombre);
            }

            if (txtCodigo.Text == "") lblInfo.Text = "";
        }

        // Buscar:
        private void button2_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.TutorTableAdapter ta = new dsTutoriasTableAdapters.TutorTableAdapter();
            dsTutorias.TutorDataTable dt = ta.GetDataByCodTutor(txtCodigo.Text);
            if (dt.Rows.Count == 0)
            {
                lblInfo.Text = "El código no existe";
            }
            else
            {
                dsTutorias.TutorRow row = (dsTutorias.TutorRow)dt.Rows[0];
                txtNombres.Text = row.Nombres;
                txtApellidos.Text = row.Apellidos;
                dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter ta_ep = new dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter();
                dsTutorias.EscuelaProfesionalDataTable dt_ep = ta_ep.GetDataByCodEP(row.CodEP);
                dsTutorias.EscuelaProfesionalRow row_ep = (dsTutorias.EscuelaProfesionalRow)dt_ep.Rows[0];
                comboBoxEP.Text = row_ep.Nombre;
            }
        }

        // Agregar
        private void button1_Click_1(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.TutorTableAdapter ta = new dsTutoriasTableAdapters.TutorTableAdapter();
            dsTutorias.TutorDataTable dt = ta.GetDataByCodTutor(txtCodigo.Text);
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

                string aux = "";
                SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = DBTutorias; Integrated Security = True");
                dt.CodEPColumn.MaxLength = 100;
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("select CodEP from EscuelaProfesional where Nombre = @nombre", con);
                    command.Parameters.AddWithValue("nombre", escuela_profesional);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    aux = datatable.Rows[0][0].ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }

                ta.Insertar(txtCodigo.Text.Trim(), txtNombres.Text.Trim().ToUpper(), txtApellidos.Text.Trim().ToUpper(), aux);
            }
        }

        // Modificar:
        private void button3_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.TutorTableAdapter ta = new dsTutoriasTableAdapters.TutorTableAdapter();
            dsTutorias.TutorDataTable dt = ta.GetDataByCodTutor(txtCodigo.Text);
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
            dsTutoriasTableAdapters.TutorTableAdapter ta = new dsTutoriasTableAdapters.TutorTableAdapter();
            dsTutorias.TutorDataTable dt = ta.GetDataByCodTutor(txtCodigo.Text);
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

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                lblInfo.Text = "";
            }
                
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                lblInfo.Text = "";
        }
    }
}

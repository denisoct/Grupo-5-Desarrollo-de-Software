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
    public partial class FormCoordTablas : Form
    {
        public FormCoordTablas()
        {
            InitializeComponent();
        }

        public void VerData(int opt, string CodEP)
        {
            if (opt == 1)
            {
                labelTitulo.Text = "DOCENTES";
                dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
                dsTutorias.DocenteDataTable dt = ta.GetData();
                dataGridView1.DataSource = dt;
                labelMensaje.Text = "Lista de Docentes. Total registros: " + dt.Rows.Count.ToString();
            }
            if (opt == 2)
            {               
                labelTitulo.Text = "TUTORES";
                dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
                dsTutorias.DocenteDataTable dt = ta.GetTutoresByCodEP(CodEP);
                dataGridView1.DataSource = dt;
                labelMensaje.Text = "Lista de Tutores. Total registros: " + dt.Rows.Count.ToString();
            }
            if (opt == 3)
            {
                labelTitulo.Text = "ESTUDIANTES";
                dsTutoriasTableAdapters.EstudianteTableAdapter ta = new dsTutoriasTableAdapters.EstudianteTableAdapter();
                dsTutorias.EstudianteDataTable dt = ta.GetData();
                dataGridView1.DataSource = dt;
                labelMensaje.Text = "Lista de Estudiantes. Total registros: " + dt.Rows.Count.ToString();
            }
            if (opt == 4)
            {
                labelTitulo.Text = "ESTUDIANTES EN RIESGO ACADÉMICO";
                dsTutoriasTableAdapters.RiesgoAcademicoTableAdapter ta = new dsTutoriasTableAdapters.RiesgoAcademicoTableAdapter();
                dsTutorias.RiesgoAcademicoDataTable dt = ta.GetData(CodEP);
                dataGridView1.DataSource = dt;
                labelMensaje.Text = "Lista de Estudiantes en riesgo académico. Total registros: " + dt.Rows.Count.ToString();
            }
        }
    }
}

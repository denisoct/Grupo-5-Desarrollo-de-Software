using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsFix.dsTutoriasTableAdapters;

namespace WinFormsFix
{
    public partial class FormTutorCrearFicha : Form
    {
        private FichaTutoriasTableAdapter taFichasTutorias = new FichaTutoriasTableAdapter();
        private dsTutorias.FichaTutoriasDataTable dtFichasTutorias = new dsTutorias.FichaTutoriasDataTable();

        public FormTutorCrearFicha(string CodDocente, string NombresyApellidos)
        {
            InitializeComponent();
            labelNombresTutor.Text = NombresyApellidos;
        }

        private void buttonCrearFicha_Click(object sender, EventArgs e)
        {
            taFichasTutorias.Insertar(textBoxSemestre.Text,
                                        textBoxFecha.Text,
                                        textBoxHorario.Text,
                                        textBoxLugar.Text,
                                        textBoxActividad.Text,
                                        textBoxCodEstudiante.Text,
                                        textBoxCodEstudiante.Text,
                                        textBoxReferencia.Text,
                                        textBoxDescripción.Text);
            labellMensaje.Text = "Se agregó con éxito";
        }
    }
}

// DateTime.ParseExact(textBoxFecha.Text, "u", null),
                                        //TimeSpan.ParseExact(textBoxHorario.Text, "T", null),
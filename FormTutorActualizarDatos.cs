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
    public partial class FormTutorActualizarDatos : Form
    {
        private DocenteTableAdapter taDocente = new DocenteTableAdapter();
        private dsTutorias.DocenteDataTable dtDocente = new dsTutorias.DocenteDataTable();

        public FormTutorActualizarDatos(string CodDocente)
        {
            InitializeComponent();
            labelMensaje.Text = "";
            dtDocente = taDocente.GetDataByCodDocente(CodDocente);
            dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dtDocente.Rows[0];
            labelCodigoTutor.Text = CodDocente;
            labelNombresTutor.Text = row.Nombres;
            labelApellidosTutor.Text = row.Apellidos;
            labelEscuelaProfesiona.Text = "INGENIERIA INFORMÁTICA Y DE SISTEMAS";
            labelTipoContrato.Text = row.TipoContrato;
            textBoxEmailDocente.Text = row.Email;
            textBoxDireccionDocente.Text = row.Dirección;
            textBoxCelularDocente.Text = row.Celular;
            if (row.TipoContrato == "NOMBRADO")
            {
                if (row.Categoria == "PR" && row.Regimen == "DE")
                {
                    labelCatRegTipo.Text = "PRINCIPAL - DEDICACIÓN EXCLUSIVA";
                }
                if (row.Categoria == "PR" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "PRINCIPAL - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AS" && row.Regimen == "DE")
                {
                    labelCatRegTipo.Text = "ASOCIADO - DEDICACIÓN EXCLUSIVA";
                }
                if (row.Categoria == "AS" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "ASOCIADO - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AS" && row.Regimen == "TP")
                {
                    labelCatRegTipo.Text = "ASOCIADO - TIEMPO PARCIAL";
                }
                if (row.Categoria == "AU" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "AUXILIAR - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AU" && row.Regimen == "TP")
                {
                    labelCatRegTipo.Text = "AUXILIAR - TIEMPO PARCIAL";
                }
            }
            if (row.TipoContrato == "CONTRATADO")
            {
                labelCatRegTipo.Text = row.Tipo;
            }
        }

        private void buttonActualizarTutor_Click(object sender, EventArgs e)
        {
            labelMensaje.Text = "";
            dtDocente = taDocente.GetDataByCodDocente(labelCodigoTutor.Text);
            dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dtDocente.Rows[0];
            string Tipo = null;
            if (row.TipoContrato == "CONTRATADO") Tipo = row.Tipo;

            taDocente.Modificar(labelNombresTutor.Text,
                                labelApellidosTutor.Text,
                                "IN",
                                labelTipoContrato.Text,
                                row.Categoria,
                                row.Regimen,
                                Tipo,
                                textBoxEmailDocente.Text,
                                textBoxDireccionDocente.Text,
                                textBoxCelularDocente.Text,
                                labelCodigoTutor.Text) ;

            labelMensaje.Text = "Se modificó el registro";
        }
    }
}

﻿using System;
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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Refrescar()
        {
            int indice = comboBoxTablas.SelectedIndex;

            if (indice == 0) // Form Docente Tutor
            {
                dsTutoriasTableAdapters.TutorTableAdapter ta = new dsTutoriasTableAdapters.TutorTableAdapter();
                dsTutorias.TutorDataTable dt = ta.GetData();
                dataGridView1.DataSource = dt;
            }
            if (indice == 1) // Form Alumno
            {
                dsTutoriasTableAdapters.AlumnoTableAdapter ta = new dsTutoriasTableAdapters.AlumnoTableAdapter();
                dsTutorias.AlumnoDataTable dt = ta.GetData();
                dataGridView1.DataSource = dt;
            }
            if (indice == 2) // Form Escuela Profesional 
            {
                dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter ta = new dsTutoriasTableAdapters.EscuelaProfesionalTableAdapter();
                dsTutorias.EscuelaProfesionalDataTable dt = ta.GetData();
                dataGridView1.DataSource = dt;
            }
        }

        // Actualizar datos:
        private void button1_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        // Acceder:
        private void button2_Click_1(object sender, EventArgs e)
        {
            int indice = comboBoxTablas.SelectedIndex;

            if (indice == 0) // Form Docente Tutor
            {
                FormDocenteTutor form = new FormDocenteTutor();
                form.ShowDialog();
            }
            if (indice == 1) // Form Alumno
            {
                FormAlumno form = new FormAlumno();
                form.ShowDialog();
            }
            if (indice == 2) // Form Escuela Profesional 
            {
                FormEscuelaProfesional form = new FormEscuelaProfesional();
                form.ShowDialog();
            }
            Refrescar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
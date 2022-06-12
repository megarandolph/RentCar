using RentCar.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Views
{
    public partial class FTipoPersona : Form
    {
        public FTipoPersona()
        {
            InitializeComponent();
        }
        CTipoPersona cTipoPersona = new CTipoPersona();
        TipoPersona TipoPersona = new TipoPersona();
        private int TipoPersonaId;

        private void CargarGrid()
        {
            var lista = cTipoPersona.Get();
            dataGridView1.DataSource = lista;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void CargarDatos()
        {
            TipoPersona.Descripcion = textBox1.Text;
            TipoPersona.TipoPersonaId = TipoPersonaId;
        }
        private void limpiar()
        {
            TipoPersonaId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            CargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cTipoPersona.Create(TipoPersona);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TipoPersonaId > 0)
            {
                CargarDatos();
                cTipoPersona.Update(TipoPersona);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TipoPersonaId > 0)
            {
                cTipoPersona.Delete(TipoPersonaId);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CargarGrid();
            limpiar();
        }

        private void FTipoPersona_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            TipoPersonaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TipoPersonaId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

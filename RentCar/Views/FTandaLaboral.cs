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
    public partial class FTandaLaboral : Form
    {
        public FTandaLaboral()
        {
            InitializeComponent();
        }
        CTandaLaboral cTandaLaboral = new CTandaLaboral();
        TandaLaboral TandaLaboral = new TandaLaboral();
        private int TandaLaboralId;

        private void CargarGrid()
        {
            var lista = cTandaLaboral.Get();
            dataGridView1.DataSource = lista;
        }
        private void FTandaLaboral_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
        private void CargarDatos()
        {
            TandaLaboral.Descripcion = textBox1.Text;
            TandaLaboral.TandaLaboralId = TandaLaboralId;
        }
        private void limpiar()
        {
            TandaLaboralId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            CargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cTandaLaboral.Create(TandaLaboral);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TandaLaboralId > 0)
            {
                CargarDatos();
                cTandaLaboral.Update(TandaLaboral);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TandaLaboralId > 0)
            {
                cTandaLaboral.Delete(TandaLaboralId);
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            TandaLaboralId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TandaLaboralId"].Value.ToString());
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

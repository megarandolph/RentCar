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
    public partial class FCantidadCombustible : Form
    {
        public FCantidadCombustible()
        {
            InitializeComponent();
        }
        CCantidadCombustible cCantidadCombustible = new CCantidadCombustible();
        CantidadCombustible CantidadCombustible = new CantidadCombustible();
        private int CantidadCombustibleId;

        private void CargarGrid()
        {
            var lista = cCantidadCombustible.Get();
            dataGridView1.DataSource = lista;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FCantidadCombustible_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
        private void CargarDatos()
        {
            CantidadCombustible.Descripcion = textBox1.Text;
            CantidadCombustible.CantidadCombustibleId = CantidadCombustibleId;
        }
        private void limpiar()
        {
            CantidadCombustibleId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            CargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cCantidadCombustible.Create(CantidadCombustible);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CantidadCombustibleId > 0)
            {
                CargarDatos();
                cCantidadCombustible.Update(CantidadCombustible);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CantidadCombustibleId > 0)
            {
                cCantidadCombustible.Delete(CantidadCombustibleId);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CargarDatos();
            limpiar();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            CantidadCombustibleId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CantidadCombustibleId"].Value.ToString());
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

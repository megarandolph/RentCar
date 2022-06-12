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
    public partial class FMarca : Form
    {
        public FMarca()
        {
            InitializeComponent();
        }
        CMarca cMarca = new CMarca();
        Marca Marca = new Marca();
        private int MarcaId;

        private void CargarGrid()
        {
            var lista = cMarca.Get();
            dataGridView1.DataSource = lista;
        }

        private void FMarca_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarDatos()
        {
            Marca.Descripcion = textBox1.Text;
            Marca.MarcaId = MarcaId;
        }
        private void limpiar()
        {
            MarcaId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            CargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cMarca.Create(Marca);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MarcaId > 0)
            {
                CargarDatos();
                cMarca.Update(Marca);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MarcaId > 0)
            {
                cMarca.Delete(MarcaId);
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
            MarcaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MarcaId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

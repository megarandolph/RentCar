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
    public partial class FModelo : Form
    {
        public FModelo()
        {
            InitializeComponent();
        }
        CModelo cModelo = new CModelo();
        CMarca cMarca = new CMarca();
        Modelo Modelo = new Modelo();
        private int ModeloId;

        private void CargarGrid()
        {
            var lista = cModelo.Get();
            dataGridView1.DataSource = lista;
        }
        private void FModelo_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillMarca();

        }
        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        private void CargarDatos()
        {
           Modelo.Descripcion = textBox1.Text;
            Modelo.ModeloId = ModeloId;
           Modelo.MarcaId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
        }
        private void limpiar()
        {
            ModeloId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            comboBox1.SelectedValue = 0;
            CargarGrid();
            FillMarca();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cModelo.Create(Modelo);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ModeloId > 0)
            {
                CargarDatos();
                cModelo.Update(Modelo);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ModeloId > 0)
            {
                cModelo.Delete(ModeloId);
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
            FillMarca();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ModeloId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ModeloId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MarcaId"].Value.ToString());
        }
        private void FillMarca() {
            var listaMarca = cMarca.Get();
            comboBox1.DataSource = listaMarca;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "MarcaId";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

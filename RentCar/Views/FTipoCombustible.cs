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
    public partial class FTipoCombustible : Form
    {
        public FTipoCombustible()
        {
            InitializeComponent();
        }
        CTipoCombustible cTipoCombustible = new CTipoCombustible();
        TipoCombustible TipoCombustible = new TipoCombustible();
        private int TipoCombustibleId;

        private void CargarGrid()
        {
            var lista = cTipoCombustible.Get();
            dataGridView1.DataSource = lista;
        }
        private void FTipoCombustible_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
        private void CargarDatos()
        {
            TipoCombustible.Descripcion = textBox1.Text;
            TipoCombustible.TipoCombustibleId= TipoCombustibleId;

        }
        private void limpiar()
        {
            TipoCombustibleId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            CargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cTipoCombustible.Create(TipoCombustible);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TipoCombustibleId > 0)
            {
                CargarDatos();
                cTipoCombustible.Update(TipoCombustible);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TipoCombustibleId > 0)
            {
                cTipoCombustible.Delete(TipoCombustibleId);
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
            TipoCombustibleId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TipoCombustibleId"].Value.ToString());
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

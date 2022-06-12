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

namespace RentCar
{
    public partial class FTipoVehiculo : Form
    {
        public FTipoVehiculo()
        {
            InitializeComponent();
        }
        CTipoVehiculo cTipoVehiculo = new CTipoVehiculo();
        TipoVehiculo tipoVehiculo = new TipoVehiculo();
        private int TipoVehiculoId;

        private void CargarGrid() {
            var lista = cTipoVehiculo.Get();
            dataGridView1.DataSource = lista;
        }

        private void FTipoVehiculo_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarDatos()
        {
            tipoVehiculo.Descripcion = textBox1.Text;
            tipoVehiculo.TipoVehiculoId = TipoVehiculoId;
        }
        private void limpiar() {
            TipoVehiculoId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            CargarGrid();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cTipoVehiculo.Create(tipoVehiculo);
            limpiar();
        }
 

        private void button3_Click(object sender, EventArgs e)
        {
            if (TipoVehiculoId > 0)
            {
                CargarDatos();
                cTipoVehiculo.Update(tipoVehiculo);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }      

        private void button2_Click(object sender, EventArgs e)
        {
            if (TipoVehiculoId > 0)
            {             
                cTipoVehiculo.Delete(TipoVehiculoId);
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
            TipoVehiculoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TipoVehiculoId"].Value.ToString());
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

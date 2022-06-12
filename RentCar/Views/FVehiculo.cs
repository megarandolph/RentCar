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
    public partial class FVehiculo : Form
    {
        public FVehiculo()
        {
            InitializeComponent();
        }
        CVehiculo cVehiculo = new CVehiculo();
        CTipoCombustible cTipoCombustible = new CTipoCombustible();
        CMarca cMarca = new CMarca();
        CModelo cModelo = new CModelo();
        CTipoVehiculo cTipoVehiculo = new CTipoVehiculo();

        Vehiculo Vehiculo = new Vehiculo();
        private int VehiculoId;

        private void CargarGrid()
        {
            var lista = cVehiculo.Get();
            dataGridView1.DataSource = lista;
        }
        private void FVehiculo_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillTipoVehiculo();
            FillMarca();
            FillTipoCombustible();

        }
        private void CargarDatos()
        {
            Vehiculo.Descripcion = textBox1.Text;
            Vehiculo.Chasis = textBox2.Text;
            Vehiculo.Motor = textBox3.Text;
            Vehiculo.Placa = textBox4.Text;
            Vehiculo.TipoVehiculoId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            Vehiculo.MarcaId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            Vehiculo.ModeloId = Convert.ToInt32(comboBox3.SelectedValue.ToString());
            Vehiculo.TipoCombustibleId = Convert.ToInt32(comboBox4.SelectedValue.ToString());

            Vehiculo.VehiculoId = VehiculoId;
        }
        private void limpiar()
        {
            VehiculoId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            comboBox4.SelectedValue = 0;


            CargarGrid();
            FillTipoVehiculo();
            FillMarca();
            FillTipoCombustible();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cVehiculo.Create(Vehiculo);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (VehiculoId > 0)
            {
                CargarDatos();
                cVehiculo.Update(Vehiculo);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (VehiculoId > 0)
            {
                cVehiculo.Delete(VehiculoId);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            limpiar();
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            VehiculoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["VehiculoId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Chasis"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Motor"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Placa"].Value.ToString();
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TipoVehiculoId"].Value.ToString());
            comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MarcaId"].Value.ToString());
            comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ModeloId"].Value.ToString());
            comboBox4.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TipoCombustibleId"].Value.ToString());

        }
        private void FillTipoVehiculo()
        {
            var listaTipoVehiculo = cTipoVehiculo.Get();
            comboBox1.DataSource = listaTipoVehiculo;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "TipoVehiculoId";
        }
        private void FillMarca()
        {
            var listaMarca = cMarca.Get();
            comboBox2.DataSource = listaMarca;
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "MarcaId";

        }
        private void FillModelo(int MarcaId)
        {
            var listaModelo = cModelo.ModeloByMarca(MarcaId);
            comboBox3.DataSource = listaModelo;
            comboBox3.DisplayMember = "Descripcion";
            comboBox3.ValueMember = "ModeloId";
        }
        private void FillTipoCombustible()
        {
            var listaTipoCombustible = cTipoCombustible.Get();
            comboBox4.DataSource = listaTipoCombustible;
            comboBox4.DisplayMember = "Descripcion";
            comboBox4.ValueMember = "TipoCombustibleId";
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count > 0)
            {
                if (comboBox2.ValueMember != String.Empty)
                {
                    var MarcaId = Convert.ToInt32(comboBox2.SelectedValue);
                    FillModelo(MarcaId);
                }
                if (comboBox3.Items.Count == 0) { 
                    comboBox3.SelectedItem = -1;
                }
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

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

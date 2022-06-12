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
    public partial class FRenta : Form
    {
        public FRenta()
        {
            InitializeComponent();
        }
        CRenta cRenta = new CRenta();
        CEmpleado cEmpleado = new CEmpleado();
        CVehiculo cVehiculo = new CVehiculo();
        CCliente cCliente = new CCliente();

        Renta Renta = new Renta();
        private int RentaId;

        private void CargarGrid()
        {
            var lista = cRenta.Get();
            dataGridView1.DataSource = lista;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRenta_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillCliente();
            FillVehiculo();
            FillEmpleado();
        }
        private void CargarDatos()
        {
            Renta.MontoDiario = Convert.ToDecimal(textBox1.Text);
            Renta.Dias = Convert.ToInt32(textBox2.Text);
            Renta.Comentario = textBox3.Text;
            Renta.FechaRenta = dateTimePicker1.Value;     
            Renta.EmpleadoId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            Renta.VehiculoId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            Renta.ClienteId = Convert.ToInt32(comboBox3.SelectedValue.ToString());

            Renta.RentaId = RentaId;
        }
        private void limpiar()
        {
            RentaId = 0;
            comboBox1.Focus();
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;            
            

            CargarGrid();
            FillCliente();
            FillVehiculo();
            FillEmpleado();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cRenta.Create(Renta);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RentaId > 0)
            {
                CargarDatos();
                cRenta.Update(Renta);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RentaId > 0)
            {
                cRenta.Delete(RentaId);
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
        private void button5_Click(object sender, EventArgs e)
        {
            if (RentaId > 0)
            {
                cRenta.Devolucion(RentaId);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            RentaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RentaId"].Value.ToString());
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmpleadoId"].Value.ToString());
            comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["VehiculoId"].Value.ToString());
            comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["MontoDiario"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Dias"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Comentario"].Value.ToString();   
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaRenta"].Value.ToString());
        }

        private void FillVehiculo()
        {
            var listaVehiculo = cVehiculo.Get();
            comboBox2.DataSource = listaVehiculo;
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "VehiculoId";

        }
        private void FillCliente()
        {
            var listaCliente = cCliente.Get();
            comboBox3.DataSource = listaCliente;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "ClienteId";
        }
        private void FillEmpleado()
        {
            var listaEmpleado = cEmpleado.Get();
            comboBox1.DataSource = listaEmpleado;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "EmpleadoId";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

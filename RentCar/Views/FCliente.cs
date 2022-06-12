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
    public partial class FCliente : Form
    {
        public FCliente()
        {
            InitializeComponent();
        }
        CCliente cCliente = new CCliente();
        CTipoPersona cTipoPersona = new CTipoPersona();
        Cliente Cliente = new Cliente();
        private int ClienteId;

        private void CargarGrid()
        {
            var lista = cCliente.Get();
            dataGridView1.DataSource = lista;
        }
        private void FCliente_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillTipoPersona();
        }
        private void CargarDatos()
        {
            Cliente.Nombre = textBox1.Text;
            Cliente.Cedula = textBox2.Text;
            Cliente.TarjetaCredito = textBox3.Text;
            Cliente.LimiteCredito = Convert.ToDecimal(textBox4.Text);
            Cliente.TipoPersonaId = Convert.ToInt32(comboBox1.SelectedValue.ToString());

            Cliente.ClienteId = ClienteId;
        }
        private void limpiar()
        {
            ClienteId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            comboBox1.SelectedValue = 0;


            CargarGrid();
            FillTipoPersona();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cCliente.Create(Cliente);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ClienteId > 0)
            {
                CargarDatos();
                cCliente.Update(Cliente);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ClienteId > 0)
            {
                cCliente.Delete(ClienteId);
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
            ClienteId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Cedula"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["TarjetaCredito"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["LimiteCredito"].Value.ToString();
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TipoPersonaId"].Value.ToString());

        }
        private void FillTipoPersona()
        {
            var listaTipoPersona = cTipoPersona.Get();
            comboBox1.DataSource = listaTipoPersona;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "TipoPersonaId";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

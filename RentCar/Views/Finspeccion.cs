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
    public partial class Finspeccion : Form
    {
        public Finspeccion()
        {
            InitializeComponent();
        }
        CInspeccion cInspeccion = new CInspeccion();
        CCantidadCombustible cCantidadCombustible = new CCantidadCombustible();
        CVehiculo cVehiculo = new CVehiculo();
        CCliente cCliente = new CCliente();
        CEmpleado cEmpleado = new CEmpleado();

        Inspeccion Inspeccion = new Inspeccion();
        private int InspeccionId;

        private void CargarGrid()
        {
            var lista = cInspeccion.Get();
            dataGridView1.DataSource = lista;
        }
        private void Finspeccion_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillEmpleado();
            FillVehiculo();
            FillCliente();
            FillCantidadCombustible();

        }
        private void CargarDatos()
        {
            Inspeccion.VehiculoId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            Inspeccion.ClienteId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            Inspeccion.EmpleadoId = Convert.ToInt32(comboBox3.SelectedValue.ToString());
            Inspeccion.TieneRalladuras = checkBox1.Checked;
            Inspeccion.TieneGomaRespuesta = checkBox2.Checked;
            Inspeccion.TieneGato = checkBox3.Checked;
            Inspeccion.TieneRoturasCristal = checkBox4.Checked;
            Inspeccion.GomaDelanteraDerecha = checkBox5.Checked;
            Inspeccion.GomaDelanteraIzquierda = checkBox6.Checked;
            Inspeccion.GomaTraceraDerecha = checkBox7.Checked;
            Inspeccion.GomaTraceraIzquierda = checkBox8.Checked;
            Inspeccion.Etc = textBox1.Text;
            Inspeccion.Fecha = dateTimePicker1.Value;
            Inspeccion.CantidadCombustibleId = Convert.ToInt32(comboBox4.SelectedValue.ToString());

            Inspeccion.InspeccionId = InspeccionId;
        }
        private void limpiar()
        {
            InspeccionId = 0;
            comboBox1.Focus();
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            comboBox4.SelectedValue = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            textBox1.Text = String.Empty;
            


            CargarGrid();
            FillEmpleado();
            FillVehiculo();
            FillCliente();
            FillCantidadCombustible();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cInspeccion.Create(Inspeccion);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (InspeccionId > 0)
            {
                CargarDatos();
                cInspeccion.Update(Inspeccion);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (InspeccionId > 0)
            {
                cInspeccion.Delete(InspeccionId);
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
            InspeccionId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["InspeccionId"].Value.ToString());
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["VehiculoId"].Value.ToString());
            comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteId"].Value.ToString());
            comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmpleadoId"].Value.ToString());
            checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TieneRalladuras"].Value.ToString());
            checkBox2.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TieneGomaRespuesta"].Value.ToString());
            checkBox3.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TieneGato"].Value.ToString());
            checkBox4.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TieneRoturasCristal"].Value.ToString());
            checkBox5.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["GomaDelanteraDerecha"].Value.ToString());
            checkBox6.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["GomaDelanteraIzquierda"].Value.ToString());
            checkBox7.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["GomaTraceraDerecha"].Value.ToString());
            checkBox8.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["GomaTraceraIzquierda"].Value.ToString());
            comboBox4.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CantidadCombustibleId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Etc"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString());
        }
        private void FillEmpleado()
        {
            var listaEmpleado = cEmpleado.Get();
            comboBox3.DataSource = listaEmpleado;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "EmpleadoId";
        }
        private void FillVehiculo()
        {
            var listaVehiculo = cVehiculo.Get();
            comboBox1.DataSource = listaVehiculo;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "VehiculoId";

        }
        private void FillCliente()
        {
            var listaCliente = cCliente.Get();
            comboBox2.DataSource = listaCliente;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "ClienteId";
        }
        private void FillCantidadCombustible()
        {
            var listaCantidadCombustible = cCantidadCombustible.Get();
            comboBox4.DataSource = listaCantidadCombustible;
            comboBox4.DisplayMember = "Descripcion";
            comboBox4.ValueMember = "CantidadCombustibleId";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

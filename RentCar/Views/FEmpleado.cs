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
    public partial class FEmpleado : Form
    {
        public FEmpleado()
        {
            InitializeComponent();
        }
        CEmpleado cEmpleado = new CEmpleado();
        CTandaLaboral cTandaLaboral = new CTandaLaboral();
        Empleado Empleado = new Empleado();
        private int EmpleadoId;
        private void CargarGrid()
        {
            var lista = cEmpleado.Get();
            dataGridView1.DataSource = lista;
        }
        private void FEmpleado_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillTandaLaboral();
        }
        private void CargarDatos()
        {
            Empleado.Nombre = textBox1.Text;
            Empleado.Cedula = textBox2.Text;
            Empleado.TandaLaboralId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            Empleado.PorcientoComision = Convert.ToInt32(textBox3.Text);
            Empleado.FechaIngreso = dateTimePicker1.Value;

            Empleado.EmpleadoId = EmpleadoId;
        }
        private void limpiar()
        {
            EmpleadoId = 0;
            textBox1.Focus();
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            
            comboBox1.SelectedValue = 0;


            CargarGrid();
            FillTandaLaboral();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            cEmpleado.Create(Empleado);
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpleadoId > 0)
            {
                CargarDatos();
                cEmpleado.Update(Empleado);
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpleadoId > 0)
            {
                cEmpleado.Delete(EmpleadoId);
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
            EmpleadoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmpleadoId"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Cedula"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["PorcientoComision"].Value.ToString(); 
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TandaLaboralId"].Value.ToString());
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaIngreso"].Value.ToString());
        }
        private void FillTandaLaboral()
        {
            var listaTandaLaboral = cTandaLaboral.Get();
            comboBox1.DataSource = listaTandaLaboral;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "TandaLaboralId";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

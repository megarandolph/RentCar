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
    public partial class FConsultas : Form
    {
        public class Parametros
        {
            public string Nombre { get; set; }
            public int Valor { get; set; }
        }
        public FConsultas()
        {
            InitializeComponent();
        }
        CRenta cRenta = new CRenta();

        private void CargarGrid()
        {
            var lista = cRenta.GetByParametros();
            dataGridView1.DataSource = lista;
        }
        private void FConsultas_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillParametros();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Parametro = Convert.ToInt32(comboBox1.SelectedValue.ToString()); 
            var Busqueda = textBox1.Text;

            dataGridView1.DataSource = cRenta.GetByParametros(Parametro, Busqueda);
        }

        private void FillParametros()
        {


            var dataSource = new List<Parametros>();
            dataSource.Add(new Parametros() { Nombre = "Empleado", Valor = 1 });
            dataSource.Add(new Parametros() { Nombre = "Cliente", Valor = 2 });
            dataSource.Add(new Parametros() { Nombre = "Vehiculo", Valor = 3 });
            dataSource.Add(new Parametros() { Nombre = "Monto diario", Valor = 4 });
            dataSource.Add(new Parametros() { Nombre = "Dias", Valor = 5 });
            dataSource.Add(new Parametros() { Nombre = "Comentario", Valor = 6 });

            //Setup data binding
            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.ValueMember = "Valor";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lista = cRenta.GetByParametros();
            dataGridView1.DataSource = lista;
            comboBox1.SelectedValue = 0;
            textBox1.Text = String.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

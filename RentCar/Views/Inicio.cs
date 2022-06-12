using RentCar.Views;
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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tiposDeVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTipoVehiculo tipoVehiculo = new FTipoVehiculo();
            tipoVehiculo.Show();
            this.Hide();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMarca fMarca = new FMarca();
            fMarca.Show();
            this.Hide();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FModelo fModelo = new FModelo();
            fModelo.Show();
            this.Hide();
        }

        private void tiposDeCombustiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTipoCombustible FTipoCombustible = new FTipoCombustible();
            FTipoCombustible.Show();
            this.Hide();
        }

        private void tipoDePersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTipoPersona FTipoPersona = new FTipoPersona();
            FTipoPersona.Show();
            this.Hide();
        }

        private void tandasLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTandaLaboral FTandaLaboral = new FTandaLaboral();
            FTandaLaboral.Show();
            this.Hide();
        }

        private void cantidadDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCantidadCombustible FCantidadCombustible = new FCantidadCombustible();
            FCantidadCombustible.Show();
            this.Hide();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FVehiculo FVehiculo = new FVehiculo();
            FVehiculo.Show();
            this.Hide();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCliente FCliente = new FCliente();
            FCliente.Show();
            this.Hide();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEmpleado FEmpleado = new FEmpleado();
            FEmpleado.Show();
            this.Hide();

        }

        private void inspeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finspeccion Finspeccion = new Finspeccion();
            Finspeccion.Show();
            this.Hide();
        }

        private void rentaYDevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRenta FRenta = new FRenta();
            FRenta.Show();
            this.Hide();
        }

        private void consultasVariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FConsultas FConsultas = new FConsultas();
            FConsultas.Show();
            this.Hide();
        }

        private void porFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FReporteFechas FReporteFechas = new FReporteFechas();
            FReporteFechas.Show();
            this.Hide();
        }

        private void tipoDeVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FReporteTipoVehiculo FReporteTipoVehiculo = new FReporteTipoVehiculo();
            FReporteTipoVehiculo.Show();
            this.Hide();
        }
    }
}

using iTextSharp.text;
using iTextSharp.text.pdf;
using RentCar.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Views
{
    public partial class FReporteTipoVehiculo : Form
    {
        public FReporteTipoVehiculo()
        {
            InitializeComponent();
        }
        CReportes cReportes = new CReportes();
        CTipoVehiculo cTipoVehiculo = new CTipoVehiculo();

        private void CargarGrid()
        {
            var lista = cReportes.Get();
            dataGridView1.DataSource = lista;
        }     
        private void FReporteTipoVehiculo_Load(object sender, EventArgs e)
        {
            CargarGrid();
            FillTipoVehiculo();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var Busqueda = comboBox2.SelectedValue.ToString();

            dataGridView1.DataSource = cReportes.GetByTipoVehiculo(Busqueda);
        }
        private void FillTipoVehiculo() { 
          
            this.comboBox2.DataSource = cTipoVehiculo.Get();
            this.comboBox2.DisplayMember = "Descripcion";
            this.comboBox2.ValueMember = "Descripcion";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cReportes.Get();
            comboBox2.SelectedValue = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Reporte de rentas por tipo vehiculo.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("No fue posible." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                    else
                                    {
                                        pdfTable.AddCell("");
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("La data fue exportada correctamente!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay registros para exportar!", "Info");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            Inicio.Show();
            this.Hide();
        }
    }
}

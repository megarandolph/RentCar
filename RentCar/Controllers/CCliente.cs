using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CCliente
    {
        RentCarDBEntities db;

        public List<View_Cliente> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Cliente.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(Cliente Cliente)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    var ExisteCliente = Get().Where(x => x.Cedula == Cliente.Cedula);
                    bool CedulaValida = false;

                    int vnTotal = 0;
                    string vcCedula = Cliente.Cedula.Replace("-", "");
                    int pLongCed = vcCedula.Trim().Length;
                    int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

                    if (pLongCed < 11 || pLongCed > 11)
                    {
                        CedulaValida = false;
                    }

                    for (int vDig = 1; vDig <= pLongCed; vDig++)
                    {
                        int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                        if (vCalculo < 10)
                            vnTotal += vCalculo;
                        else
                            vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
                    }

                    if (vnTotal % 10 == 0)
                        CedulaValida = true;
                    else
                        CedulaValida = false;

                    if (ExisteCliente.Count() == 0 && CedulaValida && Cliente.LimiteCredito > 0)
                    {
                        Cliente.Estado = true;
                        db.Cliente.Add(Cliente);
                        db.SaveChanges();
                        MessageBox.Show("Guardado");
                    }
                    else {
                        if (ExisteCliente.Count() > 0)
                        {
                            MessageBox.Show("Cliente existente");
                        }
                        else
                        {
                            MessageBox.Show("Cedula invalida");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Cliente Cliente)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    bool CedulaValida = false;

                    int vnTotal = 0;
                    string vcCedula = Cliente.Cedula.Replace("-", "");
                    int pLongCed = vcCedula.Trim().Length;
                    int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

                    if (pLongCed < 11 || pLongCed > 11)
                    {
                        CedulaValida = false;
                    }

                    for (int vDig = 1; vDig <= pLongCed; vDig++)
                    {
                        int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                        if (vCalculo < 10)
                            vnTotal += vCalculo;
                        else
                            vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
                    }

                    if (vnTotal % 10 == 0)
                        CedulaValida = true;
                    else
                        CedulaValida = false;

                    if (CedulaValida && Cliente.LimiteCredito > 0)
                    {
                        db.Entry(Cliente).State = EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Editado");
                    }
                    else{
                            MessageBox.Show("Cedula invalida");

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int ClienteId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var Cliente = db.Cliente.Find(ClienteId);
                    Cliente.Estado = false;
                    db.SaveChanges();
                    MessageBox.Show("Borrado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

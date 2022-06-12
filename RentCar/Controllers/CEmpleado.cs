using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CEmpleado
    {
        RentCarDBEntities db;

        public List<View_Empleado> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Empleado.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(Empleado Empleado)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var ExisteEmpleado = Get().Where(x => x.Cedula == Empleado.Cedula);
                    bool CedulaValida = false;

                    int vnTotal = 0;
                    string vcCedula = Empleado.Cedula.Replace("-", "");
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

                    if (ExisteEmpleado.Count() == 0 && CedulaValida)
                    {
                        Empleado.Estado = true;
                        db.Empleado.Add(Empleado);
                        db.SaveChanges();
                        MessageBox.Show("Guardado");
                    }
                    else
                    {
                        if (ExisteEmpleado.Count() > 0)
                        {
                            MessageBox.Show("Empleado existente");
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
        public void Update(Empleado Empleado)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    bool CedulaValida = false;

                    int vnTotal = 0;
                    string vcCedula = Empleado.Cedula.Replace("-", "");
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

                    if (CedulaValida)
                    {
                        db.Entry(Empleado).State = EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Editado");
                    }
                    else { 
                            MessageBox.Show("Cedula invalida");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int EmpleadoId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var Empleado = db.Empleado.Find(EmpleadoId);
                    Empleado.Estado = false;
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

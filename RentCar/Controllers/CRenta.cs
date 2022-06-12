using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CRenta
    {
        RentCarDBEntities db;

        public List<View_Renta> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Renta.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<View_Rentas> GetByParametros(int type = 0, string busqueda = "")
        {
            try
            {
               
                using (var db = new RentCarDBEntities())
                {
                    if (type == 0)
                    {
                        return db.View_Rentas.ToList();
                    }
                    else if (type == 1)
                    {
                        var data = db.View_Rentas.Where(x => x.Empleado.Contains(busqueda)).ToList();
                        return data;
                    }
                    else if (type == 2)
                    {
                        return db.View_Rentas.Where(x => x.Cliente.Contains(busqueda)).ToList();
                    }
                    else if (type == 3)
                    {
                        return db.View_Rentas.Where(x => x.Vehiculo.Contains(busqueda)).ToList();
                    }
                    else if (type == 4)
                    {
                        var montodiario = Convert.ToDecimal(busqueda);
                        return db.View_Rentas.Where(x => x.MontoDiario == montodiario).ToList();
                    }
                    else if (type == 5)
                    {
                        var dias = Convert.ToInt32(busqueda);
                        return db.View_Rentas.Where(x => x.Dias == dias).ToList();
                    }
                    else if (type == 6)
                    {
                        return db.View_Rentas.Where(x => x.Comentario.Contains(busqueda)).ToList();
                    }                 
                   else {
                        return null;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(Renta Renta)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    var VehiculosRentados = Get().Where(x=>x.VehiculoId == Renta.VehiculoId && x.Estado == true);
                    if (VehiculosRentados.Count() == 0 && Renta.Dias > 0 && Renta.MontoDiario > 0)
                    {
                        Renta.Estado = true;
                        Renta.FechaEsperada = Renta.FechaRenta.Value.AddDays((int)Renta.Dias);
                        db.Renta.Add(Renta);
                        db.SaveChanges();
                        MessageBox.Show("Guardado");
                    }
                    else {
                        if (VehiculosRentados.Count() > 0) {
                            MessageBox.Show("Este vehiculo aun esta rentado");
                        }
                        else { 
                            MessageBox.Show("El monto o los dias son invalidos");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Renta Renta)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    if (Renta.Dias > 0 && Renta.MontoDiario > 0)
                    {
                        Renta.Estado = true;
                        Renta.FechaEsperada = Renta.FechaRenta.Value.AddDays((int)Renta.Dias);
                        db.Entry(Renta).State = EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Editado");
                    }
                    else { 
                            MessageBox.Show("El monto o los dias son invalidos");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int RentaId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var Renta = db.Renta.Find(RentaId);
                    Renta.Estado = false;
                    db.SaveChanges();
                    MessageBox.Show("Borrado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Devolucion(int RentaId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var Renta = db.Renta.Find(RentaId);
                    Renta.FechaDevolucion = DateTime.UtcNow.AddHours(-4);
                    Renta.Estado = false;
                    db.SaveChanges();
                    MessageBox.Show("Devuelto");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

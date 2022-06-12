using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CVehiculo
    {
        RentCarDBEntities db;

        public List<View_Vehiculo> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Vehiculo.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(Vehiculo Vehiculo)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    Vehiculo.Estado = true;
                    db.Vehiculo.Add(Vehiculo);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Vehiculo Vehiculo)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(Vehiculo).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int VehiculoId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var Vehiculo = db.Vehiculo.Find(VehiculoId);
                    Vehiculo.Estado = false;
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

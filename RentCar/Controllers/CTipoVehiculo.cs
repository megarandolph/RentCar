using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CTipoVehiculo
    {
        RentCarDBEntities db;

        public List<View_TipoVehiculo> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_TipoVehiculo.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(TipoVehiculo tipoVehiculo)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    tipoVehiculo.Estado = true;
                    db.TipoVehiculo.Add(tipoVehiculo);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(TipoVehiculo tipoVehiculo)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(tipoVehiculo).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int tipoVehiculoId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var tipoVehiculo = db.TipoVehiculo.Find(tipoVehiculoId);
                    tipoVehiculo.Estado = false;
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

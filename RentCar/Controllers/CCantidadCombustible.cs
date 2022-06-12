using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CCantidadCombustible
    {
        RentCarDBEntities db;

        public List<View_CantidadCombustible> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_CantidadCombustible.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(CantidadCombustible CantidadCombustible)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    CantidadCombustible.Estado = true;
                    db.CantidadCombustible.Add(CantidadCombustible);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(CantidadCombustible CantidadCombustible)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(CantidadCombustible).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int CantidadCombustibleId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var CantidadCombustible = db.CantidadCombustible.Find(CantidadCombustibleId);
                    CantidadCombustible.Estado = false;
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

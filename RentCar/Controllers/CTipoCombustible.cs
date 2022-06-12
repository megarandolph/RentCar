using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CTipoCombustible
    {
        RentCarDBEntities db;

        public List<View_TipoCombustible> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_TipoCombustible.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(TipoCombustible TipoCombustible)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    TipoCombustible.Estado = true;
                    db.TipoCombustible.Add(TipoCombustible);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(TipoCombustible TipoCombustible)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(TipoCombustible).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int TipoCombustibleId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var TipoCombustible = db.TipoCombustible.Find(TipoCombustibleId);
                    TipoCombustible.Estado = false;
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

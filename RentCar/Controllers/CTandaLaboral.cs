using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CTandaLaboral
    {
        RentCarDBEntities db;

        public List<View_TandaLaboral> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_TandaLaboral.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(TandaLaboral TandaLaboral)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    TandaLaboral.Estado = true;
                    db.TandaLaboral.Add(TandaLaboral);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(TandaLaboral TandaLaboral)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(TandaLaboral).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int TandaLaboralId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var TandaLaboral = db.TandaLaboral.Find(TandaLaboralId);
                    TandaLaboral.Estado = false;
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

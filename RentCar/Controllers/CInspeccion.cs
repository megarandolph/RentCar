using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CInspeccion
    {
        RentCarDBEntities db;

        public List<View_Inspeccion> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Inspeccion.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(Inspeccion Inspeccion)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    Inspeccion.Estado = true;
                    db.Inspeccion.Add(Inspeccion);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Inspeccion Inspeccion)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(Inspeccion).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int InspeccionId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var Inspeccion = db.Inspeccion.Find(InspeccionId);
                    Inspeccion.Estado = false;
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

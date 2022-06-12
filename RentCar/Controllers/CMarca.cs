using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CMarca
    {
        RentCarDBEntities db;

        public List<View_Marca> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Marca.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(Marca marca)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    marca.Estado = true;
                    db.Marca.Add(marca);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Marca marca)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(marca).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int marcaId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var marca = db.Marca.Find(marcaId);
                    marca.Estado = false;
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

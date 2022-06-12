using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CModelo
    {
        RentCarDBEntities db;

        public List<View_Modelo> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Modelo.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<View_Modelo> ModeloByMarca(int MarcaId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    if (MarcaId > 0)
                    {
                        return db.View_Modelo.Where(x => x.MarcaId == MarcaId).ToList();
                    }
                    else
                    {
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

        public void Create(Modelo Modelo)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    Modelo.Estado = true;
                    db.Modelo.Add(Modelo);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Modelo Modelo)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(Modelo).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int ModeloId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var Modelo = db.Modelo.Find(ModeloId);
                    Modelo.Estado = false;
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

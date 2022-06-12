using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CTipoPersona
    {
        RentCarDBEntities db;

        public List<View_TipoPersona> Get()
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    return db.View_TipoPersona.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Create(TipoPersona TipoPersona)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {
                    TipoPersona.Estado = true;
                    db.TipoPersona.Add(TipoPersona);
                    db.SaveChanges();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(TipoPersona TipoPersona)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    db.Entry(TipoPersona).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Editado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int TipoPersonaId)
        {
            try
            {
                using (var db = new RentCarDBEntities())
                {

                    var TipoPersona = db.TipoPersona.Find(TipoPersonaId);
                    TipoPersona.Estado = false;
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

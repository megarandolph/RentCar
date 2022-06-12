using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Controllers
{
    internal class CReportes
    {
        RentCarDBEntities db;     

        public List<View_Rentas> Get()
        {
            try
            {

                using (var db = new RentCarDBEntities())
                {                 
                    return db.View_Rentas.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<View_Rentas> GetByFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                FechaInicio = FechaInicio.Date;
                FechaFin = FechaFin.Date;
                using (var db = new RentCarDBEntities())
                {
                    return db.View_Rentas.Where(x => x.FechaRenta >= FechaInicio && x.FechaRenta <= FechaFin).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<View_Rentas> GetByTipoVehiculo(string TipoVehiculo)
        {
            try
            {

                using (var db = new RentCarDBEntities())
                {

                    return db.View_Rentas.Where(x => x.TipoVehiculo == TipoVehiculo).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}

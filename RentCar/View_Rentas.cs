//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCar
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_Rentas
    {
        public int RentaId { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }
        public string Vehiculo { get; set; }
        public Nullable<System.DateTime> FechaRenta { get; set; }
        public Nullable<System.DateTime> FechaEsperada { get; set; }
        public Nullable<System.DateTime> FechaDevolucion { get; set; }
        public Nullable<decimal> MontoDiario { get; set; }
        public Nullable<int> Dias { get; set; }
        public string Comentario { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string TipoVehiculo { get; set; }
    }
}

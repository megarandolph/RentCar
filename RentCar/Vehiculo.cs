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
    
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            this.Inspeccion = new HashSet<Inspeccion>();
            this.Renta = new HashSet<Renta>();
        }
    
        public int VehiculoId { get; set; }
        public Nullable<int> TipoVehiculoId { get; set; }
        public Nullable<int> MarcaId { get; set; }
        public Nullable<int> ModeloId { get; set; }
        public Nullable<int> TipoCombustibleId { get; set; }
        public string Descripcion { get; set; }
        public string Chasis { get; set; }
        public string Motor { get; set; }
        public string Placa { get; set; }
        public Nullable<bool> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspeccion> Inspeccion { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual TipoCombustible TipoCombustible { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta> Renta { get; set; }
    }
}

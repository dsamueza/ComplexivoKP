//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KatherinePorras_FINBANK.Acceso_Dato.@base
{
    using System;
    using System.Collections.Generic;
    
    public partial class SFB_INTERES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SFB_INTERES()
        {
            this.SFB_SIMULACION = new HashSet<SFB_SIMULACION>();
        }
    
        public int SFB_INT_ID { get; set; }
        public string SFB_INT_DESCRIPCION { get; set; }
        public Nullable<double> SFB_INT_VALOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SFB_SIMULACION> SFB_SIMULACION { get; set; }
    }
}

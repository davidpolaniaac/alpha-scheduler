//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlphaScheduler.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Linea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Linea()
        {
            this.Pensum = new HashSet<Pensum>();
        }
    
        public int Id_Linea { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int FK_Id_Programa { get; set; }
    
        public virtual Programa Programa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pensum> Pensum { get; set; }
    }
}
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
    using System.ComponentModel;
    public partial class Programa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Programa()
        {
            this.Linea = new HashSet<Linea>();
            this.Materia = new HashSet<Materia>();
        }
    
        public int Id_Programa { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        [DisplayName("Facultad")]
        public int FK_Id_Facultad { get; set; }
    
        public virtual Facultad Facultad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Linea> Linea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materia> Materia { get; set; }
    }
}

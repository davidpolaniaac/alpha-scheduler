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
    public partial class Pensum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pensum()
        {
            this.Pensum_Materia = new HashSet<Pensum_Materia>();
        }
    
        public int Id_Pensum { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        [DisplayName("Linea")]
        public int FK_Id_Linea { get; set; }
        [DisplayName("Num Semestre")]
        public Nullable<int> numSemestre { get; set; }
    
        public virtual Linea Linea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pensum_Materia> Pensum_Materia { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBALPHAEntities : DbContext
    {
        public DBALPHAEntities()
            : base("name=DBALPHAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Linea> Linea { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<Pensum> Pensum { get; set; }
        public virtual DbSet<Pensum_Materia> Pensum_Materia { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Programa> Programa { get; set; }
        public virtual DbSet<Sede> Sede { get; set; }
        public virtual DbSet<ViewFacultad> ViewFacultad { get; set; }
        public virtual DbSet<ViewLinea> ViewLinea { get; set; }
        public virtual DbSet<ViewMateria> ViewMateria { get; set; }
        public virtual DbSet<ViewMateriaPensum> ViewMateriaPensum { get; set; }
        public virtual DbSet<ViewPensum> ViewPensum { get; set; }
        public virtual DbSet<ViewPrograma> ViewPrograma { get; set; }
    }
}

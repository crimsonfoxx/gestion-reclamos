﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projecto.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class examenEntities : DbContext
    {
        public examenEntities()
            : base("name=examenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<queja> quejas { get; set; }
        public virtual DbSet<Decanato> Decanatoes { get; set; }
        public virtual DbSet<Equipo> Equipoes { get; set; }
        public virtual DbSet<EVA> EVAs { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
    }
}

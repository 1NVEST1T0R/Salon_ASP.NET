//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Salon.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Frizerski_SalonEntities3 : DbContext
    {
        public Frizerski_SalonEntities3()
            : base("name=Frizerski_SalonEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Frizura> Frizura { get; set; }
        public virtual DbSet<Komentar> Komentar { get; set; }
        public virtual DbSet<Nalog> Nalog { get; set; }
        public virtual DbSet<Naplata> Naplata { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Termin> Termin { get; set; }
    }
}

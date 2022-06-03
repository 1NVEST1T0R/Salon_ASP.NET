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
    using System.Collections.Generic;
    
    public partial class Frizura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Frizura()
        {
            this.Komentar = new HashSet<Komentar>();
            this.Proizvod = new HashSet<Proizvod>();
            this.Racun = new HashSet<Racun>();
            this.Termin = new HashSet<Termin>();
        }
    
        public int FrizuraID { get; set; }
        public string NalogID { get; set; }
        public int Duzina { get; set; }
        public string Frizura1 { get; set; }
        public string Boja { get; set; }
        public string Preparati { get; set; }
        public int Tip { get; set; }
        public int Gustina { get; set; }
    
        public virtual Nalog Nalog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komentar> Komentar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvod> Proizvod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racun { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Termin> Termin { get; set; }
    }
}
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
    
    public partial class Racun
    {
        public int RacunID { get; set; }
        public int FrizuraID { get; set; }
        public System.DateTime Datum { get; set; }
        public System.TimeSpan Vreme { get; set; }
        public double Vrednost { get; set; }
        public bool Obradjen { get; set; }
        public bool Storniran { get; set; }
    
        public virtual Frizura Frizura { get; set; }
        public virtual Naplata Naplata { get; set; }
    }
}

//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int matricula { get; set; }
        public int campus { get; set; }
        public string queja { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Estatus { get; set; }
    }
}
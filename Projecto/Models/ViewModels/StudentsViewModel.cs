using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecto.Models.ViewModels
{
    public class StudentsViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Matricula { get; set; }
        public Campus Campus { get; set; }
        public string Queja { get; set; }
        public DateTime Fecha { get; set; }
        public string Estatus { get; set; }
    }
}
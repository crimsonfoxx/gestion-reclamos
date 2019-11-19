﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto.Models.ViewModels
{
    public class ComplainViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Matricula { get; set; }
        public int Campus { get; set; }
        public string Queja { get; set; }
        public DateTime Fecha { get; set; }
    }
}
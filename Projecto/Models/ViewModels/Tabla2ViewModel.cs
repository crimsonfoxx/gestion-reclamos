using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto.Models.ViewModels
{
    public class Tabla2ViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es mandatorio y solo se aceptan Letras")]
        [Display(Name = "Nombre")]
        [MaxLength(50), MinLength(10),]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La matricula debe ser entre 2017000 y 20199999")]
        [Display(Name = "Matricula")]
        [Range(20170000, 20199999)]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "Solo se permiten los valores 1 y 2")]
        [Display(Name = "Campus")]
        [Range(1, 2)]
        public int Campus { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio")]
        [Display(Name = "Queja")]
        public string Queja { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM.dd.yyyy}")]
        [Display(Name = "Fecha en la que se creo")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio, solo se aceptan letras")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Estatus")]
        public string Estatus { get; set; }
    }
}
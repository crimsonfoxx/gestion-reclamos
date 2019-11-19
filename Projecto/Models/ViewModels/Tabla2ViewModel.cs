using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto.Models.ViewModels
{
    public enum Estado
    {
        [Display(Name = "Activo")]
        Activo,
        [Display(Name = "Finalizado")]
        Finalizado
    }
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

        [Display(Name = "Campus")]
        [EnumDataType(typeof(Campus))]
        public Campus Campus { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio")]
        [Display(Name = "Queja")]
        public string Queja { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM.dd.yyyy}")]
        [Display(Name = "Fecha en la que se creo")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Estado")]
        [EnumDataType(typeof(Estado))]
        public string Estatus { get; set; }
    }
}
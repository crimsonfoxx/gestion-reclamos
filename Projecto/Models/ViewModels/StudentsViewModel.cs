using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto.Models.ViewModels
{
    public class StudentsViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es mandatorio y solo se aceptan Letras")]
        [Display(Name = "Nombre")]
        [RegularExpression(@"QUEJA\d{3}", ErrorMessage = "Eso no es asi, tiene que ser: QUEJAXXX, donde XXX es un numero entero")]
        [MaxLength(50), MinLength(5),]
        public string Nombre { get; set; } = "QUEJA000";

        [Required(ErrorMessage = "La matricula debe ser utilizada.")]
        [RegularExpression(@"\d{4}-\d{4}", ErrorMessage = "Eso no es asi, una matricula es por ej.: 2016-1283")]
        [Display(Name = "Matricula")]
        //[Range(20160000, 20199999)]
        public String Matricula { get; set; } = "0000-0000";

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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto.Models.ViewModels
{
    public enum Campus
    {
        [Display(Name = "Campus 1")]
        Campus1,
        [Display(Name = "Campus 2")]
        Campus2
    }

    public class TablaViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es obligatorio y solo se aceptan Letras")]
        [Display(Name = "Nombre")]
        [MaxLength(50), MinLength(10),]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La matricula debe ser entre 2017000 y 20199999")]
        [Display(Name = "Matricula")]
        [Range(20170000,20199999)]
        public int Matricula { get; set; }

        [Display(Name = "Campus")]
        [EnumDataType(typeof(Campus))]
        public Campus Campus { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Queja")]
        public string Queja { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date )]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Creacion o Modificacion")]
        public DateTime Fecha { get; set; }
    }

   
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto.Models.ViewModels
{
    public class ComplainViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es mandatorio y solo se aceptan Letras")]
        [Display(Name = "Nombre")]
        [RegularExpression(@"QUEJA\d{3}", ErrorMessage = "Eso no es asi, tiene que ser: QUEJAXXX, donde XXX es un numero entero")]
        [MaxLength(50), MinLength(5),]
        public string Nombre { get; set; } = "QUEJA000";
        // https://dotnettutorials.net/lesson/regular-expression-attribute-mvc/

        [Required(ErrorMessage = "La matricula debe ser utilizada.")]
        [RegularExpression(@"\d{4}-\d{4}", ErrorMessage = "Eso no es asi, una matricula es por ej.: 2016-1283")]
        [Display(Name = "Matricula")]
        public String Matricula { get; set; } = "0000-0000";

        // https://stackoverflow.com/questions/35160986/bind-gender-with-radio-button-in-create-and-edit-in-mvc
        // alt. https://stackoverflow.com/questions/18852821/how-can-i-bind-a-radio-button-with-model-data-in-asp-net-mvc
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
        // https://stackoverflow.com/questions/33470849/html-editorfor-datetime-not-displaying-when-set-a-default-value-to-it
        // https://stackoverflow.com/questions/20329146/asp-net-mvc-4-editorfor-datetime-not-prepopulating-in-chrome
        // NOTE: obs/depr // https://stackoverflow.com/questions/16843411/asp-mvc-editorfor-datetime-not-displaying
    }
}
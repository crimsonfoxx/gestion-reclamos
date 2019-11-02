using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projecto.Models.ViewModels
{
    public class ProfessorsViewModel : Controller
    {
        // GET: Professors
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projecto.Models;
using Projecto.Models.ViewModels;
namespace Projecto.Controllers
{
    public class ComplainController : Controller
    {
        // GET: Complain
        public ActionResult Index()
        {
            List<ComplainViewModel> lst;
            using (examenEntities db = new examenEntities())
            {

                lst = (from d in db.quejas
                       select new ComplainViewModel
                       {
                           Id = d.Id,
                           Nombre = d.Nombre,
                           Matricula = d.matricula,
                           Campus = d.campus,
                           Queja = d.queja1,
                           Fecha = d.fecha
                       }).ToList();
            }

            return View(lst);
        }

        

        public ActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (examenEntities db = new examenEntities())
                    {
                        var oTabla = new queja();
                        oTabla.Nombre = model.Nombre;
                        oTabla.matricula = model.Matricula;
                        oTabla.campus = model.Campus;
                        oTabla.queja1 = model.Queja;
                        oTabla.fecha = model.Fecha;

                        db.quejas.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/Complain/");
                }
                return View();
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (examenEntities db = new examenEntities())
            {
                var oTabla = db.quejas.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Matricula = oTabla.matricula;
                model.Campus = oTabla.campus;
                model.Queja = oTabla.queja1;
                model.Fecha = oTabla.fecha;
                model.Id = oTabla.Id;
            }
                return View();
        }


        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (examenEntities db = new examenEntities())
                    {
                        var oTabla = db.quejas.Find(model.Id);
                        oTabla.Nombre = model.Nombre;
                        oTabla.matricula = model.Matricula;
                        oTabla.campus = model.Campus;
                        oTabla.queja1 = model.Queja;
                        oTabla.fecha = model.Fecha;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Complain/");
                }
                return View();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (examenEntities db = new examenEntities())
            {
                var oTabla = db.quejas.Find(Id);
                db.quejas.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/Complain/");
        }

       

    }
}
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
            return View(new ComplainViewModel());
        }


        [HttpPost]
        public ActionResult Nuevo(ComplainViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (examenEntities db = new examenEntities())
                    {
                        var query = db.quejas
                        .Where(s => s.Nombre == model.Nombre);
                        if (query.Any())
                        {
                            ViewBag.ErrorMessage = "Entry with name already exists";
                            return View();
                        }
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


        // https://stackoverflow.com/questions/54026020/asp-net-core-2-1-razor-form-post-not-reaching-controller
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            ComplainViewModel model = new ComplainViewModel();
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
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(ComplainViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (examenEntities db = new examenEntities())
                    {
                        var query = db.quejas
                        .Where(s => s.Nombre == model.Nombre);

                        // https://www.entityframeworktutorial.net/Querying-with-EDM.aspx
                        if (query.Any())
                        {
                            ViewBag.ErrorMessage = "Entry with name already exists";
                            return View();
                        }
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

        [HttpGet]
        public ActionResult Mover(int Id)
        {
            using (examenEntities db = new examenEntities())
            {
                var foundRecord = db.quejas.Find(Id);

                var typeCastRecord = new Estudiante();
                typeCastRecord.Nombre = foundRecord.Nombre;
                typeCastRecord.matricula = foundRecord.matricula;
                typeCastRecord.campus = foundRecord.campus;
                typeCastRecord.queja = foundRecord.queja1;
                typeCastRecord.Fecha = foundRecord.fecha;
                typeCastRecord.Estatus = "Activo";

                db.Estudiantes.Add(typeCastRecord);
                db.quejas.Remove(foundRecord);
                db.SaveChanges();

            }
            return Redirect("/Complain/");
        }




    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projecto.Models;
using Projecto.Models.ViewModels;

namespace Projecto.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            List<StudentsViewModel> lst;
            using (examenEntities db = new examenEntities())
            {

                lst = (from d in db.Estudiantes
                       select new StudentsViewModel
                       {
                           Id = d.Id,
                           Nombre = d.Nombre,
                           Matricula = d.matricula,
                           Campus = d.campus,
                           Queja = d.queja,
                           Fecha = d.Fecha,
                           Estatus = d.Estatus                    
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View(new StudentsViewModel());
        }


        [HttpPost]
        public ActionResult Nuevo(StudentsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (examenEntities db = new examenEntities())
                    {
                        var query = db.Estudiantes
                        .Where(s => s.Nombre == model.Nombre);
                        if (query.Any())
                        {
                            ViewBag.ErrorMessage = "Entry with name already exists";
                            return View();
                        }

                        var oTabla = new Estudiante();
                        oTabla.Nombre = model.Nombre;
                        oTabla.matricula = model.Matricula;
                        oTabla.campus = model.Campus;
                        oTabla.queja = model.Queja;
                        oTabla.Fecha = model.Fecha;
                        oTabla.Estatus = model.Estatus;

                        db.Estudiantes.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/Students/");
                }
                return View();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            StudentsViewModel model = new StudentsViewModel();
            Estudiante oTabla;
            using (examenEntities db = new examenEntities())
            {
                oTabla = db.Estudiantes.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Matricula = oTabla.matricula;
                model.Campus = oTabla.campus;
                model.Queja = oTabla.queja;
                model.Fecha = oTabla.Fecha;
                model.Estatus = oTabla.Estatus;
                model.Id = oTabla.Id;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(StudentsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (examenEntities db = new examenEntities())
                    {
                        var query = db.Estudiantes
                        .Where(s => s.Nombre == model.Nombre);
                        if (query.Any())
                        {
                            ViewBag.ErrorMessage = "Entry with name already exists";
                            return View();
                        }
                        var oTabla = db.Estudiantes.Find(model.Id);
                        oTabla.Nombre = model.Nombre;
                        oTabla.matricula = model.Matricula;
                        oTabla.campus = model.Campus;
                        oTabla.queja = model.Queja;
                        oTabla.Fecha = model.Fecha;
                        oTabla.Estatus =  model.Estatus;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Students/");
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
                var oTabla = db.Estudiantes.Find(Id);
                db.Estudiantes.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/Students/");
        }

    }
}

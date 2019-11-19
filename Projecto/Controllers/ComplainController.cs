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
                           Campus = (Campus)d.campus,
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
                        var oTabla = new queja
                        {
                            Nombre = model.Nombre,
                            matricula = model.Matricula,
                            campus = (int)model.Campus,
                            queja1 = model.Queja,
                            fecha = model.Fecha
                        };

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
                model.Campus = (Campus)oTabla.campus;
                model.Queja = oTabla.queja1;
                model.Fecha = oTabla.fecha;
                model.Id = oTabla.Id;
            }
                return View(model);
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
                        oTabla.campus = (int)model.Campus;
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
        [HttpGet]
        public ActionResult Mover2(int Id)
        {
            using (examenEntities db = new examenEntities())
            {
                var foundRecord = db.quejas.Find(Id);
                var typeCastRecord = new EVA();
                typeCastRecord.Nombre = foundRecord.Nombre;
                typeCastRecord.matricula = foundRecord.matricula;
                typeCastRecord.campus = foundRecord.campus;
                typeCastRecord.queja = foundRecord.queja1;
                typeCastRecord.Fecha = foundRecord.fecha;
                typeCastRecord.Estatus = "Activo";

                db.EVAs.Add(typeCastRecord);
                db.quejas.Remove(foundRecord);
                db.SaveChanges();
            }
            return Redirect("/Complain/");
        }
        [HttpGet]
        public ActionResult Mover3(int Id)
        {
            using (examenEntities db = new examenEntities())
            {
                var foundRecord = db.quejas.Find(Id);
                var typeCastRecord = new Decanato();
                typeCastRecord.Nombre = foundRecord.Nombre;
                typeCastRecord.matricula = foundRecord.matricula;
                typeCastRecord.campus = foundRecord.campus;
                typeCastRecord.queja = foundRecord.queja1;
                typeCastRecord.Fecha = foundRecord.fecha;
                typeCastRecord.Estatus = "Activo";

                db.Decanatoes.Add(typeCastRecord);
                db.quejas.Remove(foundRecord);
                db.SaveChanges();
            }
            return Redirect("/Complain/");
        }
        [HttpGet]
        public ActionResult Mover4(int Id)
        {
            using (examenEntities db = new examenEntities())
            {
                var foundRecord = db.quejas.Find(Id);
                var typeCastRecord = new Horario();
                typeCastRecord.Nombre = foundRecord.Nombre;
                typeCastRecord.matricula = foundRecord.matricula;
                typeCastRecord.campus = foundRecord.campus;
                typeCastRecord.queja = foundRecord.queja1;
                typeCastRecord.Fecha = foundRecord.fecha;
                typeCastRecord.Estatus = "Activo";

                db.Horarios.Add(typeCastRecord);
                db.quejas.Remove(foundRecord);
                db.SaveChanges();
            }
            return Redirect("/Complain/");
        }
        [HttpGet]
        public ActionResult Mover5(int Id)
        {
            using (examenEntities db = new examenEntities())
            {
                var foundRecord = db.quejas.Find(Id);
                var typeCastRecord = new Equipo();
                typeCastRecord.Nombre = foundRecord.Nombre;
                typeCastRecord.matricula = foundRecord.matricula;
                typeCastRecord.campus = foundRecord.campus;
                typeCastRecord.queja = foundRecord.queja1;
                typeCastRecord.Fecha = foundRecord.fecha;
                typeCastRecord.Estatus = "Activo";

                db.Equipoes.Add(typeCastRecord);
                db.quejas.Remove(foundRecord);
                db.SaveChanges();
            }
            return Redirect("/Complain/");
        }
    }
}
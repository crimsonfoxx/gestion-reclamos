using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projecto.Models;
using Projecto.Models.ViewModels;

namespace Projecto.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            List<EquipoViewModel> lst;
            using (examenEntities db = new examenEntities())
            {

                lst = (from d in db.Equipoes
                       select new EquipoViewModel
                       {
                           Id = d.Id,
                           Nombre = d.Nombre,
                           Matricula = d.matricula,
                           Campus = (Campus)d.campus,
                           Queja = d.queja,
                           Fecha = d.Fecha,
                           Estatus = d.Estatus
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Editar(int Id)
        {
            Tabla6ViewModel model = new Tabla6ViewModel();
            using (examenEntities db = new examenEntities())
            {
                var oTabla = db.Equipoes.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Matricula = oTabla.matricula;
                model.Campus = (Campus)oTabla.campus;
                model.Queja = oTabla.queja;
                model.Fecha = oTabla.Fecha;
                model.Estatus = oTabla.Estatus;
                model.Id = oTabla.Id;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(Tabla6ViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (examenEntities db = new examenEntities())
                    {
                        var oTabla = db.Equipoes.Find(model.Id);
                        oTabla.Nombre = model.Nombre;
                        oTabla.matricula = model.Matricula;
                        oTabla.campus = (int)model.Campus;
                        oTabla.queja = model.Queja;
                        oTabla.Fecha = model.Fecha;
                        oTabla.Estatus = model.Estatus;
                        //Enum.GetName(typeof(/*enum estado estudiante*/), model.Estatus) caso de oTabla.Estatus sea string y model.Estatus un enum
                        //Enum.Parse(typeof(/*enum estado estudiante*/), oTabla.Estatus), model.Estatus) caso de oTabla.Estatus sea enum y model.Estatus un string
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Equipo/");
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
                var oTabla = db.Equipoes.Find(Id);
                db.Equipoes.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/Equipo/");
        }

    }
}


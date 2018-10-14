using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcerciseWebAppl.Models;
using ExcerciseWebAppl.Models.DAL;
using PagedList;





namespace ExcerciseWebAppl.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExcerciseRepository interfaceObj;

        public HomeController()
        {
            this.interfaceObj = new ExcerciseRepository(new HarpreetEntities());
        }

        public ActionResult Index(string search, int? page)
        {
            var data = this.interfaceObj.GetExcercises().OrderBy(x => x.ExcerciseName);

            if (!string.IsNullOrEmpty(search))
            {
                return View(data.Where(x => x.ExcerciseName.StartsWith(search) || search == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(data.ToPagedList(page ?? 1, 3));
            }
        }

        public ActionResult Search()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateExcercise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExcercise(Excercise excercise)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    interfaceObj.InsertExcercise(excercise);
                    interfaceObj.Save();
                    //ViewBag.MyMessage("Save done Successfully");
                }
                
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ActionResult Details(int id)
        {
            Excercise e = interfaceObj.GetExcerciseByID(id);
            return View(e);
        }

        public ActionResult Delete(int id)
        {
            Excercise e = interfaceObj.GetExcerciseByID(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult Delete(int id, Excercise e)
        {
            interfaceObj.DeleteExcecise(id);
            interfaceObj.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Excercise e = interfaceObj.GetExcerciseByID(id);
            return View(e);
        }

        public ActionResult Edit(int id, Excercise e)
        {
            interfaceObj.UpdateExcercise(e);
            interfaceObj.Save();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
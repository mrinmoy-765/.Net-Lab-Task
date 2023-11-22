using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new TestDBEntities1();
            var data = db.students.ToList();
            return View(data);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(student s)
        {
            var db = new TestDBEntities1();
            db.students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new TestDBEntities1();
            var ex = (from d in db.students
                      where d.Id == id
                      select d).SingleOrDefault();
            return View(ex);

        }

        [HttpPost]
        public ActionResult Edit(student s)
        {
            var db = new TestDBEntities1();
            var exdata = db.students.Find(s.Id);
         //   exdata.Name = s.Name;
             db.Entry(exdata).CurrentValues.SetValues(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new TestDBEntities1();
            var ex = (from d in db.students
                      where d.Id == id
                      select d).SingleOrDefault();
            return View(ex);
        }


        [HttpPost]
        public ActionResult Delete(student s)
        {
            var db = new TestDBEntities1();
            var ex = (from d in db.students
                      where d.Id == s.Id
                      select d).SingleOrDefault();
            db.students.Remove(ex);
            db.SaveChanges();
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
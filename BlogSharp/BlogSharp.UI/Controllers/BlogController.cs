using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSharp.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(int id)
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delele()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("List");
        }
    }
}
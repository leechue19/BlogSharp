using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSharp.UI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
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
        public ActionResult Add()
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delele()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete()
        {
            return RedirectToAction("List");
        }
    }
}
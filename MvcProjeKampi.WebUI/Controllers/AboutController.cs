using MvcProjeKampi.BusinessLayer.Concrete;
using MvcProjeKampi.DataAccessLayer.EntityFramework;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.WebUI.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = am.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.AboutAddBL(p);
            return RedirectToAction("Index");
        }
    }
}
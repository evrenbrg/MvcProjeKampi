using MvcProjeKampi.BusinessLayer.Concrete;
using MvcProjeKampi.DataAccessLayer.Concrete;
using MvcProjeKampi.DataAccessLayer.EntityFramework;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.WebUI.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        //CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        public ActionResult Index()
        {
          
            var query1 =  c.Category.Count();
            ViewBag.q1 = query1;
            var query2 = c.Heading.Count(x => x.CategoryID == 7);   // Yazılım kat id 7
            ViewBag.q2 = query2;
            var query3 = c.Writer.Count(x => x.WriterName.Contains("a"));
            ViewBag.q3 = query3;
            var query4 = c.Category.Where(
                u => u.CategoryID == c.Heading.GroupBy(
                    x => x.CategoryID).OrderByDescending(
                    x => x.Count()).Select(
                    x => x.Key).FirstOrDefault()).Select(
                x => x.CategoryName)
                    .FirstOrDefault();
            ViewBag.q4 = query4;


            var query5 = c.Category.Count(x => x.CategoryStatus == true) - c.Category.Count(x => x.CategoryStatus == false);
            ViewBag.q5 = query5;

            return View();
        }
    }
}
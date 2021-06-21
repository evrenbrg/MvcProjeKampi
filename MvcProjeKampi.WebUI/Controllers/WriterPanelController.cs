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
    public class WriterPanelController : Controller
    {
        Context context = new Context();
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string param)
        {
            param = (string)Session["WriterEmail"];
            var writerid = context.Writer.Where(w => w.WriterMail == param).Select(x => x.WriterID).FirstOrDefault();
            var result = headingManager.GetHeadingByWriter(writerid);
            return View(result);
        }

        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> valuecategory = (from c in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.valuecategory = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdd(Heading heading)
        {
            string deger = (string)Session["WriterEmail"];
            var writeridhead = context.Writer.Where(w => w.WriterMail == deger).Select(x => x.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridhead;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");

        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valuecategory = (from c in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryID.ToString()

                                                  }).ToList();

            ViewBag.valuecategory = valuecategory;
            var result = headingManager.GetById(id);
            return View(result);
        }


        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var result = headingManager.GetById(id);
            if (result.HeadingStatus == true)
            {
                result.HeadingStatus = false;
            }
            else
            {
                result.HeadingStatus = true;
            }
            headingManager.HeadingDelete(result);
            return RedirectToAction("MyHeading");
        }


        public ActionResult AllHeading()
        {
            var headings = headingManager.GetList();
            return View(headings);
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}
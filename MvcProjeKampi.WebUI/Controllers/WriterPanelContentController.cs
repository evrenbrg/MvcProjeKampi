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
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string param)
        {
            param = (string)Session["WriterEmail"];
            var writeridinfo = context.Writer.Where(w => w.WriterMail == param).Select(x => x.WriterID).FirstOrDefault();
            var contentvalues = contentManager.GetListByWriter(writeridinfo);
            return View(contentvalues);

        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }


        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterEmail"];
            var writeridinfo = context.Writer.Where(w => w.WriterMail == mail).Select(x => x.WriterID).FirstOrDefault();
            content.ContenDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writeridinfo;
            content.ContentStatus = true;
            contentManager.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }
    }
}
using MvcProjeKampi.BusinessLayer.Concrete;
using MvcProjeKampi.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var result = headingManager.GetList();
            return View(result);
        }
        // GET: Default
        public PartialViewResult Index(int id=0)
        {
            var result = contentManager.GetListByHeadingId(id);
            return PartialView(result);
        }
    }
}
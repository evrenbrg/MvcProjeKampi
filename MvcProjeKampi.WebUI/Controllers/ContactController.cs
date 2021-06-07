using MvcProjeKampi.BusinessLayer.Concrete;
using MvcProjeKampi.BusinessLayer.ValidationRules;
using MvcProjeKampi.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.WebUI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult MenuPartial()
        {
            return PartialView();
        }
    }
}
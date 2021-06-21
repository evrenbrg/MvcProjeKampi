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
        MessageManager mm = new MessageManager(new EfMessageDal());
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
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetListSendbox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mm.GetListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = mm.GetListInbox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = mm.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
    }
}
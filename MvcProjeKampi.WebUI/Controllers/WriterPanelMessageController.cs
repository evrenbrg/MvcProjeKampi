using FluentValidation.Results;
using MvcProjeKampi.BusinessLayer.Concrete;
using MvcProjeKampi.BusinessLayer.ValidationRules;
using MvcProjeKampi.DataAccessLayer.EntityFramework;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.WebUI.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: WriterPanelMessage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WriterInbox()
        {
            var MessageList = messageManager.GetListInbox();
            return View(MessageList);
        }

        public ActionResult WriterSendBox()
        {
            var result = messageManager.GetListSendbox();
            return View(result);
        }

        public PartialViewResult MessagePartial()
        {
            return PartialView();
        }

        public ActionResult GetWriterMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message, string button)
        {
            ValidationResult validationResult = messageValidator.Validate(message);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.SenderMail = "gizemyıldız@gmail.om";
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAddBL(message);
                    return RedirectToAction("WriterSendbox");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (button == "draft")
            {
                if (validationResult.IsValid)
                {

                    message.SenderMail = "gizemyıldız@gmail.om";
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAddBL(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "cancel")
            {
                return RedirectToAction("AddMessage");
            }

            return View();
        }
    }
}
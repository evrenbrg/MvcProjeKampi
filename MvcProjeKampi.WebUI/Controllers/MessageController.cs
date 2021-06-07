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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mc = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messagelist = mc.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messageList = mc.GetListSendbox();
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message model, string button)
        {
            ValidationResult results = new ValidationResult();
            if (button == "draft")
            {

                results = messageValidator.Validate(model);
                if (results.IsValid)
                {
                    model.MessageDate = DateTime.Now;
                    model.SenderMail = "evren@evren.com";
                    model.isDraft = true;
                    mc.MessageAddBL(model);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "save")
            {
                results = messageValidator.Validate(model);
                if (results.IsValid)
                {
                    model.MessageDate = DateTime.Now;
                    model.SenderMail = "admin@gmail.com";
                    model.isDraft = false;
                    mc.MessageAddBL(model);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }
    }
}
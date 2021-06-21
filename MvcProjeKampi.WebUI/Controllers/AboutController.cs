using Business.FluentValidation;
using FluentValidation.Results;
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
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            AboutValidator aboutValidator = new AboutValidator();
            ValidationResult validationResult = aboutValidator.Validate(about);
            if (validationResult.IsValid)
            {
                aboutManager.AboutAddBL(about);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult UpdateAbout(int id)
        {
            var result = aboutManager.GetById(id);
            if (result.AboutStatus == true)
            {
                result.AboutStatus = false;
            }
            else
            {
                result.AboutStatus = true;
            }
            aboutManager.AboutUpdate(result);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}
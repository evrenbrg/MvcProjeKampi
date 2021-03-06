using MvcProjeKampi.BusinessLayer.Abstract;
using MvcProjeKampi.BusinessLayer.Concrete;
using MvcProjeKampi.DataAccessLayer.Concrete;
using MvcProjeKampi.DataAccessLayer.EntityFramework;
using MvcProjeKampi.EntityLayer.Concrete;
using MvcProjeKampi.EntityLayer.Dto;
using MvcProjeKampi.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));

        Context context = new Context();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {

            if (authService.Login(loginDto))
            {
                FormsAuthentication.SetAuthCookie(loginDto.AdminUserName, false);
                Session["AdminUserName"] = loginDto.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

        public ActionResult WriterLogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Heading", "Default");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        /*
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var writerinfo = context.Writer.FirstOrDefault(w => w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
            if (writerinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterMail, false);
                Session["WriterEmail"] = writerinfo.WriterMail;
                return RedirectToAction("MyContent","WriterPanelContent");
            }

            return RedirectToAction("WriterLogin");
        }
        */
        [HttpPost]
        public ActionResult WriterLogin(WriterLoginDto writerLoginDto)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6Lc9zzgbAAAAAFBGD3Gb201yvNAX4Tb5LAzlqy0d";
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.WriterLogin(writerLoginDto) && captchaResponse.Success)
            {
                FormsAuthentication.SetAuthCookie(writerLoginDto.WriterEmail, false);
                Session["WriterEmail"] = writerLoginDto.WriterEmail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return RedirectToAction("WriterLogin");
            }

        }
    }
}
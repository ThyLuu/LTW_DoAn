using LoginWeb_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace LoginWeb_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string fullname, string email, string username, string password)
        {
            if (Request.Form.Count > 0)
            {
                UserDataContext dtb = new UserDataContext();
                User us = new User();
                us.Fullname = fullname;
                us.Email = email;
                us.Username = username;
                us.Password = password;
                dtb.Users.InsertOnSubmit(us);
                dtb.SubmitChanges();
                return RedirectToAction("LogIn");
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password, string message)
        {
            UserDataContext dtb = new UserDataContext();
            TempData["alertMessage"] = message;
            var us = dtb.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (us != null)
            {
                Session["Username"] = us.Username;
                return RedirectToAction("Space", "Space");
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Chưa có tài khoản, vui lòng đăng kí !!'); </script>");
                return View("SignUp");
            }
        }

        public ActionResult LogOut()
        {
            return View();
        }
    }
}
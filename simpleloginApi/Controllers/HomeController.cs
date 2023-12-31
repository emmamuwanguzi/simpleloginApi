﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using simpleloginApi.Models;

namespace simpleloginApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LoginModel obj = new LoginModel();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(LoginModel objuserlogin)
        {
            var display = Userloginvalues().Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();
            if (display != null)
            {
                ViewBag.Status = "CORRECT UserName and Password";
            }
            else
            {
                ViewBag.Status = "INCORRECT UserName or Password";
            }
            return View(objuserlogin);
        }
        public List<LoginModel> Userloginvalues()
        {
            List<LoginModel> objModel = new List<LoginModel>();
            objModel.Add(new LoginModel { UserName = "emma", UserPassword = "password1" });
            objModel.Add(new LoginModel { UserName = "user2", UserPassword = "password2" });
            
            return objModel;
        }
    }
}

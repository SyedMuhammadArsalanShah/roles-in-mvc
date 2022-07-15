using RolePanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RolePanel.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(usert model)
        {

            using (var context = new srfEntities())
            {
                context.userts.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Members model)
        {

            using (var context = new srfEntities())
            {
                bool isvalid = context.userts.Any(x => x.userName == model.userName && x.Pass == model.Pass);

                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.userName, false);
                    return RedirectToAction("Index", "students");
                }
                ModelState.AddModelError("", "Invalid user name or password");
                return View();
            }
        }


            public ActionResult Dashboard()
            {
                return View();
            }

        public ActionResult  Logout()
        {
            FormsAuthentication.SignOut();
           return RedirectToAction("Login");
        }




    }
    } 
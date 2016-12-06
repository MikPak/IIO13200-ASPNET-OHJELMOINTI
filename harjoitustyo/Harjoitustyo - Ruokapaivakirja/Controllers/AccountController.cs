using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harjoitustyo___Ruokapaivakirja.Models;

namespace Harjoitustyo___Ruokapaivakirja.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("LoggedIn");
            }
            else 
            {
               return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Register() 
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (Session["UserID"] == null)
            {
                if (ModelState.IsValid)
                {
                    using (OurDbContext db = new OurDbContext())
                    {
                        db.userAccount.Add(account);
                        //db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                        db.SaveChanges();
                        //int id = account.UserID;
                        //Debug.WriteLine("added user ID: " + id);
                    }
                    ModelState.Clear();
                    TempData["registeredMessage"] = account.Username + " rekisteröity.";
                    return RedirectToAction("Index", "Home");
                } else {
                    return RedirectToAction("Index", "Home");
                }
            }
            else 
            {
                return RedirectToAction("Index", "Account");
            }
        }

        // Login
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user) 
        {
            using(OurDbContext db = new OurDbContext()) 
            {
                var usr = db.userAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Käyttäjätunnus tai salasana virheellinen.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)
            {
                /*
                using (OurDbContext db = new OurDbContext())
                {
                    return View(db.userAccount.ToList());
                }
                */
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
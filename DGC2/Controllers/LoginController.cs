using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DGC2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: LoginSubCustomer
        //[HttpGet]
        //public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        //{
        //    return View();
        //}

    
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SubCustomer p)
        {
            Context c = new Context();
            var subcustomerInfo = c.SubCustomers.FirstOrDefault(x => x.SubCustomerUsername == p.SubCustomerUsername && x.SubCustomerPassword == p.SubCustomerPassword);
            if(subcustomerInfo !=null)
            {
                FormsAuthentication.SetAuthCookie(subcustomerInfo.SubCustomerUsername, false);
                Session["SubCustomerUsername"] = subcustomerInfo.SubCustomerUsername;
                return RedirectToAction("Index", "SubCustomer");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult CustomerIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerIndex(Customer p)
        {
            Context c = new Context();
            var customerInfo = c.Customers.FirstOrDefault(x => x.CustomerUsername == p.CustomerUsername && x.CustomerPassword == p.CustomerPassword);
            if (customerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(customerInfo.CustomerUsername, false);
                Session["CustomerUsername"] = customerInfo.CustomerUsername;
                return RedirectToAction("Index", "CustomerAppAccept");
            }
            else
            {
                return RedirectToAction("CustomerIndex");
            }

        }


        //Admin
        [HttpGet]
        public ActionResult Admin()
        {
           
                return View();
            
        }
        [HttpPost]
        public ActionResult Admin(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUsername, false);
                Session["AdminUsername"] = adminuserinfo.AdminUsername;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Admin","Login");
            }
            
        }

        //Admin
        [HttpGet]
        public ActionResult Chief()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Chief(Chief p)
        {
            Context c = new Context();
            var adminuserinfo = c.Chiefs.FirstOrDefault(x => x.ChiefUsername == p.ChiefUsername && x.ChiefPassword == p.ChiefPassword);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.ChiefUsername, false);
                Session["ChiefUsername"] = adminuserinfo.ChiefUsername;
                return RedirectToAction("Index", "Chief");
            }
            else
            {
                return RedirectToAction("Chief", "Login");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Login");
        }

    }
}
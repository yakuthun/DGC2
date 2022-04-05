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
    public class LoginController : Controller
    {
        // GET: LoginSubCustomer
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
    }
}
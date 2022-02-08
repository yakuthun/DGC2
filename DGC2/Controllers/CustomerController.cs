using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DGC2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerManager cm = new CustomerManager(new EfCustomerDal());
        public ActionResult Index()
        {
            var customervalues = cm.GetList();
            return View(customervalues);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer p)
        {
            cm.CustomerAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customervalue = cm.GetByID(id);
            return View(customervalue);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer p)
        {
            cm.CustomerUpdate(p);
            return RedirectToAction("Index");
        }

    }
}
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        UserManager um = new UserManager(new EfUserDal());

      
        public ActionResult Index(User p)
        {
            Context c = new Context();
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
            p.CustomerStartDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CustomerFinishDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
        public ActionResult DeleteCustomer(int id)
        {//Güncelleme işlemi
            //customer delete kısmına git
            var customervalue = cm.GetByID(id);
            customervalue.CustomerStatus = false;
            cm.CustomerDelete(customervalue);
            return RedirectToAction("Index");
        }
        public ActionResult UserList(int id)
        {
             var calendarvalues = um.GetList();
            TempData["CustomerID"] = id;
            ViewBag.customerid = id;
       
            return View(calendarvalues);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            ViewBag.t = TempData["CustomerID"];
            ViewBag.z = "asdasd";
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            
            
            um.UserAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            ViewBag.t = TempData["CustomerID"];
            var uservalue = um.GetByID(id);
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult EditUser(User p)
        {
            um.UserUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int id)
        {//Güncelleme işlemi
            //customer delete kısmına git
            var uservalue = um.GetByID(id);
            um.UserDelete(uservalue);
            return RedirectToAction("Index");
        }
    }
}
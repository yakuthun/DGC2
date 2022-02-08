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
    public class SubCustomerController : Controller
    {
        // GET: SubCustomer
        SubCustomerManager scm = new SubCustomerManager(new EfSubCustomerDal());
        public ActionResult Index()
        {
            var Subcustomervalues = scm.GetList();
            return View(Subcustomervalues);
        }
        [HttpGet]
        public ActionResult AddDriver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDriver(Driver p)
        {
            scm.DriverAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditDriver(int id)
        {
            var drivervalue = scm.GetByID(id);
            return View(drivervalue);
        }
        [HttpPost]
        public ActionResult EditDriver(Driver p)
        {
            scm.DriverUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDriver(int id)
        {
            var drivervalue = scm.GetByID(id);
            drivervalue.DriverStatus = false;
            scm.DriverUpdate(drivervalue);
            return RedirectToAction("Index");
        }
    }
}
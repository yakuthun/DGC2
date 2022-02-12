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
        AppointmentManager apm = new AppointmentManager(new EfAppointmentDal());
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
        
        public ActionResult WaitingListAppoinment()
        {
            var listappoinment = apm.GetList();
            return View(listappoinment);
            
        }
        public ActionResult AskChangeList()
        {
            var listappoinment = apm.GetList();
            return View(listappoinment);

        }

        [HttpGet]
        public ActionResult EditAskChange(int id)
        {


            var showappoinment = apm.GetBySubCustomer();
          
            return View(showappoinment);
        }
        [HttpPost]
        public ActionResult EditAskChange(Appointment p)
        {

            apm.AppointmentUpdate(p);
            
            return RedirectToAction("AppliedAppoinment");
        }

        public ActionResult CanceledListAppoinment()
        {
            var canceledappoinment = apm.GetList();
            return View(canceledappoinment);

        }
        public ActionResult AppliedListAppoinment()
        {
            var appliedappoinment = apm.GetList();
            return View(appliedappoinment);

        }
        public ActionResult AskChange(int id)
        {
            var appvalue = apm.GetByID(id);
            appvalue.AppointmentTrackStatus = 20;
            apm.AppointmentUpdate(appvalue);
            return RedirectToAction("AppliedListAppoinment");
        }

        [HttpGet]
        public  ActionResult AddAppoinment()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult AddAppoinment(Appointment p)
        {
            apm.AppointmentAdd(p);
            p.AppointmentTrackStatus = 1;
            //p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //p.AppFinishDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //p.RealAppStartDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //p.RealAppFinishDate = DateTime.Parse(DateTime.Now.ToShortDateString());


            return RedirectToAction("Index");
        }
    }
}
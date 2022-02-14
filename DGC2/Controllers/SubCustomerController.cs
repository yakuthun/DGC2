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


            var askvalue = apm.GetByID(id);
            return View(askvalue);
        }
        [HttpPost]
        public ActionResult EditAskChange(Appointment p)
        {


            if (p.AppointmentStatus == false)
                    p.AppointmentStatus = true;
            if (p.AppointmentTrackStatus == 2)
                    p.AppointmentTrackStatus = 20;

            p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            apm.AppointmentAdd(p);
            return RedirectToAction("AppliedListAppoinment");
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


            appvalue.AppointmentStatus = false;
            appvalue.AppointmentTrackStatus = 20;
            apm.AppointmentUpdate(appvalue);
            return RedirectToAction("AppliedListAppoinment");
        }
        public ActionResult CancelChange(int id)
        {
            var appvalue = apm.GetByID(id);
            appvalue.AppointmentTrackStatus = 3;
            apm.AppointmentUpdate(appvalue);
            return RedirectToAction("AppliedListAppoinment");
        }
        public ActionResult CancelChangeList()
        {
            var cancelChangeList = apm.GetList();
            return View(cancelChangeList);
        }

        [HttpGet]
        public ActionResult AddAppoinment()
        {
            
            return View();
        }



        [HttpPost]
        public ActionResult AddAppoinment(Appointment p)
        {

           
            
            if (p.AppointmentUCode == null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);

                p.AppointmentUCode = finalString;
            }


         


            if (p.AppointmentTrackStatus == 0)
            {
                p.AppointmentTrackStatus = 1;
                
               
            }
            p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            //string appimage = "";
            //p.AppointmentComment = appimage;
            apm.AppointmentAdd(p);
           // p.AppStartDate = DateTime.TryParse(DateTime.Now.ToShortDateString());
            
            //p.AppFinishDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //p.RealAppStartDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //p.RealAppFinishDate = DateTime.Parse(DateTime.Now.ToShortDateString());


            return RedirectToAction("Index");
        }
    }
}
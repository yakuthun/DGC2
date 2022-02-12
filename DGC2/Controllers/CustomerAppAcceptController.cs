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
    public class CustomerAppAcceptController : Controller
    {   
        // GET: CustomerSubAppAccept
        AppointmentManager am = new AppointmentManager(new EfAppointmentDal());



        public ActionResult Appointments()
        {


            var appointmentvalue = am.GetBySubCustomer();
            return View(appointmentvalue);
        }
        public ActionResult CanceledAppoinments()
        {
            var appointmentvalue = am.GetBySubCustomer();
            return View(appointmentvalue);
        }
        public ActionResult WantsChangeAppoinments()
        {
            var appointmentvalue = am.GetBySubCustomer();
            return View(appointmentvalue);
        }
        public ActionResult AccesChangeAppointment(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 2;
            am.AppointmentUpdate(appvalue);
            return RedirectToAction("Appointments");
        }
        public ActionResult ApplyAppointment(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 4;
            am.AppointmentUpdate(appvalue);
            return RedirectToAction("Appointments");
        }
        public ActionResult CancelAppointment(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 7;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("CanceledAppoinments");
        }

       

        public ActionResult WaitingAppointments()
        {
            var waitingvalue = am.GetBySubCustomer();
            return View(waitingvalue);
        }
    }
}
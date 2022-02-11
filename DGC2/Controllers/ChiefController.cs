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
    public class ChiefController : Controller
    {
        // GET: Chief
        AppointmentManager am = new AppointmentManager(new EfAppointmentDal());

        public ActionResult Index()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }


        public ActionResult DeleteAppointment(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentStatus = false;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("PendingAppointments");
        }
        public ActionResult ApplyAppointment(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentStatus = true;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("CanceledAppointments");
        }


        [HttpGet]
        public ActionResult EditAppointment(int id)
        {
            var appvalues = am.GetByID(id);
            return View(appvalues);
        }
        [HttpPost]
        public ActionResult EditAppointment(Appointment p)
        {
            am.AppointmentUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult PendingAppointments()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }
        public ActionResult CanceledAppointments()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }
    }

    //
}
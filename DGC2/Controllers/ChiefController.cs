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
            return RedirectToAction("Index");
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
        // 5 - GELMEYEN
        public ActionResult NotComing()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }
        // 8- DEPOYA GELEN
        public ActionResult InComingApp(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 8;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("Index");
        }
        // 9- İNDİRİLİYOR
        public ActionResult Downloaded(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 9;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("Index");
        }
        // 9 - GELDİ VE İNDİRİLDİ
        public ActionResult InComingAndDownloading()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }

        // 9 - TAMAMLANAN
        public ActionResult Completed()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }
    }

    //
}
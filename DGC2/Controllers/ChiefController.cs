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
    public class ChiefController : Controller
    {
        // GET: Chief
        AppointmentManager am = new AppointmentManager(new EfAppointmentDal());
        
        public ActionResult ClosePopUp()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);

        }
      
        public ActionResult Finished()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }

        public ActionResult NotComings()
        {
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }


        [HttpGet]
        public ActionResult EditAppointment(int id, Appointment p)
        {
            ViewBag.d = id;
            var appvalues = am.GetByID(id);
            return View(appvalues);
        }
        [HttpPost]
        public ActionResult EditAppointment(Appointment p,int id)
        {
            

           // p.InComingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            p.AppFinishDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            am.AppointmentUpdate(p);
            if (p.AppointmentTrackStatus == 9)
            {
                var appvalue = am.GetByID(id);
                appvalue.AppointmentTrackStatus = 10;
                am.AppointmentDelete(appvalue);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("EditAppointment", "Chief", p.AppointmentID);
            }

            if (p.AppointmentTrackStatus == 4 || p.AppointmentTrackStatus == 8 || p.AppointmentTrackStatus == 9)
            {
                return RedirectToAction("EditAppointment", "Chief", p.AppointmentID);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            //return RedirectToAction("Index");
            
        }

     
        public PartialViewResult EditAppPartial()
        {
            return PartialView();
        }

        //[HttpGet]
        //public PartialViewResult EditAppPartial(int id)
        //{
        //    var appvalues = am.GetByID(id);
        //    return PartialView(appvalues);
        //}
        //[HttpPost]
        //public ActionResult EditAppPartial(Appointment p)
        //{
        //    am.AppointmentUpdate(p);
        //    return RedirectToAction("Index");
        //}


        //------------------------------------------------------------


        // 5 - GELMEYEN
        public ActionResult NotComing(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 5;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("Index");
        }
        // 8- GELDİ

        public ActionResult InComingApp(int id,Appointment p)
        {
           
            var appvalue = am.GetByID(id);
            appvalue.InComingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

            appvalue.AppointmentTrackStatus = 8;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("Index");
        }
        // 9- İNDİRİLİYOR
        public ActionResult Downloaded(int id, Appointment p)
        {
            var appvalue = am.GetByID(id);
            appvalue.DownloadedDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

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

        // 10 - TAMAMLANAN
        public ActionResult Completed(int id, Appointment p)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppFinishDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            appvalue.AppointmentTrackStatus = 10;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("Index");
        }
    }

    //
}
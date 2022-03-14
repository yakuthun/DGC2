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
        Context c = new Context();
        public ActionResult Index()
        {
           
            var deger3 = c.Slices.Where(c => c.SliceStatus == true).Select(x => x.SlicesID).FirstOrDefault();
            ViewBag.d3 = deger3;
            var deger4 = c.Calendars.Where(c => c.Slice.SliceStatus == true).Max(x => x.CLSlice);
            ViewBag.d5 = deger4;
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

       

        [HttpPost]
        public ActionResult SaveCapture(string data,Appointment p,int id)
        {
            string fileName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");
            byte[] imageBytes = Convert.FromBase64String(data.Split(',')[1]);
            string filePath = Server.MapPath(string.Format("~/Captures/{0}.jpg", fileName));
            System.IO.File.WriteAllBytes(filePath, imageBytes);

            var appvalue = am.GetByID(id);
            appvalue.AppointmentImage = filePath;
            am.AppointmentDelete(appvalue);
            

            return RedirectToAction("EditAppointment", "Chief", new { id = id });
        }



        [HttpGet]
        public ActionResult EditAppointment(int id, Appointment p)
        {
            ViewBag.d = id;
           
           
            var appvalues = am.GetByID(id);
            ViewBag.trackstatus = appvalues.AppointmentTrackStatus;
            ViewBag.imagecontent = appvalues.AppointmentImage;
            return View(appvalues);

        }
        [HttpPost]
        public ActionResult EditAppointment(Appointment p,int id)
        {

            
            //p.AppointmentImage = "xxx";

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
            return RedirectToAction("EditAppointment", "Chief", new { id = id });
        }
        // 9- İNDİRİLİYOR
        public ActionResult Downloaded(int id, Appointment p)
        {
            var appvalue = am.GetByID(id);
            appvalue.DownloadedDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

            appvalue.AppointmentTrackStatus = 9;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("EditAppointment", "Chief", new { id = id });
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
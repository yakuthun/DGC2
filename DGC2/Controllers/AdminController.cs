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
    [Authorize(Roles = "A")]
    public class AdminController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        AppointmentManager apm = new AppointmentManager(new EfAppointmentDal());
        CalendarManager cl = new CalendarManager(new EfCalendarDal());
        CustomerSubManager sbm = new CustomerSubManager(new EfCustomerAddSubDal());
        SliceManager sm = new SliceManager(new EfSliceDal());

        
       

        public ActionResult Index()
        {
            var adminvalues = am.GetList();
            return View(adminvalues);
        }

        public ActionResult Dashboard()
        {
            var adminvalues = am.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = am.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteAdmin(int id)
        {
            var adminvalue = am.GetByID(id);
            am.AdminDelete(adminvalue);
            return RedirectToAction("Index");
        }

        public ActionResult SubCustomerList()
        {
            var sbmvalues = sbm.GetList();
            return View(sbmvalues);
        }

        public ActionResult WaitingApp()
        {
            var apmvalues = apm.GetList();
            return View(apmvalues);
        }

        // 4 - İptal Onaylandı
        public ActionResult Completed(int id)
        {
            var appvalue = apm.GetByID(id);
            appvalue.AppointmentTrackStatus = 4;
            apm.AppointmentDelete(appvalue);
            return RedirectToAction("WaitingApp","Admin");
        }

        // 4 - İptal Onaylandı
        public ActionResult Canceled(int id)
        {
            var appvalue = apm.GetByID(id);
            appvalue.AppointmentTrackStatus = 11;
            apm.AppointmentDelete(appvalue);
            return RedirectToAction("WaitingApp", "Admin");
        }

        public ActionResult CalendarList(int id)
        {
            var deger1 = c.Slices.Count();
            if (deger1 == 0)
            {

            }
            else
            {
                //var toplamdilim = c.Calendars.Where(c => c.CalendarID == id).Max(x => x.CLSlice);
                //ViewBag.d5 = toplamdilim;
            }
          



            var onemli = cl.GetListByID(id);
            TempData["SliceID"] = id;
            return View(onemli);
        }

        [HttpGet]
        public ActionResult AddCalendar()
        {
            ViewBag.t  = TempData["SliceID"];
            return View();
        }
        [HttpPost]
        public ActionResult AddCalendar(Calendar p)
        {

      
            p.CLStartDate = p.CLStartHour;

            var amount = p.CLAmount;
            var tolerance = p.CLTolerance;
            var sum = amount * tolerance / 100;
            p.CLSumTolerance = sum + amount;

            p.CLStartDate = DateTime.Now.ToString();
            cl.CalendarAdd(p);
            var alcalendar = cl.GetByID(p.CalendarID);
            var today = DateTime.Now;

            for (int i = 1; i <= 6; i++)
            {
                //var today = DateTime.Now.AddDays(i - 1);
                var tomorrow = today;
                tomorrow = tomorrow.AddDays(i);
               
                    p.CLStartDate = tomorrow.ToString();
                    cl.CalendarAdd(alcalendar);
                
            }

            //cl.CalendarAdd(p);
            return RedirectToAction("SliceList", "Admin");
        }
        [HttpGet]
        public ActionResult EditCalendar(int id)
        {
            ViewBag.t = TempData["SliceID"];
            var calendarvalue = cl.GetByID(id);
            return View(calendarvalue);
        }
        [HttpPost]
        public ActionResult EditCalendar(Calendar p)
        {
            var deger3 = c.Slices.Where(c => c.SliceStatus == true).Select(x => x.SlicesID).FirstOrDefault();
            ViewBag.d3 = deger3;

            var curt = cl.GetList().Where(c => c.SlicesID == deger3).OrderByDescending(c => c.CLStartDate);


            foreach (var item in curt)
            {

            }
            cl.CalendarUpdate(p);
            return RedirectToAction("SliceList","Admin");
        }

        Context c = new Context();
        public ActionResult PassiveSlice(int id)
        {
         
            var deger3 = c.Slices.Where(c => c.SliceStatus == true).Select(x => x.SlicesID).FirstOrDefault();
            ViewBag.d3 = deger3;
            

            var appvalue = sm.GetByID(id);
            appvalue.SliceStatus = true;

            var icveri = c.Slices.Count();
            if (icveri == 1)
            {
                appvalue.SliceStatus = true;
            }
            else
            {
                var deger4 = c.Slices.Where(c => c.SliceStatus == true).Select(x => x.SlicesID).FirstOrDefault();
                var passiveslice = sm.GetByID(deger4);
                passiveslice.SliceStatus = false;

            }



            sm.SliceUpdate(appvalue);
            return RedirectToAction("SliceList", "Admin");
        }
      

        public ActionResult SliceList()
        {
            Context c = new Context();
            var deger1 = c.Slices.Count().ToString();
            ViewBag.d1 = deger1;

            var calendarvalues = sm.GetList();
            return View(calendarvalues);
        }

        [HttpGet]
        public ActionResult AddSlice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlice(Slice p)
        {
           
            sm.SliceAdd(p);

            return RedirectToAction("SliceList", "Admin");
        }

    }
}
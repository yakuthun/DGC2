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
    public class AdminController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        AppointmentManager apm = new AppointmentManager(new EfAppointmentDal());

        CustomerSubManager sbm = new CustomerSubManager(new EfCustomerAddSubDal());
       
        public ActionResult Index()
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
    }
}
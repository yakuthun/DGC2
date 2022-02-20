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
        CustomerSubManager csm = new CustomerSubManager(new EfCustomerAddSubDal());
        Context c = new Context();


        public ActionResult Appointments()
        {


            var appointmentvalue = am.GetBySubCustomer();
            return View(appointmentvalue);
        }
        public ActionResult SubCustomerList()
        {
            var ssubcustomervalue = csm.GetList();
            return View(ssubcustomervalue);
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
            ViewBag.d = appvalue.AppointmentID;
            appvalue.AppointmentTrackStatus = 7;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("CanceledAppoinments");
        }

        public ActionResult RefuseChangeAppointment(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 4;
            am.AppointmentDelete(appvalue);
            return RedirectToAction("Appointments");
        }
        public ActionResult CancelChangedAppointment(int id)
        {
            var stats = am.GetByID(id).AppointmentUCode;
            var asdd = am.GetByIDForChange(false, stats);
            var dsaa = am.GetByIDForChange(true, stats);
            asdd.AppointmentTrackStatus = 4;
            am.AppointmentUpdate(asdd);
            am.AppointmentCopyDelete(dsaa);
            return RedirectToAction("Appointments");
        }
        public ActionResult ApplyChangedAppointment(Appointment p, int id)
        {
            var stat = am.GetByID(id).AppointmentUCode;
            var asd = am.GetByIDForChange(true, stat);
            var dsa = am.GetByIDForChange(false, stat);
            asd.AppointmentTrackStatus = 4;
            am.AppointmentUpdate(asd);
            am.AppointmentCopyDelete(dsa);
            return RedirectToAction("Appointments");
        }
        public ActionResult ThrowToCancelAppointment(int id)
        {
            var stats = am.GetByID(id).AppointmentUCode;
            var asdd = am.GetByIDForChange(false, stats);
            var dsaa = am.GetByIDForChange(true, stats);
            asdd.AppointmentTrackStatus = 11;
            am.AppointmentUpdate(asdd);
            am.AppointmentCopyDelete(dsaa);
            return RedirectToAction("Appointments");
        }

        public ActionResult WaitingAppointments()
        {
            var waitingvalue = am.GetBySubCustomer();
            return View(waitingvalue);
        }
        public ActionResult CanceledAfterChangedAppointments()
        {
            var waitingvalue = am.GetBySubCustomer();
            return View(waitingvalue);
        }
        public ActionResult AppliedWantsCancelAppointments()
        {
            var appwcgvalue = am.GetBySubCustomer();
            return View(appwcgvalue);
        }
        public ActionResult YesCancel(int id)
        {
            var yescancel = am.GetByID(id);
            yescancel.AppointmentTrackStatus = 11;
            am.AppointmentUpdate(yescancel);
            return RedirectToAction("Appointments");
        }
        public ActionResult NoCancel(int id)
        {
            var nocancel = am.GetByID(id);
            nocancel.AppointmentTrackStatus = 6;
            am.AppointmentUpdate(nocancel);
            return RedirectToAction("Appointments");
        }

        // TEDARİKÇİ EKLEME 

        public ActionResult AddSubCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCustomer(SubCustomer p)
        {
            csm.SubCustomerAdd(p);
            return RedirectToAction("SubCustomerList");
        }
        [HttpGet]
        public ActionResult EditSubCustomer(int id)
        {
            var subcustomervalue = csm.GetByID(id);
            return View(subcustomervalue);
        }
        [HttpPost]
        public ActionResult EditSubCustomer(SubCustomer p)
        {
            csm.SubCustomerUpdate(p);
            return RedirectToAction("SubCustomerList");
        }

        public ActionResult DeleteSubCustomer(int id)
        {
            var subcustomervalue = csm.GetByID(id);
            subcustomervalue.SubCustomerStatus = false;
            csm.SubCustomerDelete(subcustomervalue);
            return RedirectToAction("SubCustomerList");
        }

        // TEDARİKÇİ EKLEME
        [HttpGet]
        public ActionResult SeeTheAppointment(int id)
        {
            ViewBag.a = id;
            var appoinmentid = am.GetByID(id);
            return View(appoinmentid);
        }
        [HttpPost]
        public ActionResult SeeTheAppointment(Appointment p)
        {
            am.AppointmentUpdate(p);
            return RedirectToAction("SubCustomerList");
        }
    }
}
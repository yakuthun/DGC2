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
        CalendarManager cm = new CalendarManager(new EfCalendarDal());
        SubCustomerManager scm = new SubCustomerManager(new EfSubCustomerDal());
        UserManager um = new UserManager(new EfUserDal());
        Context c = new Context();
        [Authorize]
        public ActionResult Index(string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();

            //var graphicresult = apm.GetList().Where(x=>x.SubCustomerID == subCustomerInfo);

            var arrayOfValues = csm.GetList();
            ViewBag.arrayOfValues = arrayOfValues;
            var graphicvalue = am.GetBySubCustomer(subCustomerInfo);
            
            return View(graphicvalue);   
        }
        public ActionResult Appointments(string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();

            //var graphicresult = apm.GetList().Where(x=>x.SubCustomerID == subCustomerInfo);
            var appointmentvalue = am.GetBySubCustomer(subCustomerInfo);

            
            return View(appointmentvalue);
        }
        public ActionResult SubCustomerList(string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();


            var ssubcustomervalue = scm.GetListByID(subCustomerInfo);
            return View(ssubcustomervalue);
        }
        public ActionResult CanceledAppoinments(string p)

        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();

            //var graphicresult = apm.GetList().Where(x=>x.SubCustomerID == subCustomerInfo);
            var appointmentvalue = am.GetBySubCustomer(subCustomerInfo);
            
            return View(appointmentvalue);
        }
        public ActionResult WantsChangeAppoinments(string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.SubCustomers.Where(x => x.SubCustomerUsername == p).Select(x => x.SubCustomerID).FirstOrDefault();

            //var graphicresult = apm.GetList().Where(x=>x.SubCustomerID == subCustomerInfo);
            var appointmentvalue = am.GetBySubCustomer(subCustomerInfo);
            
            return View(appointmentvalue);
        }
        public ActionResult AccesChangeAppointment(int id)
        {
            var appvalue = am.GetByID(id);
            appvalue.AppointmentTrackStatus = 2;
            am.AppointmentUpdate(appvalue);
            return RedirectToAction("Appointments");
        }

        public ActionResult FinishedAppointments(string p)
        {

            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();

            //var graphicresult = apm.GetList().Where(x=>x.SubCustomerID == subCustomerInfo);
            var finishedvalue = am.GetBySubCustomer(subCustomerInfo);
            
            return View(finishedvalue);
        }
        public ActionResult ApplyAppointment(int id)
        {
            /* Randevu Alanı */
            var appvalue = am.GetByID(id);
            var calappid = am.GetByID(id).CalendarID;
            appvalue.AppointmentTrackStatus = 4;
            appvalue.AppClickTime = DateTime.Now;
            am.AppointmentUpdate(appvalue);
            
            /* Randevu Alanı */

            /* Takvim Alanı */
            var calappvalue = cm.GetByID((int)calappid);
            if (appvalue.AppointmentLoadType == "Dökme")
            {
                calappvalue.CLDailyAmount += appvalue.AppointmentCapacity;
            }
            else if (appvalue.AppointmentLoadType == "Palet")
            {
                calappvalue.CLPalletCapacity += appvalue.AppointmentCapacity;
            }
            
            cm.CalendarUpdate(calappvalue);
            /* Takvim Alanı */

            return RedirectToAction("Appointments");
        }
        public ActionResult CancelAppointment(int id)
        {
            /* Randevu Alanı */
            var appvalue = am.GetByID(id);
            //var calid = am.GetByID(id).CalendarID;
            ViewBag.d = appvalue.AppointmentID;
            appvalue.AppointmentTrackStatus = 11;
            appvalue.AppClickTime = DateTime.Now;
            /* Randevu Alanı */

            /* Takvim Alanı */
            //var calvalue = cm.GetByID((int)calid);
            //if(appvalue.AppointmentLoadType == "Dökme")
            //{
            //    calvalue.CLDailyAmount -= appvalue.AppointmentCapacity;
            //}
            //else if(appvalue.AppointmentLoadType =="Palet")
            //{
            //    calvalue.CLPalletCapacity -= appvalue.AppointmentCapacity;
            //}
            
            //cm.CalendarUpdate(calvalue);
            /* Takvim Alanı */

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
            asd.AppointmentStatus = false;
            am.AppointmentUpdate(asd);
            am.AppointmentCopyDelete(dsa);
            return RedirectToAction("Appointments");
        }
        
        [HttpGet]
        public ActionResult ThrowToCancelAppointment(int id)
        {
            
            var app = am.GetByID(id);
            return View(app);
        }

        [HttpPost]
        public ActionResult ThrowToCancelAppointment(Appointment p)
        {
            int tempdata = (int)TempData["cancelid"];
            
            var stats = am.GetByID(tempdata).AppointmentUCode;
            var asdd = am.GetByIDForChange(false, stats);
            var dsaa = am.GetByIDForChange(true, stats);
           asdd.AppointmentTrackStatus = 11;
            asdd.AppointmentCancelComment = p.AppointmentCancelComment;
            
                am.AppointmentUpdate(asdd);
            am.AppointmentCopyDelete(dsaa);
            return RedirectToAction("Appointments");
        }
       
        public ActionResult WaitingAppointments(string p)
        {

            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();

            //var graphicresult = apm.GetList().Where(x=>x.SubCustomerID == subCustomerInfo);
            var waitingvalue = am.GetBySubCustomer(subCustomerInfo);
            
            return View(waitingvalue);
        }
        //public ActionResult CanceledAfterChangedAppointments()
        //{
        //    var waitingvalue = am.GetBySubCustomer();
        //    return View(waitingvalue);
        //}
        public ActionResult AppliedWantsCancelAppointments(string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();

            //var graphicresult = apm.GetList().Where(x=>x.SubCustomerID == subCustomerInfo);
            var appwcgvalue = am.GetBySubCustomer(subCustomerInfo);
            
            return View(appwcgvalue);
        }
        public ActionResult YesCancel(int id)
        {
            var yescancel = am.GetByID(id);
            yescancel.AppointmentTrackStatus = 11;
            yescancel.AppClickTime = DateTime.Now;
            am.AppointmentUpdate(yescancel);
            return RedirectToAction("Appointments");
        }
        public ActionResult NoCancel(int id)
        {
            var nocancel = am.GetByID(id);
            nocancel.AppointmentTrackStatus = 6;
            nocancel.AppClickTime = DateTime.Now;
            am.AppointmentUpdate(nocancel);
            return RedirectToAction("Appointments");
        }

        // TEDARİKÇİ EKLEME 

        public ActionResult AddSubCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCustomer(SubCustomer m, string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var CustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();
            m.CustomerID = CustomerInfo;
            csm.SubCustomerAdd(m);
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
            ViewBag.company = appoinmentid.SubCustomer.SubCustomerCompany;
            ViewBag.name = appoinmentid.AppointmentName;
            ViewBag.capacity = appoinmentid.AppointmentCapacity;
            return View(appoinmentid);
        }
        [HttpPost]
        public ActionResult SeeTheAppointment(Appointment p)
        {
            
            am.AppointmentUpdate(p);
            return RedirectToAction("SubCustomerList");
        }

        [HttpGet]
        public ActionResult SeeAndCancelTheAppointment(int id)
        {
            TempData["cancelid"] = id;
            ViewBag.a = id;
            
            var appoinmentid = am.GetByID(id);
            var oldapp = am.GetByIDForChange(false, appoinmentid.AppointmentUCode);
            var newapp = am.GetByIDForChange(true, appoinmentid.AppointmentUCode);

            ViewBag.oldname = oldapp.AppointmentName;
            ViewBag.oldcapacity = oldapp.AppointmentCapacity;
            ViewBag.company = newapp.SubCustomer.SubCustomerCompany;
            ViewBag.name = newapp.AppointmentName;
            ViewBag.capacity = newapp.AppointmentCapacity;
            return View(newapp);
        }
        [HttpPost]
        public ActionResult SeeAndCancelTheAppointment(Appointment p)
        {
            am.AppointmentUpdate(p);
            return RedirectToAction("SubCustomerList");
        }




        public ActionResult UserList(string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();


            var calendarvalues = um.GetListUserByID(subCustomerInfo);
            //TempData["CustomerID"] = id;
            //ViewBag.customerid = id;
            return View(calendarvalues);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            ViewBag.t = TempData["CustomerID"];
            ViewBag.z = "asdasd";
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {


            um.UserAdd(p);
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            ViewBag.t = TempData["CustomerID"];
            var uservalue = um.GetByID(id);
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult EditUser(User p)
        {
            um.UserUpdate(p);
            return RedirectToAction("UserList");
        }
        public ActionResult DeleteUser(int id)
        {//Güncelleme işlemi
            //customer delete kısmına git
            var uservalue = um.GetByID(id);
            um.UserDelete(uservalue);
            return RedirectToAction("UserList");
        }

        public ActionResult pieChartDeneme(string p)
        {
            p = (string)Session["CustomerUsername"];
            Context c = new Context();
            var subCustomerInfo = c.Customers.Where(x => x.CustomerUsername == p).Select(x => x.CustomerID).FirstOrDefault();


            var calendarvalues = um.GetListUserByID(subCustomerInfo);
            //TempData["CustomerID"] = id;
            //ViewBag.customerid = id;
            return View(calendarvalues);
        }
    }

}

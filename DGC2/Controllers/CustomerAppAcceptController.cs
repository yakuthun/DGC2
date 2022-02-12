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
        Context c = new Context();

        
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
        //public ActionResult ApplyAppointment(int id)
        //{
        //    var appvalue = am.GetByID(id);
        //    appvalue.AppointmentAcceptStatus = true;
        //    am.AppointmentUpdate(appvalue);
        //    return RedirectToAction("Appointments");
        //}
        //public ActionResult DeleteAppointment(int id)
        //{
        //    var appvalue = am.GetByID(id);
        //    appvalue.AppointmentAcceptStatus = false;
        //    am.AppointmentDelete(appvalue);
        //    return RedirectToAction("Appointments");
        //}
    }
}
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            var appointmentvalue = am.GetList();
            return View(appointmentvalue);
        }
    }
}
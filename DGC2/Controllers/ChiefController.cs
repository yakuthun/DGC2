using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            var appointments = am.GetList();
            return View(appointments);
        }
    }
}
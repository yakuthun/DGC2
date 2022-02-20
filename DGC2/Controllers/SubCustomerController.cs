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
    public class SubCustomerController : Controller
    {
        // GET: SubCustomer
        SubCustomerManager scm = new SubCustomerManager(new EfSubCustomerDal());
        AppointmentManager apm = new AppointmentManager(new EfAppointmentDal());
        CalendarManager cm = new CalendarManager(new EfCalendarDal());
        public ActionResult Index()
        {
            var Subcustomervalues = apm.GetList();
            return View(Subcustomervalues);
        }
        [HttpGet]
        public ActionResult AddDriver()
        {

            return View();


        }
        [HttpPost]
        public ActionResult AddDriver(Driver p, Appointment ps)
        {
            p.DriverName = "Mahmut";
            //p.DriverSurname = "Özcan";
            p.DriverNumber = "321321321";
            p.DriverPlate = "34 ASD 23";
            p.DriverLogisticName = "React A.Ş.";
            var name = p.DriverName;
            //var surname = p.DriverSurname;
            var number = p.DriverNumber;
            var plate = p.DriverPlate;
            var logisticname = p.DriverLogisticName;
            var app = apm.GetByID(78);
            //ps.AppointmentComment =p.DriverName + " " + p.DriverSurname + " " + p.DriverNumber + " " + p.DriverPlate + " " + p.DriverLogisticName;
            scm.DriverAdd(p);

            var fullname = String.Format("İsim:" + name + " Soyad:" + " Telefon:" + number + " Plaka:" + plate + " Firma:" + logisticname);
            var asd = apm.GetByID(78);
            asd.AppointmentComment = fullname;

            //apm.AppointmentUpdate(app);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditDriver(int id)
        {


            var drivervalue = scm.GetByID(id);
            return View(drivervalue);
        }
        [HttpPost]
        public ActionResult EditDriver(Driver p)
        {

            scm.DriverUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDriver(int id)
        {
            var drivervalue = scm.GetByID(id);
            drivervalue.DriverStatus = false;
            scm.DriverUpdate(drivervalue);
            return RedirectToAction("Index");
        }

        public ActionResult WaitingListAppoinment()
        {
            var listappoinment = apm.GetList();
            return View(listappoinment);

        }
        public ActionResult AskChangeList()
        {
            var listappoinment = apm.GetList();
            return View(listappoinment);

        }

        [HttpGet]
        public ActionResult AskChangeComment(int id)
        {


            var askvalue = apm.GetByID(id);
            return View(askvalue);
        }
        [HttpPost]
        public ActionResult AskChangeComment(Appointment p)
        {

            if (p.AppointmentTrackStatus == 2)
                p.AppointmentTrackStatus = 20;

            apm.AppointmentUpdate(p);
            return RedirectToAction("AppliedListAppoinment");
        }

        [HttpGet]
        public ActionResult EditAskChange(int id)
        {


            var askvalue = apm.GetByID(id);
            return View(askvalue);
        }
        [HttpPost]
        public ActionResult EditAskChange(Appointment p)
        {


            if (p.AppointmentStatus == false)
                p.AppointmentStatus = true;
            if (p.AppointmentTrackStatus == 2)
                p.AppointmentTrackStatus = 24;

            p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            apm.AppointmentAdd(p);
            return RedirectToAction("AppliedListAppoinment");
        }



        public ActionResult CanceledListAppoinment()
        {
            var canceledappoinment = apm.GetList();
            return View(canceledappoinment);

        }
        public ActionResult AppliedListAppoinment()
        {
            var appliedappoinment = apm.GetList();
            return View(appliedappoinment);

        }
        public ActionResult AskChange(int id)
        {
            var appvalue = apm.GetByID(id);


            appvalue.AppointmentStatus = false;
            appvalue.AppointmentTrackStatus = 20;
            apm.AppointmentUpdate(appvalue);
            return RedirectToAction("AppliedListAppoinment");
        }
        public ActionResult CancelChange(int id)
        {
            var appvalue = apm.GetByID(id);
            appvalue.AppointmentTrackStatus = 3;
            apm.AppointmentUpdate(appvalue);
            return RedirectToAction("AppliedListAppoinment");
        }
        public ActionResult CancelChangeList()
        {
            var cancelChangeList = apm.GetList();
            return View(cancelChangeList);
        }

        [HttpGet]
        public ActionResult AddAppoinment(int id, Appointment p)
        {
            var datetime = cm.GetByID(id).CLStartDate;
            var sliceid = cm.GetByID(id).CalendarID;
            TempData["tempdata"] = datetime;
            TempData["tempslice"] = sliceid;
            return View();
            

        }
        [HttpPost]
        public ActionResult AddAppoinment(Appointment p, Driver d)
        {
         
            
            if (p.AppointmentUCode == null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);

                p.AppointmentUCode = finalString;
            }

            p.AppStartDate = DateTime.Parse(TempData["tempdata"].ToString());
            var number = TempData["tempslice"];
            p.CalendarID = int.Parse(number.ToString());

            if (p.DriverStatus == false)
            {
                d.SubCustomerID = p.SubCustomerID;
                d.DriverName = p.AppDriverName;
                d.DriverNumber = p.AppDriverNumber;
                d.DriverPlate = p.AppDriverPlate;
                d.DriverLogisticName = p.AppDriverLogisticName;
                d.DriverStatus = true;
                scm.DriverAdd(d);
            }

            if (p.AppointmentTrackStatus == 0)
            {
                p.AppointmentTrackStatus = 1;
            }

           
            


            //p.AppointmentName = calenderid.Slice.ToString();
            //p.AppStartDate = DateTime.Parse(calenderid.CLStartDate.ToShortTimeString());
            //p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            apm.AppointmentAdd(p);

            return RedirectToAction("Index");
            //if (p.AppointmentTrackStatus == 0)
            //{
            //    p.AppointmentTrackStatus = 1;


            //}
            //p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            //apm.AppointmentAdd(p);
            //return RedirectToAction("Index");
        }


        public ActionResult Calendar()
        {
            var calenderresult = cm.GetList();
            return View(calenderresult);
        }

    }
}
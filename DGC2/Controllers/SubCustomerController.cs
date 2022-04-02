using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;



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
            var graphicresult = apm.GetList();
            return View(graphicresult);
            
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
            askvalue.AppointmentUpdateComment = null;
            askvalue.AppointmentStatus = false;
            return View(askvalue);
        }
        [HttpPost]
        public ActionResult AskChangeComment(Appointment p)
        {

            if (p.AppointmentTrackStatus == 4)
            {

                p.AppointmentTrackStatus = 20;
            }
            
            p.AppointmentStatus = false;
            apm.AppointmentUpdate(p);
            return RedirectToAction("AppliedListAppoinment");
        }

        [HttpGet]
        public ActionResult EditAskChange(int id)
        {


            var askvalue = apm.GetByID(id);
            TempData["oldvalue"] = askvalue.AppointmentID;
            return View(askvalue);
        }
        [HttpPost]
        public ActionResult EditAskChange(Appointment p)
        {

            var oldvalue = apm.GetByID((int)TempData["oldvalue"]);


            oldvalue.AppointmentTrackStatus = 0;
            p.AppStartDate = oldvalue.AppStartDate;
            apm.AppointmentUpdate(oldvalue);

            if (p.AppointmentStatus == false)
                p.AppointmentStatus = true;
            if (p.AppointmentTrackStatus == 4)
                p.AppointmentTrackStatus = 24;


            apm.AppointmentAdd(p);
            return RedirectToAction("AppliedListAppoinment");
        }

        
        [HttpGet]
        public ActionResult EditNotAppliedAppointment(int id )
        {
            var subcustomervalue = apm.GetByID(id);
            ViewBag.editnot = subcustomervalue.AppSlice;
            
            List<SelectListItem> valuecm = (from x in cm.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.CLSlice.ToString(),
                                                Value = x.CalendarID.ToString()
                                            }).ToList();
            ViewBag.vlc = valuecm;
            return View(subcustomervalue);
        }
        [HttpPost]
        public ActionResult EditNotAppliedAppointment(Appointment p, Calendar k)
        {
            //Context c = new Context();
            //var curt = p.AppSlice;
            
            //DateTime dt = DateTime.Now;
            //dt = DateTime.Parse(p.AppStartDate.ToString());

            //var newvalue = c.Calendars.Where(x => x.CLSlice == curt);
             

            apm.AppointmentUpdate(p);
           
            return RedirectToAction("WaitingListAppoinment");
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
        public ActionResult AddAppoinment(int id, string mydatetime, string myhour, string myhourfinish, int myslice)
        {

            ViewBag.deneme = ViewBag.dsa;
            TempData["mydatetime"] = mydatetime;
            TempData["myhour"] = myhour;
            TempData["myhourfinish"] = myhourfinish;
            TempData["myslice"] = myslice;
            var alldatas = cm.GetByID(id);
            var datetime = cm.GetByID(id).CLStartHour;
            var sliceid = cm.GetByID(id).CalendarID;
            var dailyamountid = cm.GetByID(id).CLDailyAmount;
            var dailypaletid = cm.GetByID(id).CLDailyPaletAmount;

            TempData["tempdata"] = datetime;
            TempData["tempslice"] = sliceid;
            TempData["tempdailyamount"] = dailyamountid;
            TempData["tempdailypaletamount"] = dailypaletid;
            TempData["allcalendardata"] = cm.GetByID(id).CalendarID;

            ViewBag.startdate = alldatas.CLStartHour;
            ViewBag.finishdate = alldatas.CLFinishDate;
            return View();


        }
        [HttpPost]
        public ActionResult AddAppoinment(Appointment p, Driver d)
        {


            p.AppStartDate = (string)TempData["mydatetime"];
            p.AppStartHour = (string)TempData["myhour"] + " - " + TempData["myhourfinish"];
            p.AppSlice = (int)TempData["myslice"];

            int asd = (int)TempData["allcalendardata"];

            var allcalendar = cm.GetByID(asd);


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

            //p.AppStartDate = DateTime.Parse(TempData["tempdata"].ToString());

            p.AppClickTime = DateTime.Now;
            //p.AppStartDate =/* DateTime.Parse(TempData["mydatetime"].ToString()); //2 nisan yorum satırına aldım*/
            //p.AppStartHour = DateTime.Parse(TempData["myhour"].ToString());
            //var number = TempData["tempslice"];
            //p.CalendarID = int.Parse(number.ToString());
            p.SubCustomerID = 3;
            p.ChiefID = 1;
            //var dailyamount = (int)TempData["tempdailyamount"];



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


            //if (p.AppointmentLoadType == "Dökme")
            //{
            //    allcalendar.CLDailyAmount += p.AppointmentCapacity;
            //}
            //else if (p.AppointmentLoadType == "Palet")
            //{
            //    allcalendar.CLDailyPaletAmount += p.AppointmentCapacity;
            //}

            if (allcalendar.CLDailyAmount <= allcalendar.CLSumTolerance && allcalendar.CLDailyAmount >= allcalendar.CLAmount)
            {
                p.AppointmentTrackStatus = 30;
            }

            if (allcalendar.CLDailyAmount >= allcalendar.CLAmount && allcalendar.CLDailyAmount <= allcalendar.CLSumTolerance)
            {
                p.AppointmentUpdateComment = "asildi";
            }
            //p.AppointmentName = calenderid.Slice.ToString();
            //p.AppStartDate = DateTime.Parse(calenderid.CLStartDate.ToShortTimeString());
            //p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            cm.CalendarUpdate(allcalendar);
            apm.AppointmentAdd(p);

            return RedirectToAction("WaitingListAppoinment");
            //if (p.AppointmentTrackStatus == 0)
            //{
            //    p.AppointmentTrackStatus = 1;


            //}
            //p.AppStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            //apm.AppointmentAdd(p);
            //return RedirectToAction("Index");
        }

        public ActionResult returnToCalendar(int apvalue = 1, int p = 1)
        {
            var comingnumber = apvalue;
            var today = DateTime.Now;
            var tomorrow = today.AddDays(p - 1);

            ViewBag.pshow = tomorrow;
            var alresult = cm.GetSearchList(comingnumber).ToPagedList(p, 4);

            return View(alresult);

        }
        public ActionResult Calendar(int p = 1, string devam = "bos")
        {
            var deger3 = c.Slices.Where(c => c.SliceStatus == true).Select(x => x.SlicesID).FirstOrDefault();
            ViewBag.d3 = deger3;

            var deger4 = c.Calendars.Where(c => c.Slice.SliceStatus == true).Max(x => x.CLSlice);
            ViewBag.d5 = deger4;

            var today = DateTime.Now;
            var tomorrow = today.AddDays(p - 1);

            


            ViewBag.pshow = tomorrow;


            //var calenderresult = cm.GetList();
            //var TODAY = DateTime.Now;
            //int j = 0;

            //for (int i = 1; i <= 6; i++)
            //{
            //var today = DateTime.Now.AddDays(i - 1);
            //    var TOMORROW = TODAY;
            //    TOMORROW = TOMORROW.AddDays(0);
            //    foreach (var item in calenderresult)
            //    {
            //        if (j == 4)
            //        {
            //            TOMORROW = TOMORROW.AddDays(1);
            //            j = 0;
            //        }
            //        item.CLStartDate = TOMORROW;
            //        cm.CalendarUpdate(item);
            //        j++;

            //    //}

            //}
           
            var curt = cm.GetList().Where(c => c.SlicesID == deger3).OrderByDescending(c => c.CLStartDate).ToPagedList(p, deger4);
            return View(curt);
        }

        [HttpGet]
        public ActionResult SeeTheCanceledAppointment(int id)
        {
            var appointmentvalue = apm.GetByID(id);
            return View(appointmentvalue);
        }


        //------------------------------------------------EGEMEN ALAN--------------------------------------------






        //---------------------------------------------------------------------------------------------------------



        //[HttpPost]
        //public JsonResult Test(Calendar p)
        //{
        //    var deneme = p.CLDailyAmount;
        //    TempData["cldailyamount"] = deneme;
        //    return Json(deneme, JsonRequestBehavior.AllowGet);
        //}




        //------------------------------------------------FURKAN ALAN--------------------------------------------
        public ActionResult Calendar101()
        {
            //var calenderresult = cm.GetList();
            return View();
        }
        Context c = new Context();

        //public JsonResult CalEvents()
        //{

        //    using (_context)
        //    {
        //        var events = _context.CalendarEventsNews.ToList();
        //        return Json(events.ToArray(), JsonRequestBehavior.AllowGet);

        //    }
        //}


        //---------------------------------------------------------------------------------------------------------

    }
}
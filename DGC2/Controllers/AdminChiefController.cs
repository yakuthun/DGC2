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
    public class AdminChiefController : Controller
    {
        // GET: AdminChief
        ChiefManager cm = new ChiefManager(new EfChiefDal());
        public ActionResult Index()
        {
            var chiefvalues = cm.GetList();
            return View(chiefvalues);
        }
        [HttpGet]
        public ActionResult AddChief()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChief(Chief p)
        {
            p.ChiefStartDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            p.ChiefFinishDate = DateTime.Parse(DateTime.Now.ToShortTimeString());


            cm.ChiefAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditChief(int id)
        {
            var chiefvalues = cm.GetByID(id);
            return View(chiefvalues);
        }
        [HttpPost]
        public ActionResult EditChief(Chief p)
        {
            cm.ChiefUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteChief(int id)
        {//Güncelleme işlemi
            //customer delete kısmına git
            var chiefvalue = cm.GetByID(id);
            chiefvalue.ChiefStatus = false;
            cm.ChiefDelete(chiefvalue);
            return RedirectToAction("Index");
        }
    }
}
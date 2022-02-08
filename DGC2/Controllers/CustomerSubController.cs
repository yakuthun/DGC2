﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DGC2.Controllers
{
    public class CustomerSubController : Controller
    {

        // GET: CustomerSub
         CustomerSubManager csm = new CustomerSubManager(new EfCustomerAddSubDal());
        public ActionResult Index()
        {
            var customersubvalues = csm.GetList();
            return View(customersubvalues);
        }
        [HttpGet]
        public ActionResult AddSubCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCustomer(SubCustomer p)
        {
            csm.SubCustomerAdd(p);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Mvc.SmartName.Web.Controllers
{
    public class UnderscoreDelimitedController : Controller
    {
        //
        // GET: /UnderscoreDelimited/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UnderscoreDelimited/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UnderscoreDelimited/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UnderscoreDelimited/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /UnderscoreDelimited/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UnderscoreDelimited/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UnderscoreDelimited/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UnderscoreDelimited/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

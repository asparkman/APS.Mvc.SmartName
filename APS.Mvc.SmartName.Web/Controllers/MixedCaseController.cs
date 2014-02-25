using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Mvc.SmartName.Web.Controllers
{
    public class MixedCaseController : Controller
    {
        //
        // GET: /MixedCase/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MixedCase/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MixedCase/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MixedCase/Create

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
        // GET: /MixedCase/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MixedCase/Edit/5

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
        // GET: /MixedCase/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MixedCase/Delete/5

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

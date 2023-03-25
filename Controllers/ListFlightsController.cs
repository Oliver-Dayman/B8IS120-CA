using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerLingus.Controllers
{
    public class ListFlightsController : Controller
    {
        // GET: ListFlightsController hhh
        public ActionResult Index()
        {
            return View();
        }

        // GET: ListFlightsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListFlightsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListFlightsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListFlightsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListFlightsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListFlightsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListFlightsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

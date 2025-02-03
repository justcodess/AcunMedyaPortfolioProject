using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class FooterController : Controller
    {
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();

        // GET: Footer
        public ActionResult Footer()
        {
            var footer = dB.Footers.ToList();

            return View(footer);
        }
        [HttpGet]
        public ActionResult CreateFooter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFooter(Footer footer)
        {
            dB.Footers.Add(footer);
            dB.SaveChanges();
            return RedirectToAction("Footer");
        }
        public ActionResult DeleteFooter(int id)
        {
            var value = dB.Footers.Find(id);
            dB.Footers.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Footer");
        }
        [HttpGet]
        public ActionResult UpdateFooter(int id)
        {
            var footer = dB.Footers.Find(id);
            return View(footer);
        }
        [HttpPost]
        public ActionResult UpdateFooter(Footer footer)
        {

            {
                var updateFooter = dB.Footers.Find(footer.Id);
                updateFooter.Title = footer.Title;
                updateFooter.CompanyName = footer.CompanyName;
                updateFooter.PersonName = footer.PersonName;
                dB.SaveChanges();
            }
            return RedirectToAction("Footer");
        }
    }
}
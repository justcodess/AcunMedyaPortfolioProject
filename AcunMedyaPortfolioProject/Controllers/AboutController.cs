using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();
        public ActionResult About()
        {

            var about = dB.Abouts.ToList();
            return View(about);
        }
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            dB.Abouts.Add(about);
            dB.SaveChanges();
            return RedirectToAction("About");
        }
        public ActionResult DeleteAbout(int id)
        {
            var value = dB.Abouts.Find(id);
            dB.Abouts.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = dB.Abouts.Find(id);
            return View(about);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var updatedAbout = dB.Abouts.Find(about.Id);
            
            {
                var updateAbout = dB.Abouts.Find(about.Id);
                updatedAbout.Title = about.Title;
                updatedAbout.Description = about.Description;
                updatedAbout.ImageUrl = about.ImageUrl;
                updatedAbout.CVLink = about.CVLink;
                dB.SaveChanges();
            }
            return RedirectToAction("About");
        }
    }
}
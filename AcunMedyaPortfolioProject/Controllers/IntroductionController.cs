using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class IntroductionController : Controller
    {
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();

        // GET: Introduction
        public ActionResult Introduction()
        {
            var introduction = dB.Introductions.ToList();

            return View(introduction);
        }
        [HttpGet]
        public ActionResult CreateIntroduction()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateIntroduction(Introduction introduction)
        {
            dB.Introductions.Add(introduction);
            dB.SaveChanges();
            return RedirectToAction("Introduction");
        }
        public ActionResult DeleteIntroduction(int id)
        {
            var value = dB.Introductions.Find(id);
            dB.Introductions.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Introduction");
        }
        [HttpGet]
        public ActionResult UpdateIntroduction(int id)
        {
            var introduction = dB.Introductions.Find(id);
            return View(introduction);
        }
        [HttpPost]
        public ActionResult UpdateIntroduction(Introduction introduction)
        {

            {
                var updateIntroduction = dB.Introductions.Find(introduction.Id);
                updateIntroduction.Title = introduction.Title;
                updateIntroduction.Description = introduction.Description;
                dB.SaveChanges();
            }
            return RedirectToAction("Introduction");
        }
    }
}
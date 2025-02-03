using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ExperienceController : Controller
    {
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();

        // GET: Experience
        public ActionResult Experience()
        {
            var experience = dB.Experiences.ToList();

            return View(experience);
        }
        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExperience(Experience experience)
        {
            dB.Experiences.Add(experience);
            dB.SaveChanges();
            return RedirectToAction("Experience");
        }
        public ActionResult DeleteExperience(int id)
        {
            var value = dB.Experiences.Find(id);
            dB.Experiences.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Experience");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var experience = dB.Experiences.Find(id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Experience experience)
        {

            {
                var updateExperience = dB.Experiences.Find(experience.Id);
                updateExperience.Title = experience.Title;
                updateExperience.CompanyName = experience.CompanyName;
                updateExperience.StartDate = experience.StartDate;
                updateExperience.EndDate = experience.EndDate;
                updateExperience.Description = experience.Description;
                dB.SaveChanges();
            }
            return RedirectToAction("Experience");
        }
    }
}
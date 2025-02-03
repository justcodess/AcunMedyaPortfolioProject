using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class EducationController : Controller
    {
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();

        // GET: Education
        public ActionResult Education()
        {
            var education = dB.Educations.ToList();

            return View(education);
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            dB.Educations.Add(education);
            dB.SaveChanges();
            return RedirectToAction("Education");
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = dB.Educations.Find(id);
            dB.Educations.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Education");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = dB.Educations.Find(id);
            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {

            {
                var updateEducation = dB.Educations.Find(education.Id);
                updateEducation.Title = education.Title;
                updateEducation.InstutionName = education.InstutionName;
                updateEducation.StartDate = education.StartDate;
                updateEducation.EndTime = education.EndTime;
                updateEducation.Description = education.Description;
                dB.SaveChanges();
            }
            return RedirectToAction("Education");
        }
    }
}
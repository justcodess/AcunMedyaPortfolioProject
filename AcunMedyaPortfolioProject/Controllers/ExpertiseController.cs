using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ExpertiseController : Controller
    {
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();

        // GET: Expertise
        public ActionResult Expertise()
        {
            var expertise = dB.Expertises.ToList();
            return View(expertise);
        }
        public ActionResult CreateExpertise()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExpertise(Expertise expertise)
        {
            dB.Expertises.Add(expertise);
            dB.SaveChanges();
            return RedirectToAction("Expertise");
        }
        public ActionResult DeleteExpertise(int id)
        {
            var value = dB.Expertises.Find(id);
            dB.Expertises.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Expertise");
        }
        [HttpGet]
        public ActionResult UpdateExpertise(int id)
        {
            var expertise = dB.Expertises.Find(id);
            return View(expertise);
        }
        [HttpPost]
        public ActionResult UpdateExpertise(Expertise expertise)
        {
            var updateExpertise = dB.Expertises.Find(expertise.Id);

            {
                updateExpertise.Name = expertise.Name;
                dB.SaveChanges();
            }
            return RedirectToAction("Expertise");
        }
    }
}
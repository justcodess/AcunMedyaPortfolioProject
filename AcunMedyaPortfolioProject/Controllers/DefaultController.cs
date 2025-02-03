using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        PortfolioDBEntities2 db = new PortfolioDBEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSiteHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialIntro()
        {
            var intro = db.Introductions.FirstOrDefault();
            return PartialView(intro);
        }
        public PartialViewResult PartialIntroSocialMedia()
        {
            var socialMedias = db.SocialMedias.ToList();
            return PartialView(socialMedias);
        }

        public PartialViewResult PartialAbout()
        {
            var about = db.Abouts.FirstOrDefault();
            return PartialView(about);
        }
        public PartialViewResult PartialExpertise()
        {
            var expertise = db.Expertises.ToList();
            return PartialView(expertise);
        }
        public PartialViewResult PartialExperience()
        {
            var experiences=db.Experiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult PartialEducation()
        {
            var educations=db.Educations.ToList();
            return PartialView(educations);
        }
        public PartialViewResult PartialProject()
        {
            var projects=db.Projects.ToList();
            return PartialView(projects);
        }
        public PartialViewResult PartialTestimonial()
        {
            var testimonials=db.Testimonials.ToList();
            return PartialView(testimonials);
        }
        public PartialViewResult PartialContact()
        {
            var contact = db.Contacts.FirstOrDefault();

            return PartialView(contact);
        }
        public PartialViewResult PartialFooter()
        {
            var footer = db.Footers.FirstOrDefault();

            return PartialView(footer);
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
        public PartialViewResult PartialCategory()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }
    }
}
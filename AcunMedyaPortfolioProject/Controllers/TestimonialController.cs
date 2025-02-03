using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();
        public ActionResult Testimonial()
        {

            var testimonial = dB.Testimonials.ToList();
            return View(testimonial);
        }
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            dB.Testimonials.Add(testimonial);
            dB.SaveChanges();
            return RedirectToAction("Testimonial");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = dB.Testimonials.Find(id);
            dB.Testimonials.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Testimonial");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = dB.Testimonials.Find(id);
            return View(testimonial);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var updateTestimonial = dB.Testimonials.Find(testimonial.Id);

            {
                updateTestimonial.NameSurname = testimonial.NameSurname;
                updateTestimonial.Title = testimonial.Title;
                updateTestimonial.ImageUrl = testimonial.ImageUrl;
                updateTestimonial.Comment = testimonial.Comment;
                dB.SaveChanges();
            }
            return RedirectToAction("Testimonial");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();
        public ActionResult SocialMedia()
        {
            var socialMedias = dB.SocialMedias.ToList();
            return View(socialMedias);
        }
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            dB.SocialMedias.Add(socialMedia);
            dB.SaveChanges();
            return RedirectToAction("SocialMedia");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = dB.SocialMedias.Find(id);
            dB.SocialMedias.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("SocialMedia");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = dB.SocialMedias.Find(id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var updateSocialMedia = dB.SocialMedias.Find(socialMedia.Id);

            {
                updateSocialMedia.SiteName = socialMedia.SiteName;
                updateSocialMedia.SiteUrl = socialMedia.SiteUrl;
                dB.SaveChanges();
            }
            return RedirectToAction("SocialMedia");
        }
    }
}
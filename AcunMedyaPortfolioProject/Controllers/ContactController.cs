using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();
        public ActionResult Contact()
        {

            var contact = dB.Contacts.ToList();
            return View(contact);
        }
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            dB.Contacts.Add(contact);
            dB.SaveChanges();
            return RedirectToAction("Contact");
        }
        public ActionResult DeleteContact(int id)
        {
            var value = dB.Contacts.Find(id);
            dB.Contacts.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Contact");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = dB.Contacts.Find(id);
            return View(contact);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var updateContact = dB.Contacts.Find(contact.Id);

            {
                updateContact.Phone = contact.Phone;
                updateContact.MailAdress = contact.MailAdress;
                updateContact.Address = contact.Address;
                dB.SaveChanges();
            }
            return RedirectToAction("Contact");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        PortfolioDBEntities2 dB = new PortfolioDBEntities2();
        public ActionResult Index()
        {
            var projects = dB.Projects.ToList();

            return View(projects);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            var categories = dB.Categories.ToList();
            var list = new SelectList(categories, "Id", "Name");
            ViewBag.Categories = list;
            return View();  
        }
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            dB.Projects.Add(project);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = dB.Projects.Find(id);
            dB.Projects.Remove(value);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var project =dB.Projects.Find(id);
            var categories = dB.Categories.ToList();
            var list = new SelectList(categories, "Id", "Name", project.CategoryId);
            ViewBag.Categories = list;
            return View(project);
        }
        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            var updatedProject = dB.Projects.Find(project.Id);
            updatedProject.Name = project.Name;
            updatedProject.CategoryId = project.CategoryId;
            updatedProject.CoverImageUrl = project.CoverImageUrl;
            updatedProject.Description = project.Description;
            updatedProject.ProjectLink = project.ProjectLink;

            dB.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Portfolio_Website.Data;
using Portfolio_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Details(int id)
        {
            IEnumerable<Project> objList = _db.Projects;
            Project project = objList.SingleOrDefault(i => i.ID == id);
            if (project == null)
                return RedirectToAction("NotFoundPage");
            return View(project);
        }

        public IActionResult Index()
        {
            IEnumerable<Project> objList = _db.Projects;
            return View(objList);
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}

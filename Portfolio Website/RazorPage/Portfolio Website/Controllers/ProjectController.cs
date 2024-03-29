﻿using Microsoft.AspNetCore.Http;
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

        public IActionResult Portfolio()
        {
            IEnumerable<Project> objList = _db.Projects;
            return View(objList);
            // return View(nameof(Portfolio), objList);
        }

        public IActionResult Index()
        {
            IEnumerable<Project> objList = _db.Projects;
            return View(objList);
        }

        /*
        public ActionResult Portfolio()
        {
            return View(nameof(Portfolio), OnGet());
        }
        */
    }
}

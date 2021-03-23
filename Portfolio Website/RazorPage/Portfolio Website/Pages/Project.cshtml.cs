using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Portfolio_Website.Controllers;
using Portfolio_Website.Data;
using Portfolio_Website.Models;

namespace Portfolio_Website.Pages
{
    public class ProjectModel : ProjectController
    {
        private readonly ApplicationDbContext _db;

        public ProjectModel(ApplicationDbContext db) : base(db)
        {

        }

        public Project Project { get; set; }
        
        // private readonly IGetAll inMemory;
        // private readonly IConfiguration configuration;
        // public string fillerText;

        public void OnGet(int portfolioID)
        {
            // fillerText = configuration["Lorem Ipsum"];
            
            Project = _db.Projects.SingleOrDefault(p => p.ID == portfolioID);

            /*
            if (Project == null)
                return RedirectToPage("./NotFound");
            return Page();
            */
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Website.Data;
using Portfolio_Website.Models;

namespace Portfolio_Website.Pages
{
    public class PortfolioModel : PageModel
    {
        public IEnumerable<Project> projects;

        public PortfolioModel(IEnumerable<Project> objList)
        {
            projects = objList;
        }
        /*
        private readonly IGetAll inMemory;


        public PortfolioModel(IGetAll getAll)
        {
            this.inMemory = getAll;
        }
        */
    }
}

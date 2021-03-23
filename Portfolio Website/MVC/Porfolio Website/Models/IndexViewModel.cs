using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio_Website.Profiles;

namespace Portfolio_Website.Models
{
    public class IndexViewModel
    {
        //private readonly ILogger<IndexModel> _logger;

        public Profile profile;
        public List<ScheduleItem> educationPlan;

        //private readonly IConfiguration configuration;

        public IndexViewModel()
        {
            //_logger = logger;
            //this.configuration = configuration;
            profile = ProfileManager.profile;
            educationPlan = ProfileManager.plan;
        }

    }
    //public static class DanhoExtender
    //{
    //    //public static string ToMyTime(this DateTime date) => $"{date.Day}/{date.Month}/{date.Year}";
    //}
}

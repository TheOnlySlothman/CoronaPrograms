using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio_Website.Profiles;

namespace Portfolio_Website.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        public Profile profile;
        public List<ScheduleItem> educationPlan;

        //private readonly IConfiguration configuration;

        public IndexModel()
        {
            //_logger = logger;
            //this.configuration = configuration;
            profile = ProfileManager.profile;
            educationPlan = ProfileManager.plan;
        }

        public void OnGet()
        {
            //Description = configuration["Lorem Ipsum"];
            // "fritids aktiviteter?, alder, NAVN, uddannelse, ynglings tal?, svar på filosofiske spørgsmål?, ynglings spil?, ynglings musik?, sprog?, programmerings sprog?, lokation"
            // profile.Description = "Name: Lasse, Age: 22, Freetime Activities: Drinking & Sleeping, Education: 2 years of programming, Favorite number: 13, Philosophical question: i would not kill baby hitler, Music: Metal, Languages: nothing special, Programming Languages: C#, Location: Støvring, Ability to describe yourself: Terrible";
        }

    }
    //public static class DanhoExtender
    //{
    //    //public static string ToMyTime(this DateTime date) => $"{date.Day}/{date.Month}/{date.Year}";
    //}
}

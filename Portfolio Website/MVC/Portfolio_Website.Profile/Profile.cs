using System;
using System.Collections.Generic;

namespace Portfolio_Website.Profiles
{
    public class Profile
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }

        public Profile()
        {
            Image = "/Images/data-4649.jpg";
            Age = Convert.ToInt32(Math.Floor(DateTime.Now.Subtract(new DateTime(1998, 1, 3)).TotalDays / 365.25));
            Location = "Støvring";
            Email = "Lasselm013@gmail.com";
            Description = "Mit navn er Lasse." +
                        $" Jeg er {Age} år gammel og jeg bor i {Location}." +
                        " Jeg er en elev i gang med Data- og kommunikationsuddannelsen Datatekniker med speciale i programmering på Techcollege Aalborg." +
                        " Jeg har valgt denne uddannelse fordi jeg gerne ville lære at programmere." +
                        //og jeg ikke kan finde ud af andet
                        " Jeg er god til Objektorienteret programmering, problem løsning & hjælpe andre" +
                        " men jeg har også prøvet kræfter med Javascript, Python & MSSQL";
            //" Jeg har evner inden for ";

        }
    }

    public class ScheduleItem
    {
        public DateTime start;
        public DateTime end;
        public string name;
        public ScheduleItem(DateTime start, DateTime end, string name)
        {
            this.start = start;
            this.end = end;
            this.name = name;
        }
    }

    public class EducationPlan
    {
        public static List<ScheduleItem> GetPlan()
        {
            return new List<ScheduleItem>
            {
                new ScheduleItem(new DateTime(2020, 1, 6), new DateTime(2020, 3, 13), "Hovedforløb 1"),
                new ScheduleItem(new DateTime(2020, 8, 3), new DateTime(2020, 10, 9), "Hovedforløb 2"),
                new ScheduleItem(new DateTime(2021, 4, 6), new DateTime(2021, 6, 18), "Hovedforløb 3"),
                new ScheduleItem(new DateTime(2021, 10, 11), new DateTime(2021, 12, 17), "Hovedforløb 4"),
                new ScheduleItem(new DateTime(2022, 9, 19), new DateTime(2022, 11, 25), "Hovedforløb 5"),
                new ScheduleItem(new DateTime(2023, 11, 6), new DateTime(2023, 12, 8), "Hovedforløb 6")
            };
        }


    }

    public static class ProfileManager
    {
        public static Profile profile = new Profile();
        public static List<ScheduleItem> plan = EducationPlan.GetPlan();

        
    }
    public static class DanhoExtender
    {
        public static string ToMyTime(this DateTime date) => $"{date.Day}/{date.Month}/{date.Year}";
    }
}

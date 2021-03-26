using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Portfolio_Website.Models
{
    /*
    public interface IGetAll
    {
        public List<Project> GetAll();
        public Project GetProjectByID(int index);
    }
    
    public class ProjectsInMemory : IGetAll
    {
        public readonly List<Project> projects;
        
        public ProjectsInMemory()
        {
            projects = new List<Project>()
            {
                new Project {
                    ID = 1,
                    Title = "Portfolie hjemmeside",
                    Description = "En hjemmeside som jeg kan sende med min ansøgninger",
                    Img = "/images/Portfolio-Website.PNG",
                    WebLink = "https://lass7924portfoliowebsite.azurewebsites.net"
                },
                new Project { 
                    ID = 2, 
                    Title = "Python Pathfinding",
                    Description = "Program som tager en labyrint i billede format med 1 hul i toppen og bunden og finder en sti", 
                    Img = "/images/braid200_breadthfirst_path.png",
                    WebLink = "https://github.com/TheOnlySlothman/PathFinding"
                },
                new Project
                {
                    ID = 3,
                    Title = "Slothbot the Discord bot",
                    Description = "Slothbot er en bot som kører over Discord™. den har funktioner som TicTacToe & google efter dovendyr",
                    Img = "/images/Slothbot.PNG",
                    WebLink = "https://github.com/TheOnlySlothman/SlothbotPublic"
                }
            };
        }
        public Project GetProjectByID(int index)
        {
            return projects.SingleOrDefault(p => p.ID == index);
        }

        public List<Project> GetAll()
        {
            return projects;
        }
    }
    */



    public class Project
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Image")]
        public byte[] ImgByte { get; set; }
        [Required]
        public string Description { get; set; }
        [Url]
        public string WebLink { get; set; }
    }

    public class ProjectWithFile : Project
    {
        [Required]
        public IFormFile ImgFile { get; set; }
    }


}

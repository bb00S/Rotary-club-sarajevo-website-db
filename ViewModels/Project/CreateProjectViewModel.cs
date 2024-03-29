﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RotaryClub.ViewModels.Project
{
    public class CreateProjectViewModel
    {
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IFormFile? Photo { get; set; } 
        [AllowHtml]
        public string Content { get; set; }    
    }
}

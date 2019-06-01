﻿using APIforHouseHoldRapItUP.Areas.HelpPage.Models;
using System.ComponentModel.DataAnnotations;

namespace APIforHouseHoldRapItUP.Controllers
{
    public class LoginViewModel
    {
        public ObjectId _id;
       
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
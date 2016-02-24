﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Awesome.Models.DB;

namespace Awesome.Models.ViewModel
{
    public class UserSignUpView
    {

        public UserSignUpView()
        {
            
        }

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Result Result { get; set; }


    }
}
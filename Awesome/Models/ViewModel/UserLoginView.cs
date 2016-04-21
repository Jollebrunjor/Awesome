﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Security;

namespace Awesome.Models.ViewModel
{
    public class UserLoginView
    {
        public UserLoginView()
        {
            
        }
        public UserLoginView(object errorMessage)
        {
            ErrorMessage = errorMessage;
            if (errorMessage != "")
            {
                HasErrorMessage = true;
            }
        }
        
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public object ErrorMessage { get; set; }
        public bool HasErrorMessage { get; set; }
       

    }

}
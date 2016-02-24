using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Awesome.Models.ViewModel
{
    public class UserLoginView
    {
        
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
       
    }
}
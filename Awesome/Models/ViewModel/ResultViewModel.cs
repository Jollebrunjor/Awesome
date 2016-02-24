using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Awesome.Models.ViewModel
{
    public class ResultViewModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Match 1")]
        public string Match1 { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Match 2")]
        public string Match2 { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Match 3")]
        public string Match3 { get; set; }

        
    }
}
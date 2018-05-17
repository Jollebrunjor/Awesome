using System.ComponentModel.DataAnnotations;

namespace Awesome.Models.ViewModel
{
    public class UserSignUpView
    {

        public UserSignUpView()
        {

        }
        public UserSignUpView(object errorMessage)
        {
            ErrorMessage = errorMessage;
            if (errorMessage != "")
            {
                HasErrorMessage = true;
            }
        }


        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Användarnamn")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        public object ErrorMessage { get; set; }
        public bool HasErrorMessage { get; set; }



    }
}
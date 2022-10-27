using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Awesome.Models.EntityManager;
using Awesome.Models.ViewModel;

namespace Awesome.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignUp()
        {
            return RedirectToAction("Index", "MyPage");
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUpView USV)
        {
                if (ModelState.IsValid)
                {
                    UserManager UM = new UserManager();
                    if (!UM.IsLoginNameExist(USV.LoginName))
                    {
                        UM.AddUserAccount(USV);
                        FormsAuthentication.SetAuthCookie(USV.LoginName, false);
                        TempData.Clear();
                        TempData.Add("Welcome", "Välkommen " + USV.LoginName);
                    return RedirectToAction("Index", "MyPage");
                    }
                    else
                        ModelState.AddModelError("", "Login Name already taken.");
                        TempData.Add("signuperror", "Användarnamnet är upptaget");
                }
                else
                {
                    TempData.Add("signuperror", "Vänligen fyll i alla fält");
                }

                return new RedirectResult(Url.Action("Index", "Home") + "#signup");
           
        }

        public ActionResult LogIn()
        {            
            return RedirectToAction("Index", "MyPage");
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);
  
                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                    TempData.Add("loginerror", "Felaktigt användarnamn eller lösenord");
                }

                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, true);

                        TempData.Clear();
                        TempData.Add("Welcome", "Välkommen " + ULV.LoginName);
                        return RedirectToAction("Index", "MyPage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                        TempData.Add("loginerror", "Felaktigt lösenord");
                    }
                }
            }
            else
            {
                 TempData.Add("loginerror", "Fyll i användarnamn och lösenord");
            }
           
            // If we got this far, something failed, redisplay form  
            return new RedirectResult(Url.Action("Index", "Home") + "#login");
        }


        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            TempData.Add("Logout", "Tack för titten!");
            return new RedirectResult(Url.Action("Index", "Home"));
        }

    }
}
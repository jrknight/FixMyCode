using System.Diagnostics;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Models;
using FixMyCode.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FixMyCode.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private IEmailService EmailService;
        private IUrlHelper UrlHelper;
        private readonly UserManager<AppUser> UserManager;

        public AccountController(UserManager<AppUser> userManager, IEmailService emailService, IUrlHelper urlHelper)
        {
            UserManager = userManager;
            EmailService = emailService;
            UrlHelper = urlHelper;
        }
        
        [HttpGet]
        public async Task<IActionResult> VerifyAccount(string userId, string code, string userType)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(userId);

            var result = await UserManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View("Confirmation");
            }
            
            return View("Index");
        }





        [HttpPost("CreateAccount")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(CredentialModel credentialModel)
        {
            Debug.WriteLine("Controller Activated");

            if (!ModelState.IsValid)
            {
                
                return View("Error");
                
            }

            var user = await UserManager.FindByEmailAsync(credentialModel.Email);

            if (user == null)
            {
                var newUser = new AppUser()
                {
                    UserName = credentialModel.Username,
                    Email = credentialModel.Email,
                    EmailConfirmed = false
                };

                var result = await UserManager.CreateAsync(newUser, credentialModel.Password);

                if (result.Succeeded)
                {
                    var created = await UserManager.FindByEmailAsync(newUser.Email);


                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(created);
                    var callbackUrl = UrlHelper.Action("VerifyAccount", "account", new { UserId = created.Id, code = code }, UrlHelper.ActionContext.HttpContext.Request.Scheme);
                    //var callbackUrl = $"http://{}/MyMvc/MyAction?param1=1&param2=somestring";

                    EmailService.VerifyEmail(created, callbackUrl, "student");

                    return View("Confirmation");
                }
                else
                {
                    await UserManager.DeleteAsync(newUser);
                    return RedirectToPage("Error");
                }
            }

            return RedirectToPage("Error");
        }

        /*[HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await UserManager.FindByEmailAsync(loginModel.Email);

            var login = await SignInManager.PasswordSignInAsync(user, loginModel.Password, true, false);

            if (login.Succeeded)
            {
                return Redirect("/");
            }
            else if (login.IsNotAllowed)
            {
                return View("Error");
            }

            
            return View();
        }*/

    }
}

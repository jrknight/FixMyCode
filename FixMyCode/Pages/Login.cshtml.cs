using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUser> SignInManager;
        private readonly UserManager<AppUser> UserManager;

        public LoginModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }


        [BindProperty]
        public VerificationModel VerificationModel { get; set; }

        public void OnGet()
        {

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {
            var user = await UserManager.FindByEmailAsync(VerificationModel.Email);
            var result = await SignInManager.PasswordSignInAsync(user, VerificationModel.Password, true, false);

            if (user != null && result.Succeeded)
            {
                const string issuer = "https://fixmycode.net";

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName, ClaimValueTypes.String, issuer),
                    new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String, issuer)
                };

                var userIdentity = new ClaimsIdentity(claims, "Password");

                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(30),
                    IsPersistent = true,
                    AllowRefresh = false
                });
                
                /*"Cookie", userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    }*/

                return Redirect("/Submissions/StudentSubmission"); //roles.Contains("Student") ? Redirect("/StudentSubmission") : Redirect("/Browse");

            }

            return Redirect("/");
        }

    }
}

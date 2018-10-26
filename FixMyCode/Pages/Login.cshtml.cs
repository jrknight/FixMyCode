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

            if (user != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = VerificationModel.RememberMe });
                //return RedirectToPage("Index");

                if (HttpContext.User != null)
                {
                    var roles = await UserManager.GetRolesAsync(user);

                    return
                        Redirect("/Submissions/StudentSubmission"); //roles.Contains("Student") ? Redirect("/StudentSubmission") : Redirect("/Browse");
                }

                return RedirectToPage("Error");
            }

            return Redirect("/");
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Models;
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

            var login = await SignInManager.PasswordSignInAsync(user, VerificationModel.Password, true, false);

            if (login.Succeeded)
            {
                return Redirect("/");
            }
            else if (login.IsNotAllowed)
            {
                return RedirectToPage("Error");
            }

            
            return RedirectToPage("/");
        }

    }
}

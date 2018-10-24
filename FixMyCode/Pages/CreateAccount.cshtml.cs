using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class CreateAccountModel : PageModel
    {

        private IEmailService EmailService;
        private IUrlHelper UrlHelper;
        private UserManager<AppUser> UserManager;


        public CreateAccountModel(UserManager<AppUser> userManager, IEmailService ES, IUrlHelper urlHelper)
        {
            UserManager = userManager;
            EmailService = ES;
            UrlHelper = urlHelper;
        }


        [BindProperty]
        [Required]
        public string Username { get; set; }

        [BindProperty]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        [BindProperty]
        [Required]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public string Credentials { get; set; }

        //When the page is loaded
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            Debug.WriteLine("Controller Activated");

            if (!ModelState.IsValid)
            {

                return BadRequest();

            }

            if (Password != ConfirmPassword)
            {
                return BadRequest();
            }

            var user = await UserManager.FindByEmailAsync(Email);

            if (user == null)
            {
                var newUser = new AppUser()
                {
                    UserName = Username,
                    Email = Email,
                    EmailConfirmed = false
                };

                var result = await UserManager.CreateAsync(newUser, Password);

                if (result.Succeeded)
                {
                    var created = await UserManager.FindByEmailAsync(newUser.Email);


                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(created);
                    var callbackUrl = UrlHelper.Action("VerifyAccount", "Account", new { UserId = created.Id, code = code }, UrlHelper.ActionContext.HttpContext.Request.Scheme);
                    //var callbackUrl = $"http://{}/MyMvc/MyAction?param1=1&param2=somestring";

                    EmailService.VerifyEmail(created, callbackUrl);

                    return RedirectToPage("Confirmation");
                }
                else
                {
                    await UserManager.DeleteAsync(newUser);
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
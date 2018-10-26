using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Models;
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
        public CredentialModel CredentialModel { get; set; }

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

            if (CredentialModel.Password != CredentialModel.ConfirmPassword)
            {
                return BadRequest();
            }

            var user = await UserManager.FindByEmailAsync(CredentialModel.Email);

            if (user == null)
            {
                var newUser = new AppUser()
                {
                    UserName = CredentialModel.Username,
                    Email = CredentialModel.Email,
                    EmailConfirmed = false
                };

                var result = await UserManager.CreateAsync(newUser, CredentialModel.Password);

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
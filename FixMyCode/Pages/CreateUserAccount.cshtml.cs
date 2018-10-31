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
using Microsoft.CodeAnalysis.CSharp;

namespace FixMyCode.Pages
{
    public class CreateUserAccountModel : PageModel
    {
        private IEmailService EmailService;
        private IUrlHelper UrlHelper;
        private IUserRepository UserRepository;
        private UserManager<AppUser> UserManager;



        public CreateUserAccountModel(IUserRepository userRepository, IEmailService ES, IUrlHelper urlHelper, UserManager<AppUser> userManager)
        {
            UserRepository = userRepository;
            EmailService = ES;
            UrlHelper = urlHelper;
            UserManager = userManager;
        }


        [BindProperty]
        public CredentialModel CredentialModel { get; set; }

        //When the page is loaded
        public void OnGet(string type)
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

                var result = await UserRepository.AddUserAsync(newUser, CredentialModel.Password);//UserManager.CreateAsync(newUser, CredentialModel.Password);

                if (result.Succeeded)
                {
                    var created = await UserManager.FindByEmailAsync(newUser.Email);


                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(created);
                    var callbackUrl = UrlHelper.Action("VerifyAccount", "Account", new { UserId = created.Id, code = code, userType = "student" }, UrlHelper.ActionContext.HttpContext.Request.Scheme);
                    //var callbackUrl = $"http://{}/MyMvc/MyAction?param1=1&param2=somestring";

                    EmailService.VerifyEmail(created, callbackUrl, "student");

                    return RedirectToPage("Confirmation");
                }
                else
                {
                    await UserManager.RemoveFromRoleAsync(newUser, "User");
                    await UserManager.DeleteAsync(newUser);
                    
                    return RedirectToPage("Error");
                }
            }

            return RedirectToPage("Error");
        }
    }
}
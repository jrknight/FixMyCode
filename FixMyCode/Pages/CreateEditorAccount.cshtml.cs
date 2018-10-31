using System;
using System.Collections.Generic;
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
    public class CreateEditorAccountModel : PageModel
    {

        private IEmailService EmailService;
        private IUrlHelper UrlHelper;
        private IUserRepository UserRepository;
        private UserManager<AppUser> UserManager;



        public CreateEditorAccountModel(IUserRepository userRepository, IEmailService ES, IUrlHelper urlHelper, UserManager<AppUser> userManager)
        {
            UserRepository = userRepository;
            EmailService = ES;
            UrlHelper = urlHelper;
            UserManager = userManager;
        }

        [BindProperty]
        public CredentialModel CredentialModel { get; set; }

        public void OnGet()
        {

        }
    }
}
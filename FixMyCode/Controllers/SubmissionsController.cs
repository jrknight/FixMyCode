using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Models;
using FixMyCode.Pages;
using FixMyCode.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FixMyCode.Controllers
{
    [Authorize]
    [Route("Queries")]
    public class SubmissionsController : Controller
    {
        private IQueryRepository QueryRepository;
        private IEmailService EmailService;
        private UserManager<AppUser> UserManager;

        public SubmissionsController(IQueryRepository IQ, IEmailService ES, UserManager<AppUser> userManager)
        {
            QueryRepository = IQ;
            EmailService = ES;
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Submit")]
        [Authorize(Roles = "Student, Admin")]
        public async Task<IActionResult> StudentSubmission(QueryModel model)
        {
            if (ModelState.IsValid)
            {
                //GetCurrentUserAsync();

                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                


                Query q = new Query { 
                    Date = DateTime.Now,
                    Question = model.Question, 
                    Code = model.Code, 
                    StudentId = user.Id, 
                    Title = model.Title, 
                    Description = model.Description
                };

                QueryRepository.AddQuery(q);


                RedirectToPage("Index");

            }
            else
            {
                // update ui to show error in input
                RedirectToPage("Error");
            }

            if (!await QueryRepository.Save())
            {
                return RedirectToPage("Error");
            }

            return RedirectToPage("Confirmation");
        }
    }
}
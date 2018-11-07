using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Models;
using FixMyCode.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class StudentSubmissionModel : PageModel
    {

        private IQueryRepository QueryRepository;
        private UserManager<AppUser> UserManager;

        public StudentSubmissionModel(IQueryRepository queryRepository, UserManager<AppUser> userManager)
        {
            QueryRepository = queryRepository;
            UserManager = userManager;
        }

        private void GetCurrentUserAsync()
        {
            var userIdentifier = HttpContext.User.Claims.ElementAt(0);
            if (userIdentifier.Type == "")
            {
                
            }
        }

        [BindProperty]
        public QueryModel QueryModel { get; set; }

        //When the page is loaded
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //GetCurrentUserAsync();

                var user = await UserManager.FindByEmailAsync("jrk.reno@gmail.com");
                


                Query q = new Query { Date = DateTime.Now,
                    Question = QueryModel.Question, 
                    Code = QueryModel.Code, 
                    StudentId = user.Id, 
                    Title = QueryModel.Title, 
                    Description = QueryModel.Description
                };
                QueryRepository.AddQuery(q);


                Redirect("/");

            }
            if (!await QueryRepository.Save())
            {
                return RedirectToPage("Error");
            }

            return RedirectToPage("Confirmation");
        }

    }
}

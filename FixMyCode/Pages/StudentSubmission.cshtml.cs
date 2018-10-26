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

        private Task<AppUser> GetCurrentUserAsync() => UserManager.GetUserAsync(HttpContext.User);

        [BindProperty]
        public QueryModel QueryModel { get; set; }

        //When the page is loaded
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            Debug.WriteLine("Controller Activated");

            if (ModelState.IsValid)
            {

                var user = await GetCurrentUserAsync();
                

                Query q = new Query { Date = DateTime.Now, Question = QueryModel.Question, Code = QueryModel.Code, StudentId = user.Id };
                QueryRepository.AddQuery(q);


                Redirect("/");

            }
            if (await QueryRepository.Save())
            {
                return Redirect("Error");
            }
            return RedirectToPage("Confirmation");
        }

    }
}

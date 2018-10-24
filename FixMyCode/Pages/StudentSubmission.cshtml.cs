using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class StudentSubmissionModel : PageModel
    {

        private IQueryRepository QueryRepository;

        public StudentSubmissionModel(IQueryRepository queryRepository)
        {
            QueryRepository = queryRepository;
        }

        [Required]
        public string Question { get; set; }
        [Required]
        public string Code { get; set; }

        //When the page is loaded
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost(StudentSubmissionModel model)
        {
            Debug.WriteLine("Controller Activated");

            if (ModelState.IsValid)
            {
                //TODO: Get Student information in this shit
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                Query q = new Query { Date = DateTime.Now, Question = model.Question, Code = model.Code, StudentId = userId };
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Pages;
using FixMyCode.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FixMyCode.Controllers
{
    [Authorize]
    [Route("Submissions")]
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

        [HttpPost("StudentSubmission")]
        public async Task<IActionResult> StudentSubmission(StudentSubmissionModel model)
        {
            Debug.WriteLine("Controller Activated");

           if (ModelState.IsValid)
            {
                //TODO: Get Student information in this shit
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                Query q = new Query { Date = DateTime.Now, Question = model.Question, Code = model.Code, StudentId = userId };
                QueryRepository.AddQuery(q);
                
                
            }
            if (await QueryRepository.Save())
            {
                return View("Error");
            }
            return View("Confirmation");
        }
    }
}
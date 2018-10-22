using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Pages;
using FixMyCode.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixMyCode.Controllers
{
    [Authorize]
    public class StudentSubmissionController : Controller
    {
        private IQueryRepository QueryRepository;
        private IEmailService EmailService;

        public StudentSubmissionController(IQueryRepository IQ, IEmailService ES)
        {
            QueryRepository = IQ;
            EmailService = ES;
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
                Query q = new Query { Date = DateTime.Now, Question = model.Question, Code = model.Code };
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
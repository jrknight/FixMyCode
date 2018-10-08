using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Pages;
using FixMyCode.Services;
using Microsoft.AspNetCore.Mvc;

namespace FixMyCode.Controllers
{
    public class StudentSubmissionController : Controller
    {
        private IQueryRepository QueryRepository;

        public StudentSubmissionController(IQueryRepository IQ)
        {
            QueryRepository = IQ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentSubmission(StudentSubmissionModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Get Student information in this shit
                Query q = new Query { Date = DateTime.Now, Question = model.question, Code = model.code };
                QueryRepository.AddQuery(q);
            }

            return View("Index", model);
        }
    }
}
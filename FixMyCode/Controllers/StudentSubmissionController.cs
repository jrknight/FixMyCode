﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [HttpPost("StudentSubmission")]
        public IActionResult StudentSubmission(StudentSubmissionModel model)
        {
            Debug.WriteLine("Controller Activated");
            if (ModelState.IsValid)
            {
                //TODO: Get Student information in this shit
                Query q = new Query { Date = DateTime.Now, Question = model.question, Code = model.code };
                QueryRepository.AddQuery(q);
            }

            ConfirmationModel confirmationModel = new ConfirmationModel();

            return View("Confirmation");
        }
    }
}
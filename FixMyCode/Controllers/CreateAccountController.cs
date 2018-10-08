using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Pages;
using FixMyCode.Services;
using Microsoft.AspNetCore.Mvc;

namespace FixMyCode.Controllers
{
    public class CreateAccountController : Controller
    {
        private IQueryRepository QueryRepository;
        private IEmailService EmailService;

        public CreateAccountController(IQueryRepository IQ, IEmailService ES)
        {
            QueryRepository = IQ;
            EmailService = ES;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(CreateAccountModel model)
        {
            Debug.WriteLine("Controller Activated");

            /*if (ModelState.IsValid)
            {
                //TODO: Get Student information in this shit
                Query q = new Query { Date = DateTime.Now, Question = model.question, Code = model.code };
                QueryRepository.AddQuery(q);
                
                
            }*/

            EmailService.EmailStudent("elijahboucharddrhs@gmail.com");

            return View("Confirmation");
        }
    }
}
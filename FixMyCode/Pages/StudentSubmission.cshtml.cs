using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class StudentSubmissionModel : PageModel
    {
        [Required]
        public string question { get; set; }
        [Required]
        public string code { get; set; }

        //When the website is loaded
        public void OnGet()
        {
            question = "This is a question";
            code = "This is a code";
        }
    }
}

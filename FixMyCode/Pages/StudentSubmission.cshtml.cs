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
        public string Question { get; set; }
        [Required]
        public string Code { get; set; }

        //When the page is loaded
        public void OnGet()
        {

        }
    }
}

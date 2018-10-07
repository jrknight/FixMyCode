using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class CodeFixModel : PageModel
    {
        public string editCode { get; set; }
        public string howFixed { get; set; }

        //When the website is loaded
        public void OnGet()
        {
            editCode = "This is a code edit";
            howFixed = "This is how code fix";
        }
    }
}

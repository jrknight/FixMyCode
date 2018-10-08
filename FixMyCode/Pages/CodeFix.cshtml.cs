using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Models;
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

            string x = editCode;
            string y = howFixed;

            CredentialModel a = new CredentialModel { Name = x, Email = "jrk.reno@gmail.com", Password = y };

            Debug.WriteLine($"{a.Name} {a.Email} {a.Password}");



        }
    }
}

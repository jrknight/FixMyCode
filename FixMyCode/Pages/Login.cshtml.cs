using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class LoginModel : PageModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public void OnGet()
        {
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Models
{
    public class CredentialModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string  Email { get; set; }
        
        [Required]
        public string RoleClaim { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}

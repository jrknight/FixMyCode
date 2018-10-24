using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Models
{
    public class CredentialModel
    {
        public string Username { get; set; }
        public string  Email { get; set; }
        public string RoleClaim { get; set; }
        public string Password { get; set; }
        public string Credentials { get; set; }
    }
}

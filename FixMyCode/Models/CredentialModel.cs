using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Models
{
    public class CredentialModel : IdentityUser
    {
        public string Name { get; set; }
        public string RoleClaim { get; set; }
        public string Password { get; set; }
    }
}

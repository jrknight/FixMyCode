using FixMyCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Services
{
    public interface IEmailService
    {
        void EmailStudent(string emailAddress);
        void VerifyEmail(AppUser user, string callbackUrl, string userType);
    }
}

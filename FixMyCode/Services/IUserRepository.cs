using FixMyCode.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Services
{
    public interface IUserRepository
    {
        void AddStudentAsync(string Name, string Email);
        void AddReviewerAsync(string Name, string Credential, string Email);
        Task<AppUser> GetUser(string Email);
    }
}

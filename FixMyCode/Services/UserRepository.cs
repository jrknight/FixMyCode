using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FixMyCode.Entities;
using Microsoft.AspNetCore.Identity;

namespace FixMyCode.Services
{
    public class UserRepository : IUserRepository
    {

        private FixMyCodeDbContext context;
        private UserManager<AppUser> userManager;

        public UserRepository(FixMyCodeDbContext ctx, UserManager<AppUser> userMgr)
        {
            context = ctx;
            userManager = userMgr;
        }

        public async void AddReviewerAsync(string Name, string Credential, string Email)
        {
            AppUser reviewer = new AppUser { Email = Email, Name = Name };

            await userManager.AddClaimAsync(reviewer, new Claim("usertype", "reviewer"));

        }

        public async void AddStudentAsync(string Name, string Email)
        {
            AppUser student = new AppUser { Email = Email, Name = Name };

            await userManager.AddClaimAsync(student, new Claim("usertype", "student"));
        }

        public async Task<AppUser> GetUser(string Email)
        {
            return  await userManager.FindByEmailAsync(Email);
        }
    }
}

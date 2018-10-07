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
            AppUser reviewer = new AppUser { Email = Email };

            await userManager.AddClaimAsync(reviewer, new Claim("usertype", "reviewer"));
            await userManager.AddClaimAsync(reviewer, new Claim("fullname", Name));

        }

        public async void AddStudentAsync(string Name, string Email)
        {
            throw new NotImplementedException();
        }

        public AppUser GetUser(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task<IdentityResult> AddEditorAsync(AppUser user, string password, string Credential)
        {
            var result = userManager.CreateAsync(user, password);

            var reviewer = await userManager.FindByEmailAsync(user.Email);

            if (result.IsCompletedSuccessfully)
            {
                await userManager.AddToRoleAsync(user, "Editor");
                await userManager.AddClaimAsync(reviewer, new Claim("Credential", Credential));

                return await result;
            }

            return await result;
        }

        public async Task<IdentityResult> AddUserAsync(AppUser user, string password)
        {
            var result = userManager.CreateAsync(user, password);

            var created = await userManager.FindByEmailAsync(user.Email);

            if (result.IsCompletedSuccessfully)
            {
                await userManager.AddToRoleAsync(created, "User");


                return await result;
            }

            return await result;
        }

        public async Task<AppUser> GetUser(string Email)
        {
            return  await userManager.FindByEmailAsync(Email);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FixMyCode.Services
{
    public class UserCheck : IUserCheck
    {
        private UserManager<AppUser> UserManager;

        public UserCheck(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task<AppUser> CurrentlyLoggedInUser(HttpContext context)
        {
            var user = await UserManager.GetUserAsync(context.User);
            return user;
        }
    }
}

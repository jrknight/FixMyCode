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
        Task<IdentityResult> AddUserAsync(AppUser user, string password);
        Task<IdentityResult> AddEditorAsync(AppUser user, string password, string credential);
        Task<AppUser> GetUser(string Email);
    }
}

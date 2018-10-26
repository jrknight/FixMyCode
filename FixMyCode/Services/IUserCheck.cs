using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using Microsoft.AspNetCore.Http;

namespace FixMyCode.Services
{
    public interface IUserCheck
    {
        Task<AppUser> CurrentlyLoggedInUser(HttpContext context);
    }
}

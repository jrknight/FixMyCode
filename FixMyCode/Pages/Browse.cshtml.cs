using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class BrowseModel : PageModel
    {

        
        private IQueryRepository QueryRepository;
        private UserManager<AppUser> UserManager;

        public BrowseModel(IQueryRepository queryRepository, UserManager<AppUser> userManager)
        {
            QueryRepository = queryRepository;
            UserManager = userManager;
        }

        
        public static List<Query> Queries;

        public async Task OnGet()
        {
            Queries = (List<Query>) await QueryRepository.GetAllUnsolvedQueries();
            foreach(Query q in Queries)
            {
                q.Student = await UserManager.FindByIdAsync(q.StudentId);
            }
        }
    }
}
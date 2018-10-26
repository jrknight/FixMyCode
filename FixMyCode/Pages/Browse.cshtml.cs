using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using FixMyCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FixMyCode.Pages
{
    public class BrowseModel : PageModel
    {
        private IQueryRepository QueryRepository;

        public BrowseModel(IQueryRepository queryRepository)
        {
            QueryRepository = queryRepository;
        }

        public static IEnumerable<Query> Queries;

        public async void OnGet()
        {
            Queries = await QueryRepository.GetAllUnsolvedQueries();
        }
    }
}
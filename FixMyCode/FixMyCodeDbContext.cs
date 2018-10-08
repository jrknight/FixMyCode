using FixMyCode.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode
{
    public class FixMyCodeDbContext : DbContext
    {

        public FixMyCodeDbContext(DbContextOptions<FixMyCodeDbContext> options) : base(options)
        {

        }



        public DbContextOptions Options { get; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Response> Responses { get; set; }

    }
}

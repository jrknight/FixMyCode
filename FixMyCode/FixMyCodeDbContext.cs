using FixMyCode.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode
{
    public class FixMyCodeDbContext : IdentityDbContext<AppUser>
    {

        public FixMyCodeDbContext(DbContextOptions<FixMyCodeDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbContextOptions Options { get; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Response> Responses { get; set; }

    }
}

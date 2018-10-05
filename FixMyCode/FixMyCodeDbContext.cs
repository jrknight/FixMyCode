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

        public DbSet<Query> Queries { get; set; }

    }
}

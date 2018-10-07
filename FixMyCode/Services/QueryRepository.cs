using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixMyCode.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixMyCode.Services
{
    public class QueryRepository : IQueryRepository
    {

        /*
         * Class handling query storage and retreival with the app and the database
         * 
         */

        FixMyCodeDbContext context;

        //Initializes the 
        public QueryRepository(FixMyCodeDbContext ctx)
        {
            context = ctx;
        }

        //Given a query type, it will put the query in the Db
        public async void AddQuery(Query query)
        {
            await context.Queries.AddAsync(query);
        }

        /*
         *TODO: Method needs to be looked at after auth is working properly
         * Method will return all of a students queries in a list
         */
        public async Task<IEnumerable<Query>> GetQueriesWithStudent(int studentId)
        {
            return await context.Queries.Where(q => q.Student.Id == studentId.ToString()).ToListAsync();
        }
        
        //Will return a specific query from a student
        public async Task<Query> GetQuery(int Id)
        {
            return await context.Queries.FirstOrDefaultAsync(q => q.Id == Id);
        }

        public bool Save()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}

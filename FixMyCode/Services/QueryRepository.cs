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

        public async Task<IEnumerable<Query>> GetAllUnsolvedQueries()
        {
            return await context.Queries.Where(q => !q.IsSolved).ToListAsync();
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

        public async Task<bool> Save()
        {
            return (await context.SaveChangesAsync() >= 0);
        }

        public async void SolveQuery(int QueryId)
        {
            var query = await context.Queries.Where(q => q.Id == QueryId).FirstOrDefaultAsync();
            query.IsSolved = true;

        }
    }
}

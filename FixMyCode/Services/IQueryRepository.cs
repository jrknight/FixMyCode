using FixMyCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Services
{
    public interface IQueryRepository
    {
        
        Task<Query> GetQuery(int Id);
        Task<IEnumerable<Query>> GetQueriesWithStudent(int studentId);
        void AddQuery(Query query);
        bool Save();

    }
}

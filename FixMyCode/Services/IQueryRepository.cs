using FixMyCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Services
{
    public interface IQueryRepository
    {

        IEnumerable<Query> GetQuery();
        Query GetQuery(int Id);
        IEnumerable<Query> GetQueriesWithStudent(int studentId);
        void AddAuthor(Query query);
        bool Save();

    }
}

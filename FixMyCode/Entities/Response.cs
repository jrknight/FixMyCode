using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Entities
{
    public class Response
    {
        public int Id { get; set; }
        
        public AppUser Reviewer { get; set; }
        public AppUser Student { get; set; }

    }
}

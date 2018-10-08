using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Entities
{
    public class Response
    {
        public int Id { get; set; }
        
        public string OriginalCode { get; set; }
        public string FixedCode { get; set; }

        public AppUser Reviewer { get; set; }
        public AppUser Student { get; set; }

    }
}

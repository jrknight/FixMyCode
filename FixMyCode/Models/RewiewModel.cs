using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Models
{
    public class RewiewModel
    {
        public string FixedCode { get; set; }
        public int StudentId { get; set; }
        public string OriginalCode { get; set; }
        public string Description { get; set; }
        
        //TODO: Make this process work.
        // Set up repository to handle this action associated with this model.
    }
}

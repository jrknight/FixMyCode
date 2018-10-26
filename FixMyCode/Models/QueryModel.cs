using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Models
{
    public class QueryModel
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Code { get; set; }
    }
}

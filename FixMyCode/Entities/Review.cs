using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string FixedCode { get; set; }

        [Required]
        public string WhatWhy { get; set; }

        [Required]
        public int QueryId { get; set; }

        public Query Query { get; set; }
        
        [Required]
        public int ReviewerId { get; set; }
        
        [Required]

        public AppUser Reviewer { get; set; }

    }
}

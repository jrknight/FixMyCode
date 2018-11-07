using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Entities
{
    public class Query
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IsSolved { get; set; } = false;
        [Required]
        public string StudentId { get; set; }


        public AppUser Student { get; set; }
    }
}

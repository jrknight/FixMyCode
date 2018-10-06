using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FixMyCode.Entities
{
    public class Reviewer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Credential { get; set; } // to be made it's own class in a later version with other properties, but for now, just job title/experience
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

    }
}

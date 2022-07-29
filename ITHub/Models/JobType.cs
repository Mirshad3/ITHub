using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITHub.Models
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
} 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public List<JobWithJobType> JobWithJobType { get; set; }
    }
    public class JobWithJobType
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public int JobTypeId { get; set; }
        [ForeignKey("JobId")]
        public Job Jobs { get; set; }
        [ForeignKey("JobTypeId")]
        public JobType JobType { get; set; }
    }
} 
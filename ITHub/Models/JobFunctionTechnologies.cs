using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class JobFunction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
    public class JobWithFunction
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public int JobFunctionId { get; set; }
        [ForeignKey("JobId")]
        public Job Jobs { get; set; }
        [ForeignKey("JobFunctionId")]
        public JobFunction JobFunction { get; set; }
    }
    public class JobTechnologies
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class JobWithTechnologies
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public int JobTechnologiesId { get; set; }
        [ForeignKey("JobId")]
        public Job Jobs { get; set; }
        [ForeignKey("JobTechnologiesId")]
        public JobTechnologies JobTechnologies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class WorkMode
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ExperienceLevel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class JobWithExperienceLevel
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public int ExperienceLevelId { get; set; }
        [ForeignKey("JobId")]
        public Job Jobs { get; set; }
        [ForeignKey("ExperienceLevelId")]
        public ExperienceLevel ExperienceLevel { get; set; }
    }
    public class CurrencyType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Remuneration
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

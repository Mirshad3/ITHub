using System.ComponentModel.DataAnnotations;

namespace ITHub.Models
{
    public class QuestionCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
} 
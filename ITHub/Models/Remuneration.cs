using System.ComponentModel.DataAnnotations;

namespace ITHub.Models
{
    public class Remuneration
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; } 

    }
    public class RemunerationRange
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

    }
    public class DatePosted
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
}

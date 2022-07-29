using System.ComponentModel.DataAnnotations;

namespace ITHub.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
} 
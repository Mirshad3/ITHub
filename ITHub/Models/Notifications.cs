using System;
using System.ComponentModel.DataAnnotations;

namespace ITHub.Models
{
    public class Notifications
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }      
        public DateTime PublishedTime { get; set; }
    }
}

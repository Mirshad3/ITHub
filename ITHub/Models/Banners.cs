using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class Banners
    {
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Link { get; set; }
		public string ImagePath { get; set; }
		public string Status { get; set; }
		public DateTime CreatedDate { get; set; }
		[ForeignKey("AspNetUsers")]
		public int UserId { get; set; }
	}
} 
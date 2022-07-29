using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class Questions
    {	
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[ForeignKey("QuestionCategory")]
		public string QuestionCategoryId { get; set; }
		public int OrderLevel { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		public string MaterialUrl { get; set; }
		public string MaterialPath { get; set; }
		public DateTime CreatedDate { get; set; }
		[ForeignKey("AspNetUsers")]
		public int UserId { get; set; } 
	}
} 
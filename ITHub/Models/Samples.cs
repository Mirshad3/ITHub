using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class Samples
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[ForeignKey("SampleType")]
		public int SampleType { get; set; }
		public string UploadPath { get; set; }
		[ForeignKey("AspNetUsers")]
		public int UserId { get; set; }
		public string Status { get; set; }
		public DateTime CreatedDate { get; set; }
	}
} 
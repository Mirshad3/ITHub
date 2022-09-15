using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class Company
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }		
		public string Address { get; set; }
		public string Contact { get; set; }
		public string ComanyLogoImagePath { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public string Status { get; set; }  
		public DateTime CreatedDate { get; set; }


	}
} 
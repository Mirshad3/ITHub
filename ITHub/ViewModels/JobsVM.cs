using ITHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.ViewModels
{
    public class JobsVM
    {
		[Key]
		public int Id { get; set; }
		public string Title { get; set; } 
		public string Description { get; set; } 
		public string JobSalary { get; set; }
		public string Status { get; set; }
		public DateTime PostingDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public DateTime CreatedDate { get; set; } 
		public int NoOfVacancy { get; set; }
		public string BriefDescription { get; set; }
		public string LongDescription { get; set; }
		public bool IsPegged { get; set; }  
		public string JobImageId { get; set; }
		public int RemunerationMax { get; set; }
		public int RemunerationMin { get; set; }

		[ForeignKey("Location")]
		public Location Locations { get; set; }
		[ForeignKey("CompanyId")]
		public Company Company { get; set; }
		[ForeignKey("CurrencyTypeId")]
		public CurrencyType CurrencyType { get; set; }
		[ForeignKey("RemunerationId")]
		public Remuneration Remuneration { get; set; }
		[ForeignKey("WorkmodeId")]
		public WorkMode WorkMode { get; set; }
		public List<JobType> JobTypes { get; set; }
		public List<ExperienceLevel> ExperienceLevel { get; set; }
		public List<JobFunction> JobFunction { get; set; }
		public List<JobTechnologies> JobTechnologies { get; set; }
		 
		 
	}
}

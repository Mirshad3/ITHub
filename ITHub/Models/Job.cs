using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class Job
    {
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
	
		public int Location { get; set; }
		public string Description { get; set; }
	
		public int CompanyId { get; set; }
		public string JobSalary { get; set; } 
		public string Status { get; set; }
		public DateTime PostingDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public DateTime CreatedDate { get; set; }	
		public int NoOfVacancy { get; set; }
		public string BriefDescription { get; set; }
		public string LongDescription { get; set; }
		public bool IsPegged { get; set; }
		public int CurrencyTypeId { get; set; }		 
		public int WorkmodeId { get; set; }
		public int RemunerationId { get; set; }
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
		public List<JobWithJobType> JobWithJobTypes { get; set; }
		public List<JobWithExperienceLevel> JobWithExperienceLevel { get; set; }
		public List<JobWithFunction> JobWithFunction { get; set; }
		public List<JobWithTechnologies> JobWithTechnologies { get; set; } 

		[BindProperty]
		[NotMapped]
		public int[] SelectedexperienceLevelIds { get; set; }
		[BindProperty]
		[NotMapped]
		public int[] SelectedjobTechnologiesIds { get; set; }
		[BindProperty]
		[NotMapped]
		public int[] SelectedjobFunctionsIds { get; set; }
		[BindProperty]
		[NotMapped]
		public int[] SelectedjobTypeIds { get; set; }
		[BindProperty]
		[NotMapped]
		public MultiSelectList GetExistingSelectedExperienceLevelIds { get; set; }
		[BindProperty]
		[NotMapped]
		public MultiSelectList GetExistingSelectedJobTechnologiesIds { get; set; }
		[BindProperty]
		[NotMapped]
		public MultiSelectList GetExistingSelectedJobFunctionsIds { get; set; }
		[BindProperty]
		[NotMapped]
		public MultiSelectList GetExistingSelectedJobTypeIds { get; set; }

	}
}
 
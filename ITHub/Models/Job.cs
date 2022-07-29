using System;
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
		
		public int JobType { get; set; }
		public string Status { get; set; }
		public DateTime PostingDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public DateTime CreatedDate { get; set; }		 
		public int UserId { get; set; }
		public int NoOfVacancy { get; set; }
		public string BriefDescription { get; set; }
		public string LongDescription { get; set; }
		public bool IsPegged { get; set; }
		public int CurrencyTypeId { get; set; }
		public int JobFunctionId { get; set; }
		public int TechnologiesId { get; set; }
		public int ExperienceLevelId { get; set; }
		public int WorkmodeId { get; set; }
		public int RemunerationId { get; set; }
		public int JobImageId { get; set; }
		public int RemunerationMax { get; set; }
		public int RemunerationMin { get; set; }

        [ForeignKey("Location")]
        public Location Locations { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [ForeignKey("JobType")]
        public JobType JobTypes { get; set; }

    }
}
 
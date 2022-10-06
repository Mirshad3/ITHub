using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHub.Models
{
    public class AppliedJobs
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public int CvId { get; set; }
        public string ApplicationState { get; set; }
        public DateTime jobAppliedDate { get; set; }
        [ForeignKey("JobId")]
        public Job Jobs { get; set; }
        [ForeignKey("CvId")]
        public CvData CvDatas { get; set; }
        public string UserId { get; set; }
    }
    public class CvData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CvUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
    
}

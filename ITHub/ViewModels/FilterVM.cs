using ITHub.Models;
using System.Collections.Generic;

namespace ITHub.ViewModels
{
    public class FilterVM
    {
        public ExperienceLevelVM experienceLevel { get; set; }
        public ToolsAndTechVM jobTechnologies { get; set; }
        public JobFunctionVM jobFunctions { get; set; }
        public JobTypeVM jobType { get; set; }
        public WorkModeVM workMode { get; set; }
        public RemunerationVM remuneration { get; set; }
        public RemunerationRangeVM remunerationRange { get; set; }
        public DatePostedVM datePosted { get; set; }

    }
    public class ExperienceLevelVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<ExperienceLevel> Options { get; set; }
    }
    public class ToolsAndTechVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<JobTechnologies> Options { get; set; }
    }
    public class JobFunctionVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<JobFunction> Options { get; set; }
    }
    public class JobTypeVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<JobType> Options { get; set; }
    }
    public class WorkModeVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<WorkMode> Options { get; set; }
    }
    public class RemunerationVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<Remuneration> Options { get; set; }
    }
    public class RemunerationRangeVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<RemunerationRange> Options { get; set; }
    }
    public class DatePostedVM
    { 
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<DatePosted> Options { get; set; }
    }
}

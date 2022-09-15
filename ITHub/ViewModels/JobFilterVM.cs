using ITHub.Models;
using System.Collections.Generic;

namespace ITHub.ViewModels
{
    public class JobFilterVM
    {
        public List<ExperienceLevel> experienceLevel { get; set; }
        public List<JobTechnologies>  jobTechnologies { get; set; }
        public JobFunctionVM jobFunctions { get; set; }
        public JobTypeVM jobType { get; set; }
        public WorkModeVM workMode { get; set; }
        public RemunerationVM remuneration { get; set; }
        public RemunerationRangeVM remunerationRange { get; set; }
        public DatePostedVM datePosted { get; set; }

    }
}

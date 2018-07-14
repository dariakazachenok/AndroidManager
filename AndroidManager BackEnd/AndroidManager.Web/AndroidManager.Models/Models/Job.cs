using AndroidManager.Models.Enums;
using System.Collections.Generic;

namespace AndroidManager.Web
{
    public class Job
    {
        public int? Id { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public ComplexityLevel? ComplexityLevel { get; set; }

        public virtual ICollection<AndroidJob> AndroidJobs { get; set; }
        public Job()
        {
            AndroidJobs = new List<AndroidJob>();
        }
    }
}

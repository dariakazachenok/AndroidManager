using AndroidManager.WebApi;
using System;
using System.Linq;

namespace AndroidManager.Web.Automapper
{
    public class JobProfile : AutoMapper.Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDTOModel>()
             .ForMember(x => x.AssignedAndroids, y => y.MapFrom(z =>
               String.Join(Environment.NewLine, z.AndroidJobs.ToList().Select(x => x.Android.AndroidName).ToList())));

            CreateMap<JobBindModel, Job>();
        }
    }
}

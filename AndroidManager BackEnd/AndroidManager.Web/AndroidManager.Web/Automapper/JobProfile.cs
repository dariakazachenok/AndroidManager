using AndroidManager.WebApi;

namespace AndroidManager.Web.Automapper
{
    public class JobProfile : AutoMapper.Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDTOModel>();
            CreateMap<JobBindModel, Job>();
        }
    }
}

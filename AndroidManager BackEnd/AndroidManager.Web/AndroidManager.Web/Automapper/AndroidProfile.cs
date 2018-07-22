using AndroidManager.WebApi;
using System;
using System.Linq;

namespace AndroidManager.Web.Automapper
{
    public class AndroidProfile : AutoMapper.Profile
    {
        public AndroidProfile()
        {

            CreateMap<Android, AndroidDTOModel>()
               .ForMember(x => x.CompletedJobs, y => y.MapFrom(z =>
               String.Join(Environment.NewLine, z.AndroidJobs.ToList().Select(x => x.Job.JobName).ToList())))
               .ForMember(x => x.AvatarImage, y => y.MapFrom(z => Convert.ToBase64String(z.AvatarImage)));

            CreateMap<AndroidBindModel, Android>();
        }
    }
}

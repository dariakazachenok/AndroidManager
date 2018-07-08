using AndroidManager.WebApi;

namespace AndroidManager.Web.Automapper
{
    public class AndroidProfile : AutoMapper.Profile
    {
        public AndroidProfile()
        {
            CreateMap<Android, AndroidDTOModel>();
            CreateMap<AndroidBindModel, Android>();
        }
    }
}

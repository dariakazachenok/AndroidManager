using AndroidManager.Models.Enums;

namespace AndroidManager.WebApi
{
    public class JobBindModel
    {
        public string JobName { get; set; }
        public string Description { get; set; }
        public ComplexityLevel? ComplexityLevel { get; set; }
    }
}

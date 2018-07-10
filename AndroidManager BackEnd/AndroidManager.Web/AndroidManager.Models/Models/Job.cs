using AndroidManager.Models.Enums;

namespace AndroidManager.Web
{
    public class Job
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ComplexityLevel? ComplexityLevel { get; set; }
    }
}

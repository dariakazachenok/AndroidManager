using AndroidManager.Models.Enums;

namespace AndroidManager.WebApi
{
    public class JobDTOModel
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public ComplexityLevel? ComplexityLevel { get; set; }
        public string AssignedAndroids { get; set; }
    }
}

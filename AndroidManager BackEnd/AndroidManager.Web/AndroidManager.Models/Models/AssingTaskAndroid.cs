using AndroidManager.Models.Enums;

namespace AndroidManager.Web
{
    public class AssingTaskAndroid
    {
        public int? Id { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }
        public ComplexityLevel? ComplexityLevel { get; set; }
        public int AndroidName { get; set; }
        public int Reliability { get; set; }
        public bool Status { get; set; }
    }
}

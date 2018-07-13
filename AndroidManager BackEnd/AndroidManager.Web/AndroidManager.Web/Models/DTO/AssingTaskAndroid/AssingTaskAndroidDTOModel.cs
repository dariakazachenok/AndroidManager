using AndroidManager.Models.Enums;

namespace AndroidManager.Web.Models.BindModel.AssingTaskAndroid
{
    public class AssingTaskAndroidDTOModel
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

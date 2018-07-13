using Microsoft.AspNetCore.Http;

namespace AndroidManager.WebApi
{
    public class AndroidDTOModel
    {
        public int Id { get; set; }
        public string AndroidName { get; set; }
        public string Skills { get; set; }
        public int Reliability { get; set; }
        public bool Status { get; set; }
    }
}

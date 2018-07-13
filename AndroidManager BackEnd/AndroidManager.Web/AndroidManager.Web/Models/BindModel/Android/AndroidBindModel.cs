using Microsoft.AspNetCore.Http;

namespace AndroidManager.WebApi
{
    public class AndroidBindModel
    {
        public string AndroidName { get; set; }
        public string Skills { get; set; }
        public int Reliability { get; set; }
        public bool Status { get; set; }
    }
}

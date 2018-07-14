
using System.Collections.Generic;

namespace AndroidManager.Web.Models
{
    public class AssignJobsModel
    {
        public int AndroidId { get; set; }
        public List<int> JobIds { get; set; }
    }
}

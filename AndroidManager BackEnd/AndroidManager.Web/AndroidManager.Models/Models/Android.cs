using System.Collections.Generic;

namespace AndroidManager.Web
{
   public class Android
   {
        public Android()
        {
            AndroidJobs = new List<AndroidJob>();
        }
        public int? Id { get; set; }
        public string AndroidName { get; set; }
        public byte[] AvatarImage { get; set; }
        public string Skills { get; set; }
        public int Reliability { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<AndroidJob> AndroidJobs { get; set; }
    }
}

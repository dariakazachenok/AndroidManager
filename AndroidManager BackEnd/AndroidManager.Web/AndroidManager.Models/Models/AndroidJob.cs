namespace AndroidManager.Web
{
   public class AndroidJob
    {
        public int AndroidId { get; set; }
        public Android Android { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}

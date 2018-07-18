namespace AndroidManager.Web.Models
{
    public class JwtConfigurationModel
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpireTime { get; set; }
    }
}

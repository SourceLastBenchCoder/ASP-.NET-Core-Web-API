namespace My.Simple.Web.API.Models
{
    public class MailInfo
    {
        public bool IsMailRequired { get; set; }
        public string SMTPPort { get; set; }
        public string MailFrom { get; set; }
    }
}

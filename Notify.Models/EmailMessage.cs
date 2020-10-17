using System;

namespace Notify.Models
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string TextTo { get; set; }
        public string Cc { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ReplyTo { get; set; }
        public SmtpOption SmtpOptions { get; set; }
        public string UserId { get; set; }
        public bool UseSsl { get; set; }
        public string Template { get; set; }
    }
}

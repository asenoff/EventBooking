using System.ComponentModel.DataAnnotations;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class Mails
    {
        [Key]
        public string MailAlias { get; set; }

        public string MailName { get; set; }

        public string MailTemplate { get; set; }
    }
}

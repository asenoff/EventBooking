using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class PreferencesSet
    {
        [Key, ForeignKey("User"), Required]
        public string UserMail { get; set; }

        public bool RecieveMailsFromApp { get; set; } = true;

        public bool RecieveFullEventInfo { get; set; }

        public virtual AppUser User { get; set; }
    }
}

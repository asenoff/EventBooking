using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class RightsSet
    {
        [Key, Required]
        public string RightsAlias { get; set; }

        public bool CanCreateEvents { get; set; }

        public bool CanDeleteEvents { get; set; }

        public bool CanUpdateEventParticipants { get; set; }

        public bool CanUpdateEventDescription { get; set; }

        public bool CanSeeUsers { get; set; }

        public bool CanDeleteUser { get; set; }

        public bool CanUpdateUser { get; set; }

        public bool CanChangeRights { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }
}

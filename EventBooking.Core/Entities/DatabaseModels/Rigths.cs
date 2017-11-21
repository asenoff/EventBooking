using System.ComponentModel.DataAnnotations;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class Rights
    {
        [Key]
        public string RightsModelName { get; set; }

        public bool CanCreateEvents { get; set; }

        public bool CanDeleteEvents { get; set; }

        public bool CanUpdateEventParticipants { get; set; }

        public bool CanUpdateEventDescription { get; set; }

        public bool CanSeeUsers { get; set; }

        public bool CanDeleteUser { get; set; }

        public bool CanUpdateUser { get; set; }

        public bool CanChangeRights { get; set; }
    }
}

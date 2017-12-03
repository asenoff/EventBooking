using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventBooking.Core.Entities.DatabaseModels.ManyToMany;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public abstract class Participant : AppUser
    {
        public Participant()
        {
            AttendedEvents = new HashSet<EventParticipant>();
        }

        [Required, Phone]
        public string Phone { get; set; }
        
        [Url]
        public string FacebookLink { get; set; }

        public virtual AppUser User { get; set; }

        public virtual ICollection<EventParticipant> AttendedEvents { get; set; }
    }
}

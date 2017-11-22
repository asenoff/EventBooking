using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventBooking.Core.Entities.DatabaseModels.ManyToMany;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public abstract class Participant : User
    {
        public Participant()
        {
            AttendedEvents = new HashSet<EventParticipant>();
        }

        [Required]
        public string Phone { get; set; }
        
        public string FacebookLink { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<EventParticipant> AttendedEvents { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventBooking.Core.Entities.DatabaseModels.ManyToMany;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class Event
    {
        public Event()
        {
            EventGuides = new HashSet<EventGuide>();
            EventParticipants = new HashSet<EventParticipant>();
        }

        [Key, Required]
        public int ID { get; set; }

        public virtual ICollection<EventGuide> EventGuides { get; set; }

        public virtual ICollection<EventParticipant> EventParticipants { get; set; }

        [Required]
        [StringLength(1200)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 20)]
        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        public string Place { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        public virtual EventImage Image { get; set; }

        public int MaxNumberOfParticipants { get; set; }

        public int? MinNumberOfCars { get; set; }

        public bool OrganizeCarsTransportation { get; set; }

        public bool MembershipPreference { get; set; } = true;

        public bool FirstTimerPreference { get; set; } = false;
    }
}

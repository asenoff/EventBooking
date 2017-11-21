using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class Event
    {
        [Key]
        public Guid ID { get; set; }

        public List<Guide> Guides { get; set; }

        public List<Participant> Participants { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public Image Image { get; set; }

        public int MaxNumberOfParticipants { get; set; }
    }
}
